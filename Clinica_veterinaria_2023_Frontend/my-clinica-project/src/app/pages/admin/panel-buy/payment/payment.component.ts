import { ProductService } from './../../../../services/product.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { PaddingService } from 'src/app/services/Padding.service';
import { AsaasService } from 'src/app/services/asaas.service';
import { DataService } from 'src/app/services/data.service';
import { SaleServicePaymentService } from 'src/app/services/saleServicePayment.service';
import Swal from 'sweetalert2';
interface CallbackPayload {
  successUrl: string;
  autoRedirect: boolean;
}

interface AsaasPaymentLinkPayload {
  saleId:string;
  billingType: string;
  chargeType: string;
  name: string;
  description: string;
  endDate: string;
  value: number;
  dueDateLimitDays: number;
  subscriptionCycle: string;  // Use string ou uma união de strings específicas, se você souber os valores possíveis
  maxInstallmentCount: number;
  notificationEnabled: boolean;
  callback: CallbackPayload;
}
@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent {
  public containerPadding: string;
  private paddingSubscription: Subscription;

  isPaymentCardVisible: boolean = false;
  isCashPaymentCardVisible: boolean = false; // você pode modificar isso conforme a lógica da sua aplicação

  paymentForm: FormGroup;
  cashPaymentForm: FormGroup;

  saleIdPayment:any
  totalPayment:any

  constructor(
    private paddingService: PaddingService,
    private dataService: DataService,
    private asaasService: AsaasService,
    private saleServicePaymentService:SaleServicePaymentService,
    private router: Router,
    private routerActivate: ActivatedRoute,
    private productService: ProductService
  ) {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation.extras.state as {saleId: number, total: number};

    if (state) {
      this.saleIdPayment = state.saleId;
      this.totalPayment = state.total;
    }
   }

   buyId:any

  ngOnInit() {

    this.buyId = this.routerActivate.snapshot.paramMap.get('id');

    alert(this.buyId)
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;

    });

    this.paymentForm = new FormGroup({
      paymentName: new FormControl('PORTAL-PETZ-LINK-PAGAMENTO-'+this.saleIdPayment, Validators.required),
      paymentDescription: new FormControl('CÓDIGO DA VENDA-'+this.saleIdPayment, Validators.required),
      paymentMethod: new FormControl('', Validators.required),
      totalValue: new FormControl(this.totalPayment, Validators.required),
      expiryDate: new FormControl(null, Validators.required),
      idVenda: new FormControl(this.saleIdPayment, Validators.required),
    });

    this.cashPaymentForm = new FormGroup({
      dataPagamento: new FormControl(new Date().toISOString(), Validators.required),
      total: new FormControl(this.totalPayment, Validators.required), // atualizado
      status: new FormControl('pago', Validators.required),
      formaPagamento: new FormControl('dinheiro', Validators.required),
      iD_Usuario: new FormControl(1, Validators.required),
      idPedidoServicos: new FormControl(null),
      idVenda: new FormControl(this.saleIdPayment, Validators.required) // atualizado
    });

  }
  submitPaymentForm() {
    if (this.paymentForm.valid) {
      console.log(this.paymentForm.value);

      const paymentData: AsaasPaymentLinkPayload = {
        saleId: `${this.saleIdPayment}`,
        billingType: "UNDEFINED",
        chargeType: "DETACHED",
        name: this.paymentForm.value.paymentName,
        description: `${this.saleIdPayment}`,
        endDate: this.paymentForm.value.expiryDate,
        value: this.paymentForm.value.totalValue,
        dueDateLimitDays: 10,  // Você pode ajustar conforme necessário ou adicionar um campo ao formulário
        subscriptionCycle: 'WEEKLY',  // Atualize se necessário
        maxInstallmentCount: 1,  // Atualize se necessário
        notificationEnabled: true , // Atualize se necessário
        callback: {
          successUrl: "https://www.google.com",
          autoRedirect: true
      }

      };

      this.asaasService.createAsaasPaymentLink(paymentData).subscribe(response => {
        console.log('Resposta da API do Asaas:', response);
        if(response && response.url) {
          // Abre o link automaticamente em uma nova aba
          window.open(response.url, '_blank');

      this.productService.removeProductFromInventory(this.cashPaymentForm.value);

          Swal.fire({
            icon: 'success',
            title: 'Link de pagamento criado com sucesso!',
            html: `O link de pagamento foi aberto em uma nova aba. Se não abrir automaticamente, clique <a href="${response.url}" target="_blank">aqui</a>.`,
            confirmButtonText: 'Fechar'
          });
        } else {
          Swal.fire({
            icon: 'error',
            title: 'Falha ao criar o link de pagamento.',
            text: 'Por favor, tente novamente mais tarde.'
          });
        }
      }, error => {
        console.error('Error:', error);
        Swal.fire({
          icon: 'error',
          title: 'Erro na API',
          text: 'Ocorreu um erro ao tentar criar o link de pagamento. Por favor, tente novamente.'
        });
      });
    } else {
      Swal.fire({
        icon: 'error',
        title: 'Formulário inválido',
        text: 'Por favor, preencha todos os campos obrigatórios.'
      });
    }


  }
  submitCashPaymentForm() {
    if (this.cashPaymentForm.valid) {
      const paymentData = {
        ...this.cashPaymentForm.value,
        idVenda: this.saleIdPayment,
        total: this.totalPayment
      };

      console.log('Dados de pagamento:', paymentData);

      this.saleServicePaymentService.sendPayment(paymentData).subscribe(response => {
        console.log('Resposta:', response);

        // Confirmação usando Swal.fire
        Swal.fire({
          icon: 'success',
          title: 'Pagamento Confirmado!',
          html: `
            <p><strong>ID Venda Serviço Pagamento:</strong> ${response.idVendaServicoPagamento}</p>
            <p><strong>Data Pagamento:</strong> ${response.dataPagamento}</p>
            <p><strong>Forma Pagamento:</strong> ${response.formaPagamento}</p>
            <p><strong>ID Usuário:</strong> ${response.iD_Usuario}</p>
            <p><strong>ID Venda:</strong> ${response.idVenda}</p>
            <p><strong>Status:</strong> ${response.status}</p>
            <p><strong>Total:</strong> ${response.total}</p>
          `
        }).then(() => {
          this.router.navigate(['/admin/panel-pdv']);  // Redirecionamento após a confirmação no Swal
        });

      }, error => {
        console.error('Erro ao enviar pagamento:', error);
        Swal.fire({
          icon: 'error',
          title: 'Erro ao confirmar pagamento',
          text: 'Por favor, tente novamente mais tarde.'
        });
      });
    } else {
      console.error('Formulário inválido!');
      Swal.fire({
        icon: 'error',
        title: 'Formulário inválido',
        text: 'Por favor, preencha todos os campos obrigatórios.'
      });
    }
  }



  processCashPayment(): void {
    this.isCashPaymentCardVisible = true;
  }



  showPaymentCard(): void {
    this.isPaymentCardVisible = true;
  }

//----------------------------------TIME LINE
events = [
  {
    timestamp: new Date(2023, 10, 1),
    title: 'Evento 1',
    content: 'Descrição do Evento 1. Algum texto adicional aqui.'
  },
  {
    timestamp: new Date(2023, 10, 10),
    title: 'Evento 2',
    content: 'Descrição do Evento 2. Outro texto explicativo.'
  },
  {
    timestamp: new Date(2023, 10, 20),
    title: 'Evento 3',
    content: 'Descrição do Evento 3. Mais informações sobre o evento.'
  }
];

}

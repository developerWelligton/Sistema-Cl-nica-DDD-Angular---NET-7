import { ProductService } from './../../../../services/product.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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

interface PaymentDinheiro {
  saleId:string;
  value: number;
}
@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent {

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
    private productService: ProductService
  ) {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation.extras.state as {saleId: number, total: number};

    if (state) {
      this.saleIdPayment = state.saleId;
      this.totalPayment = state.total;
    }
   }

  ngOnInit() {


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
          }).then(() => {
            this.router.navigate(['/admin/panel-pdv']);  // Redirecionamento após a confirmação no Swal
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
    debugger
    if (this.cashPaymentForm.valid) {
      console.log(this.paymentForm.value);

      const paymentData: PaymentDinheiro = {
        saleId: `${this.saleIdPayment}`,
        value: this.paymentForm.value.totalValue,
      }



      this.saleServicePaymentService.sendPaymentDinheiro(paymentData).subscribe(response => {
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
          }).then(() => {
            this.router.navigate(['/admin/panel-pdv']);  // Redirecionamento após a confirmação no Swal
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

  };




  processCashPayment(): void {
    this.isCashPaymentCardVisible = true;
    this.isPaymentCardVisible = false;
  }



  showPaymentCard(): void {
    this.isPaymentCardVisible = true;
    this.isCashPaymentCardVisible = false;
  }
}

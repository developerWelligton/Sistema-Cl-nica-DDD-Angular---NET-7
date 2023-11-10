import { ProductService } from '../../../../services/product.service';
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
  selector: 'app-modal-stock',
  templateUrl: './modal-stock.component.html',
  styleUrls: ['./modal-stock.component.scss']
})
export class ModalStockComponent {
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
  ) {}

  buyId:any
  ngOnInit() {

    this.buyId = this.routerActivate.snapshot.paramMap.get('id');

    alert(this.buyId)
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;

    });


  }



//----------------------------------TIME LINE
events = [
  {
    timestamp: new Date(2023, 10, 1),
    title: 'Pedido da Compra Foi Realizado',
    content: 'O pedido foi recebido e está aguardando processamento.'
  },
  {
    timestamp: new Date(2023, 10, 10),
    title: 'Em Trânsito',
    content: 'O produto está em trânsito.'
  },
  {
    timestamp: new Date(2023, 10, 20),
    title: 'Confirme a Chegada',
    content: 'Confirme a chegada do produto.',
  },
];
atualizarEstoque() {
  // Lógica para atualizar o estoque
}


}

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


import { MatDialog } from '@angular/material/dialog';
import { ModalStockComponent } from '../modal-stock/modal-stock.component';


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
    private productService: ProductService,
    public dialog: MatDialog
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

openEstoqueModal() {
  const dialogRef = this.dialog.open(ModalStockComponent, {
    width: '250px',
    // Você pode passar dados para o modal se necessário
  });

  dialogRef.afterClosed().subscribe(result => {
    // Lógica a ser executada depois que o modal for fechado
  });
}

}

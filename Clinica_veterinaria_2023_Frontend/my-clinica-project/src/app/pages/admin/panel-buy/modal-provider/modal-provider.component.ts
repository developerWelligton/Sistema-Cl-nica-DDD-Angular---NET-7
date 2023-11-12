import { ProductService } from '../../../../services/product.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { PaddingService } from 'src/app/services/Padding.service';
import { AsaasService } from 'src/app/services/asaas.service';
import { DataService } from 'src/app/services/data.service';
import { ProviderService } from 'src/app/services/provider.service';
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
  selector: 'app-modal-provider',
  templateUrl: './modal-provider.component.html',
  styleUrls: ['./modal-provider.component.scss']
})
export class ModalProviderComponent {
  public containerPadding: string;
  private paddingSubscription: Subscription;

  isPaymentCardVisible: boolean = false;
  isCashPaymentCardVisible: boolean = false; // você pode modificar isso conforme a lógica da sua aplicação

  paymentForm: FormGroup;
  cashPaymentForm: FormGroup;

  saleIdPayment:any
  totalPayment:any
  providerControl: any;
  constructor(
    private providerService: ProviderService,
    public dialogRef: MatDialogRef<ModalProviderComponent>
  ) { this.loadProviders()}

  buyId:any
  ngOnInit() {

  }



  confirmar() {
    // Fecha o modal e passa o valor selecionado
    this.dialogRef.close({ confirmed: true, selectedProvider: this.providerControl });
  }

cancelar() {
  // Se o botão "Cancelar" for clicado, fechar o modal sem ação
  this.dialogRef.close();
}
providers: any;
loadProviders(): void {
  this.providerService.getAllProviders().subscribe((data: any[]) => {
    this.providers = data
      console.log(data)
  }, error => {
      console.error('Error loading FORNECEDORES :', error);
      // Handle error as needed
  })
}

}

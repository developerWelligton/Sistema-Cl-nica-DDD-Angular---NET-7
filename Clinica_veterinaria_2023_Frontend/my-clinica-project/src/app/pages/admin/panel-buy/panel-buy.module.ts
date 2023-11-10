import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminModule } from '../admin.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SidebarModule } from 'src/app/components/sidebar/sidebar.module';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { PaymentComponent } from './payment/payment.component';
import { PanelBuyComponent } from './panel-buy.component';
import { PanelBuyRoutingModule } from './panel-buy-routing.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxTimelineModule } from '@frxjs/ngx-timeline';
import { ModalStockComponent } from './modal-stock/modal-stock.component';
@NgModule({
  imports: [
    FormsModule,
    PanelBuyRoutingModule,
    CommonModule,
    NavbarModule,
    SidebarModule,
    SharedModule,
    ReactiveFormsModule,
    NgSelectModule,
    NgxTimelineModule

  ],
  declarations: [
    PanelBuyComponent,
    PaymentComponent
  ],
  exports:[PanelBuyRoutingModule ],
  providers: [
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class PanelBuyModule { }

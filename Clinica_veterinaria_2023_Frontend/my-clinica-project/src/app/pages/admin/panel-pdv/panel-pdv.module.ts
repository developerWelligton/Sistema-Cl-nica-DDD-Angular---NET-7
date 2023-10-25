import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelPdvComponent } from './panel-pdv.component';
import { AdminModule } from '../admin.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SidebarModule } from 'src/app/components/sidebar/sidebar.module';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { PanelPdvRoutingModule } from './panel-pdv-routing.module';
import { PaymentComponent } from './payment/payment.component';

@NgModule({
  imports: [
    FormsModule,
    PanelPdvRoutingModule,
    CommonModule,
    NavbarModule,
    SidebarModule,
    SharedModule,
    ReactiveFormsModule

  ],
  declarations: [
    PanelPdvComponent,
    PaymentComponent
  ],
  exports:[PanelPdvRoutingModule ],
  providers: [
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class PanelPdvModule { }

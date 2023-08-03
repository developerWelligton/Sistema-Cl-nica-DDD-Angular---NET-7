import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SidebarModule } from 'src/app/components/sidebar/sidebar.module';
import { VeterinarioRoutingModule } from './cliente-routing.module';
import { ClienteComponent } from './cliente.component';

@NgModule({
  declarations: [
    ClienteComponent
  ],
  imports: [
    CommonModule,
    VeterinarioRoutingModule,
    NavbarModule,
    SidebarModule
  ],
  providers: []
})
export class ClienteModule { }

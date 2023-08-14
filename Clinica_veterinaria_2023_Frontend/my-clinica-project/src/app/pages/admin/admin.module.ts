import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SidebarModule } from 'src/app/components/sidebar/sidebar.module';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { CreateUserComponent } from './create-user/create-user.component';

@NgModule({
  declarations: [
    AdminComponent,
    CreateUserComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NavbarModule,
    SidebarModule,

  ],
  providers: []
})
export class AdminModule { }

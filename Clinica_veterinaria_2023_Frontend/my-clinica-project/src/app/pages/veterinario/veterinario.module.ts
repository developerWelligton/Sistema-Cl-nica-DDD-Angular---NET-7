import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SidebarModule } from 'src/app/components/sidebar/sidebar.module';
import { VeterinarioRoutingModule } from './veterinario-routing.module';
import { VeterinarioComponent } from './veterinario.component';
import { TableConsultComponent } from './list-consult/table-consult/table-consult.component';
import { ListConsultComponent } from './list-consult/list-consult.component';

@NgModule({
  declarations: [
   VeterinarioComponent,
   TableConsultComponent,
   ListConsultComponent
  ],
  imports: [
    CommonModule,
    VeterinarioRoutingModule,
    NavbarModule,
    SidebarModule
  ],
  providers: []
})
export class VeterinarioModule { }

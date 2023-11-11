import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SidebarComponent } from './sidebar.component';

import {MatSidenavModule} from '@angular/material/sidenav';
import { MatRadioModule } from '@angular/material/radio';
@NgModule({
  declarations: [
    SidebarComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    FormsModule, // Adicione o FormsModule
    ReactiveFormsModule, // Adicione o ReactiveFormsModule
    MatSidenavModule,
    MatRadioModule
  ],
  exports: [SidebarComponent
  ]
})
export class SidebarModule { }

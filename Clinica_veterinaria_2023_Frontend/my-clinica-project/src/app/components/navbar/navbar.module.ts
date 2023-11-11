import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar.component';

import { MatToolbarModule } from '@angular/material/toolbar'; // Importe o módulo de barra de ferramentas do Angular Material
import { MatMenuModule } from '@angular/material/menu'; // Importe o módulo de menu do Angular Material
import { MatIconModule } from '@angular/material/icon'; // Importe o módulo de ícones do Angular Material

@NgModule({
  declarations: [
    NavbarComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatToolbarModule, // Importe o módulo de barra de ferramentas do Angular Material
    MatMenuModule, // Importe o módulo de menu do Angular Material
    MatIconModule
  ],
  exports: [NavbarComponent]
})
export class NavbarModule { }

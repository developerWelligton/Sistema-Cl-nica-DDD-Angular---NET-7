import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalUnspscComponent } from './modal-unspsc.component';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    ModalUnspscComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule
  ],
  exports: [ModalUnspscComponent
  ]
})
export class modalUnspscModule { }

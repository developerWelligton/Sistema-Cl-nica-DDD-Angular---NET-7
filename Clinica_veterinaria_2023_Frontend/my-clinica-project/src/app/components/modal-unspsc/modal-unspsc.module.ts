import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalUnspscComponent } from './modal-unspsc.component';

@NgModule({
  declarations: [
    ModalUnspscComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [ModalUnspscComponent
  ]
})
export class modalUnspscModule { }

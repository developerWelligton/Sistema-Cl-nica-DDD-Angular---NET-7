import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoaderInterceptor, HTTPStatus } from '../interceptors/loader.interceptor';
import { CreateConsultComponent } from './create-consult/create-consult.component';
import { AuthGuard } from '../pages/guard/auth.guard';

@NgModule({
  declarations: [
    CreateConsultComponent
    // Outros componentes compartilhados vão aqui.
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgxSpinnerModule
  ],
  exports: [
    CreateConsultComponent,
    // Outros componentes compartilhados que você deseja exportar vão aqui.
  ],
  providers: [],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class SharedModule { }

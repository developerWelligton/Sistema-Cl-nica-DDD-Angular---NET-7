import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SidebarModule } from 'src/app/components/sidebar/sidebar.module';
import { SecretariaRoutingModule } from './secretaria-routing.module';
import { SecretariaComponent } from './secretaria.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthGuard } from '../guard/auth.guard';
import { LoaderInterceptor } from 'src/app/interceptors/loader.interceptor';
import { NotfoundConsultComponent } from './notfound-consult/notfound-consult.component';

@NgModule({
  declarations: [
    SecretariaComponent,
    NotfoundConsultComponent
  ],
  imports: [
    CommonModule,
    SecretariaRoutingModule,
    NavbarModule,
    SidebarModule,
    SharedModule
  ],
  providers: [
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class SecretariaModule { }

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
import { CreateConsultComponent } from './create-consult/create-consult.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { SearchConsultComponent } from './search-consult/search-consult.component';
import { AdminModule } from '../admin/admin.module';

@NgModule({
  declarations: [
    SecretariaComponent,
    NotfoundConsultComponent,
    CreateConsultComponent,
    SearchConsultComponent,
  ],
  imports: [
    CommonModule,
    SecretariaRoutingModule,
    NavbarModule,
    SidebarModule,
    SharedModule,
    NgSelectModule,
    ReactiveFormsModule,
    AdminModule

  ],
  providers: [
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class SecretariaModule { }

import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { CommonModule, HashLocationStrategy,LocationStrategy } from '@angular/common';



import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AuthGuard } from './pages/guard/auth.guard';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

/**/
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { jqxGridModule } from 'jqwidgets-ng/jqxgrid';
import { NavbarModule } from './components/navbar/navbar.module';
import { SidebarModule } from './components/sidebar/sidebar.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatRadioModule } from '@angular/material/radio';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,

    CommonModule,
    HttpClientModule,

    ReactiveFormsModule,
    FormsModule,

    NgxSpinnerModule,
    MatProgressSpinnerModule,
    jqxGridModule,
    NavbarModule,

    MatToolbarModule, // Importe o módulo de barra de ferramentas do Angular Material
    MatMenuModule, // Importe o módulo de menu do Angular Material
    MatIconModule,
    MatSidenavModule,
    MatRadioModule

  ],
  providers: [
    AuthGuard
  ],
  bootstrap: [AppComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }

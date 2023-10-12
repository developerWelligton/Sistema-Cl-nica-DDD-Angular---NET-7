import { NgModule,CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SidebarModule } from 'src/app/components/sidebar/sidebar.module';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { CreateUserComponent } from './create-user/create-user.component';

// Angular Material Imports
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { ListUserComponent } from './list-user/list-user.component';
import { MatTableModule } from '@angular/material/table';
import { UserTableComponent } from './list-user/user-table/user-table.component';
import { CreateProductComponent } from './create-product/create-product.component';
import { ListProductComponent } from './list-user copy/list-product.component';
import { CreateUnspscComponent } from './create-unspsc/create-unspsc.component';
import { ListUnspscComponent } from './list-user copy 2/list-unspsc.component';

@NgModule({
  declarations: [
    AdminComponent,
    CreateUserComponent,
    ListUserComponent,
    UserTableComponent,
    CreateProductComponent,
    ListProductComponent,
    CreateUnspscComponent,
    ListUnspscComponent

  ],
  exports:[CreateUserComponent],
  imports: [

    CommonModule,
    AdminRoutingModule,
    NavbarModule,
    SidebarModule,
    ReactiveFormsModule,
    FormsModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,



  ],
  providers: []
  ,
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AdminModule { }

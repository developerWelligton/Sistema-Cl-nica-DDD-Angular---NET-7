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
import { NgSelectModule } from '@ng-select/ng-select';
import { UnspscTableComponent } from './list-user copy 2/unspsc-table/unspsc-table.component';
import { UserProductComponent } from './list-user copy/product-table/product-table.component';
import { ProductComponent } from './product/product.component';
import { VmessageModule } from 'src/app/shared/components/vmessage/vmessage.module';

@NgModule({
  declarations: [
    AdminComponent,
    CreateUserComponent,
    ListUserComponent,
    UserTableComponent,
    CreateProductComponent,
    ListProductComponent,
    CreateUnspscComponent,
    ListUnspscComponent,
    UnspscTableComponent,
    UserProductComponent,
    ProductComponent,


  ],
  exports:[CreateUserComponent,UserProductComponent],
  imports: [
    NgSelectModule,
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
    VmessageModule
  ],
  providers: []
  ,
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AdminModule { }

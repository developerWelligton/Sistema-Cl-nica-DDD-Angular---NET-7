import { NgModule,CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SidebarModule } from 'src/app/components/sidebar/sidebar.module';

// Angular Material Imports
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { NgSelectModule } from '@ng-select/ng-select';
import { VmessageModule } from 'src/app/shared/components/vmessage/vmessage.module';
import { jqxTreeModule } from 'jqwidgets-ng/jqxtree';
import { jqxExpanderModule } from 'jqwidgets-ng/jqxexpander';
import { CreateEstoqueComponent } from '../create-estoque/create-estoque.component';
import { ListStockComponent } from './list-stock.component';
import { StockListTableComponent } from './stock-list-table/stock-table.component';
import { StockRoutingModule } from './stock-routing.module';
import { CreateUserComponent } from '../create-user/create-user.component';
import { StockProductsTableComponent } from './stock-list-table copy/stock-products-table.component';

@NgModule({
  declarations: [
    CreateEstoqueComponent,
    ListStockComponent,
    StockListTableComponent,
    StockProductsTableComponent

  ],
  exports:[ StockRoutingModule ],
  imports: [
    NgSelectModule,
    CommonModule,
    StockRoutingModule,
    NavbarModule,
    SidebarModule,
    ReactiveFormsModule,
    FormsModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    VmessageModule,
    jqxTreeModule, jqxExpanderModule,
    MatTableModule,
    MatButtonModule
  ],
  providers: []
  ,
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class StockModule { }

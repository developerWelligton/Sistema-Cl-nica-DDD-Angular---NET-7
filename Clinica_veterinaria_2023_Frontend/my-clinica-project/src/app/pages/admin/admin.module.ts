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
import { CreateUnspscComponent } from './create-unspsc/create-unspsc.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { VmessageModule } from 'src/app/shared/components/vmessage/vmessage.module';
import { PanelPdvComponent } from './panel-pdv/panel-pdv.component';
import { ListUnspscComponent } from './unspsc-table/list-unspsc.component';
import { ListProductComponent } from './product-table/list-product.component';
import { UnspscTableComponent } from './unspsc-table/unspsc-table/unspsc-table.component';
import { UserProductComponent } from './product-table/product-table/product-table.component';
import { ProductComponent } from './product-table/product.component';
import { ListSaleComponent } from './sale-table/sale-list.component';
import { SaleTableComponent } from './sale-table/sale-table/sale-table.component';
import { DetailProductComponent } from './detail-product/detail-product.component';
import { jqxTreeModule } from 'jqwidgets-ng/jqxtree';
import { jqxExpanderModule } from 'jqwidgets-ng/jqxexpander';
import { TreeViewUnspscComponent } from './tree-view-unspsc/tree-view-unspsc.component';
import { CreateEstoqueComponent } from './create-estoque/create-estoque.component';
import { ListStockComponent } from './stock-table/list-stock.component';
import { StockModule } from './stock-table/stock.module';
import { modalUnspscModule } from 'src/app/components/modal-unspsc/modal-unspsc.module';
import { CreateProviderComponent } from './create-provider/create-provider.component';
import { ListProviderComponent } from './unspsc-table copy/list-provider.component';
import { ProviderTableComponent } from './unspsc-table copy/provider-table/provider-table.component';
import { CreateBuyComponent } from './create-buy/create-buy.component';
import { PanelBuyComponent } from './panel-buy/panel-buy.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ModalStockComponent } from './panel-buy/modal-stock/modal-stock.component';
import {MatCardModule} from '@angular/material/card';
import { ModalProviderComponent } from './panel-buy/modal-provider/modal-provider.component';
import { MatIconModule } from '@angular/material/icon';
import {MatStepperModule} from '@angular/material/stepper';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
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
    ListSaleComponent,
    SaleTableComponent,
    DetailProductComponent,
    TreeViewUnspscComponent,
    CreateProviderComponent,
    ListProviderComponent,
    ProviderTableComponent,
    CreateBuyComponent,
    ModalStockComponent,
    ModalProviderComponent
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
    VmessageModule,
    jqxTreeModule, jqxExpanderModule,
    modalUnspscModule,
    MatDialogModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatStepperModule,
    MatPaginatorModule,

  ],
  providers: []
  ,
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AdminModule { }

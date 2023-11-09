
import { TreeViewUnspscComponent } from './tree-view-unspsc/tree-view-unspsc.component';
import { DetailProductComponent } from './detail-product/detail-product.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { CreateProductComponent } from './create-product/create-product.component';
import { CreateUnspscComponent } from './create-unspsc/create-unspsc.component';
import { ListProductComponent } from './product-table/list-product.component';
import { ListUnspscComponent } from './unspsc-table/list-unspsc.component';
import { ListSaleComponent } from './sale-table/sale-list.component';
import { CreateProviderComponent } from './create-provider/create-provider.component';

const routes: Routes = [
  {
    path:'',
    component:AdminComponent
  },
  {
    path:'create-user',
    component:CreateUserComponent
  },
  {
    path:'list-user',
    component:ListUserComponent
  },

  {
    path:'treeview-unspsc',
    component:TreeViewUnspscComponent
  },
  {
    path:'create-product',
    component:CreateProductComponent
  },
  {
    path:'list-product',
    component:ListProductComponent
  },
  {
    path:'detail-product/:id',
    component:DetailProductComponent
  },
  {
    path:'create-unspsc',
    component:CreateUnspscComponent
  },
  {
    path:'list-unspsc',
    component:ListUnspscComponent
  },
  {
    path: 'panel-pdv',
    loadChildren: () => import('./panel-pdv/panel-pdv.module').then(m => m.PanelPdvModule)
  },
  {
    path: 'salesMade',
    component:ListSaleComponent
  },
  {
    path: 'list-stock',
    loadChildren: () => import('./stock-table/stock.module').then(m => m.StockModule)
  },
  {
    path:'create-provider',
    component:CreateProviderComponent
  },
   // Rota coringa - Redireciona para NotfoundConsultComponent quando a rota não é encontrada
   {
    path: '**',
    redirectTo: 'notfound'
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

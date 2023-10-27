import { DetailProductComponent } from './detail-product/detail-product.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { CreateProductComponent } from './create-product/create-product.component';
import { CreateUnspscComponent } from './create-unspsc/create-unspsc.component';
import { PanelPdvComponent } from './panel-pdv/panel-pdv.component';
import { ListProductComponent } from './product-table/list-product.component';
import { ListUnspscComponent } from './unspsc-table/list-unspsc.component';
import { ListSaleComponent } from './sale-table/sale-list.component';

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
  },{
    path: 'salesMade',
    component:ListSaleComponent
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

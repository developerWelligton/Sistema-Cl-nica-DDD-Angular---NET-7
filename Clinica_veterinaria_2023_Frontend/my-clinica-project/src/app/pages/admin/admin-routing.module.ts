import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { CreateProductComponent } from './create-product/create-product.component';
import { ListProductComponent } from './list-user copy/list-product.component';
import { CreateUnspscComponent } from './create-unspsc/create-unspsc.component';
import { ListUnspscComponent } from './list-user copy 2/list-unspsc.component';

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
    path:'create-unspsc',
    component:CreateUnspscComponent
  },
  {
    path:'list-unspsc',
    component:ListUnspscComponent
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

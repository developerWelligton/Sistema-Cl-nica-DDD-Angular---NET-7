import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { CreateProductComponent } from './create-product/create-product.component';

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

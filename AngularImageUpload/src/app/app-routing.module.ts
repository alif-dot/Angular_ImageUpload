import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './components/product/product.component';
import { DisplayProductsComponent } from './components/display-products/display-products.component';

const routes: Routes = [{
  path:'add-product',
  component:ProductComponent
},
{
  path:'',
  redirectTo:'/add-product',
  pathMatch:'full'
},
{
  path:'display-products', component:DisplayProductsComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

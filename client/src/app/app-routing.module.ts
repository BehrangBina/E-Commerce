import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  {path: ''         , component: HomeComponent},
  // Lazy Loading only loaded when shop component is accessed
  {path: 'shop' , loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule)},
  {path: '**'       , redirectTo: '', pathMatch: 'full'} // redirect to home if any incorrect
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

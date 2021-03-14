import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  {path: ''         , component: HomeComponent, data:{breadcrumb: 'Home'}},
  {path: 'server-error', component: ServerErrorComponent, data:{breadcrumb: 'Server Errors'}},
  {path: 'not-found', component: NotFoundComponent, data:{breadcrumb: 'Not Found'}},
  // Lazy Loading only loaded when shop component is accessed
  {path: 'shop' , loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule)},
  {path: '**'       , redirectTo: 'not-found', pathMatch: 'full'} // redirect to home if any incorrect
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

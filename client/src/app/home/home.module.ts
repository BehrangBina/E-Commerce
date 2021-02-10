import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopModule } from '../shop/shop.module';
import { HomeComponent } from './home.component';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule
  ],
  exports: [HomeComponent]
})
export class HomeModule { }

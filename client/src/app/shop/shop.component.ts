import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { IBrand } from '../models/brand';
import { IProduct } from '../models/product';
import { IType } from '../models/productTypes';
import { ShopService } from './shop.service';
/*
  Consuming service
  list of components, sort , search ,...
*/
@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products: IProduct[] = [];
  types: IType[] = [];
  brands: IBrand[] = [];
  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getBrands();
    this.getProducts();
    this.getTypes();
  }
  getProducts(){
    this.shopService.getProducts().subscribe(
      (res) => {
        this.products = res.data1;
      },
      (err) => {
        console.log(err);
      }
    );
  }
  getBrands(){
    this.shopService.getBrands().subscribe(
      (res) => {
        this.brands = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
  getTypes(){
    this.shopService.getTypes().subscribe(
      (res) => {
        this.types = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}

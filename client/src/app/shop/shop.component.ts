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
  types: IType[] = [];
  brands: IBrand[] = [];
  brandIdSelected!: number;
  typeIdSelected!: number;
  products: IProduct[] | undefined;

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getBrands();
    this.getProducts();
    this.getTypes();
  }
  getProducts(): void {
    this.shopService
      .getProducts(this.brandIdSelected, this.typeIdSelected)
      .subscribe(
        (res) => {
          this.products = res?.data1;
        },
        (err) => {
          console.log(err);
        }
      );
  }
  getBrands(): void {
    this.shopService.getBrands().subscribe(
      (res) => {
        // this.brands = res;
        // ... Spread operator: spread all of the objects from that array and is simply adding
        this.brands = [{ id: 0, name: 'All' }, ...res];
      },
      (err) => {
        console.log(err);
      }
    );
  }
  getTypes(): void {
    this.shopService.getTypes().subscribe(
      (res) => {
       // this.types = res;
       this.types = [{ id: 0, name: 'All' }, ...res];
      },
      (err) => {
        console.log(err);
      }
    );
  }
  onBrandSelected(brandId: number): void {
    this.brandIdSelected = brandId;
    this.getProducts();
  }
  onTypeSelected(typeId: number): void {
    this.typeIdSelected = typeId;
    this.getProducts();
  }
}

import { Component, OnInit } from '@angular/core';
import { IBrand } from '../models/brand';
import { IProduct } from '../models/product';
import { IType } from '../models/productTypes';
import { ShopParams } from '../models/shopParams';
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
  products: IProduct[] | undefined;
  shopParams = new ShopParams();
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];
  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getBrands();
    this.getProducts();
    this.getTypes();
  }
  getProducts(): void {
    this.shopService
      .getProducts(this.shopParams)
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
    this.shopParams.brandId = brandId;
    this.getProducts();
  }
  onTypeSelected(typeId: number): void {
    this.shopParams.typeId= typeId;
    this.getProducts();
  }
  onSortSelected(sort: string): void{
    this.shopParams.sort = sort;
    this.getProducts();
  }
}

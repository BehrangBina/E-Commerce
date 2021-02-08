import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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
  // dnamic for hide able
  @ViewChild('search', {static: false}) searchTerm!: ElementRef;
  types: IType[] = [];
  brands: IBrand[] = [];
  products: IProduct[] | undefined;
  shopParams = new ShopParams();
  totalCount!: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];
  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getBrands();
    this.getProducts();
    this.getTypes();
  }
  getProducts(): void {
    this.shopService.getProducts(this.shopParams).subscribe(
      (res) => {
        this.products = res?.data1;
        if (res != null) {
          this.shopParams.pageNumber = res.pageIndex;
          this.shopParams.pageSize = res.pageSize;
          this.totalCount =  res.totalItems;

        }
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
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onTypeSelected(typeId: number): void {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onSortSelected(sort: string): void {
    this.shopParams.sort = sort;
    this.getProducts();
  }
  onPageChanged(event: any): void{
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }

  }
  onSearch(): void{
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onReset(): void{
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}

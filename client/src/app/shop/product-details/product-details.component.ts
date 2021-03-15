import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, provideRoutes } from '@angular/router';
import { IProduct } from 'src/app/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  product!: IProduct;

  constructor(
    private shopService: ShopService,
    private activateRoute: ActivatedRoute,
    private bcService: BreadcrumbService
  ) {}

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct(): void {
    let productId = this.activateRoute.snapshot.paramMap.get('id');
    if (productId == null) {
      productId = '0';
    }
    this.shopService.getProduct(parseInt(productId, 10)).subscribe(
      (product) => {
        this.product = product;
        this.bcService.set('@productDetails', this.product.name);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}

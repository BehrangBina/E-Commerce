import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/models/product';
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
    private activateRoute: ActivatedRoute
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
      (product) => (this.product = product),
      (error) => {
        console.log(error);
      }
    );
  }
}

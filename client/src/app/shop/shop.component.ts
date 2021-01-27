import { Component, OnInit } from '@angular/core';
import { IProduct } from '../models/product';
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
  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.shopService.getProducts().subscribe(
      (res) => {
        this.products = res.data1;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}

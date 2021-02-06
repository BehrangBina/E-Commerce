import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../models/pagination';
import { IBrand } from '../models/brand';
import { IType } from '../models/productTypes';
import { delay, map } from 'rxjs/operators';
import { ShopParams } from '../models/shopParams';
@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) {}
  // ? for optional
  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId) {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    if (shopParams.sort) {
      params = params.append('sort', shopParams.sort);
    }
    // pipe is a wrapper around any rxjs method operators that we want to use
    // chain operators as we want inside request

    return this.http
      .get<IPagination>(this.baseUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(
        // delay(1000),
        map((response) => {
          return response.body;
        })
      );
  }
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}

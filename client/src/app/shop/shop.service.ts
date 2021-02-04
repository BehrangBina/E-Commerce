import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../models/pagination';
import { IBrand } from '../models/brand';
import { IType } from '../models/productTypes';
import {delay, map} from 'rxjs/operators';
@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) {}
  // ? for optional
  getProducts(brnadId?: number, typeId?: number) {
    let params = new HttpParams();

    if (brnadId) {
      params.append('brandId', brnadId.toString());
    }
    if (typeId) {
      params.append('typeId', typeId.toString());
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

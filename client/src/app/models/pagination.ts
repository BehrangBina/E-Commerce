import { IProduct } from './product';

export interface IPagination {
  totalItems: number;
  pageIndex: number ;
  pageSize: number ;
  count: number;
  data1: IProduct[];
}

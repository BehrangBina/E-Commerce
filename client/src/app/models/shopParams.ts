export class ShopParams {
  brandId = 0;
  typeId = 0;
  sort = 'name';
  pageNumber = 1;
  pageSize = 6;

  getPageFrom(): number {
    return (this.pageNumber - 1) * this.pageSize + 1;
  }
  getPageTo(totalPages: number): number{
    return (this.pageNumber * this.pageSize)
      > totalPages
      ? totalPages
      : this.pageNumber * this.pageSize;
  }
}

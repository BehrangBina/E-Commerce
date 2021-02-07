import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss']
})
export class PagingHeaderComponent implements OnInit {
  @Input() totalCount!: number;
  @Input() pageFrom!: number;
  @Input() pageTo!: number;
  constructor() { }

  ngOnInit(): void {
  }

}

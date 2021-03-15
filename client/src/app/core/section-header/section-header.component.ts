import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BreadcrumbComponent, BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.scss']
})
export class SectionHeaderComponent implements OnInit {

  constructor(private bcService: BreadcrumbService) { }
  breadCrumb$!: Observable<any[]>;
  ngOnInit(): void {
    this.breadCrumb$= this.bcService.breadcrumbs$;
  }

}

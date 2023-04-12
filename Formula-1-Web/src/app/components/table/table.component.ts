import { Component, OnInit } from '@angular/core';
import { Observable, combineLatest, map, of } from 'rxjs';
import { ApiResult } from 'src/app/models/api.result';
import { Entity } from 'src/app/models/entities/entity';
import { ApiService } from 'src/app/services/api/api.service';
import 'datatables.net-bs4'
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  public response$: Observable<ApiResult<Entity>> = of();
  public entity$: Observable<string> = of();
  public columns$: Observable<Array<{ title: string, data: string }>> = of();
  public entityList$: Observable<Array<Entity>> = of();
  public table: any;

  private readonly tableElementId: string = '#dataTable';

  constructor(private readonly apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    const collectionKey = this.router.url.replace('/', '');

    this.response$ = this.apiService.GetEntities(collectionKey);
    this.entity$ = this.response$.pipe(map(response => response.meta.type));
    this.columns$ = this.response$.pipe(map(response => Object.keys(response.payload.data[0]).map(columnName => ({ title: columnName, data: columnName }))));
    this.entityList$ = this.response$.pipe(map(response => response.payload.data));

    combineLatest([this.columns$, this.entityList$]).subscribe(([columns, data]) => {
      this.table = $(this.tableElementId).DataTable({ columns, data, retrieve: true });
    });
  }
}

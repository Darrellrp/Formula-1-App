import { Component, OnInit } from '@angular/core';
import { Observable, combineLatest, map, of } from 'rxjs';
import { ApiResult } from 'src/app/models/api.result';
import { Entity } from 'src/app/models/entities/entity';
import { ApiService } from 'src/app/services/api/api.service';
import 'datatables.net-bs4'
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import * as EntitiesActions from 'src/app/store/entities/entities.actions';
import { selectEntityListFromDict } from 'src/app/store/entities/entities.selectors';

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

  private static readonly tableElementId: string = '#dataTable';
  private static readonly defaultCollection: string = 'circuits';

  constructor(
    private readonly apiService: ApiService,
    private readonly router: Router,
    private readonly store: Store) { }

  ngOnInit(): void {
    const uri = this.router.url.replace('/', '');
    const collectionKey = uri == '' ? TableComponent.defaultCollection : uri;

    this.store.dispatch(EntitiesActions.load({ collectionKey }));
    // this.store.select(selectEntitiesList(collectionKey));
    // const sss = selectEntityListFromDict(collectionKey);
    // this.store.select(sss);

    this.response$ = this.apiService.GetEntities(collectionKey);
    this.entity$ = this.response$.pipe(map(response => response.meta.label));
    this.columns$ = this.response$.pipe(map(response => Object.keys(response.payload.data[0]).map(columnName => ({ title: columnName, data: columnName }))));
    this.entityList$ = this.response$.pipe(map(response => response.payload.data));

    combineLatest([this.columns$, this.entityList$]).subscribe(([columns, data]) => {
      this.table = $(TableComponent.tableElementId).DataTable({ columns, data, retrieve: true });
    });
  }
}

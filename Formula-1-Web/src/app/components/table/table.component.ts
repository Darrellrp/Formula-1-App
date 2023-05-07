import { Component, OnInit } from '@angular/core';
import { Observable, combineLatest, distinct, filter, map, of, tap } from 'rxjs';
import { Entity } from 'src/app/models/entities/entity';
import { ApiService } from 'src/app/services/api/api.service';
import 'datatables.net-bs4'
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import * as EntitiesActions from 'src/app/store/entities/entities.actions';
import * as EntitiesSelectors from 'src/app/store/entities/entities.selectors';
import { Dictionary } from '@ngrx/entity';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  public response$: Observable<Dictionary<Entity> | undefined> = of();
  public entity$: Observable<string | undefined> = of();
  public columns$: Observable<Array<{ title: string, data: string }> | undefined> = of();
  public entityList$: Observable<Array<Entity | undefined> | undefined> = of();
  public table: any;

  private static readonly tableElementId: string = '#dataTable';
  private static readonly defaultCollection: string = 'circuits';

  constructor(
    private readonly router: Router,
    private readonly store: Store) { }

  ngOnInit(): void {
    const uri = this.router.url.replace('/', '');
    const collectionKey = uri == '' ? TableComponent.defaultCollection : uri;

    this.store.dispatch(EntitiesActions.load({ collectionKey }));

    this.response$ = this.store.select(EntitiesSelectors.selectEntities(collectionKey)).pipe(distinct())
      .pipe(tap(entities => console.log(collectionKey, entities)));
    this.entity$ = this.store.select(EntitiesSelectors.selectCollectionLabel(collectionKey));
    this.columns$ = this.response$.pipe(
      filter((entities): entities is Dictionary<Entity> => !!entities),
      map((entities) => this.getColumns(entities))
    );

    this.entityList$ = this.response$.pipe(
      filter((entities): entities is Dictionary<Entity> => !!entities),
      map(entities => Object.values(entities)),
    );

    combineLatest([this.columns$, this.entityList$]).subscribe(([columns, data]) => {
      this.table = $(TableComponent.tableElementId).DataTable({ columns, data, retrieve: true });
    });
  }

  private getColumns(entities: Dictionary<Entity>): { title: string, data: string }[] | undefined {
    const entity = entities[Object.keys(entities)[0]];

    if (entity == undefined) { return undefined; }

    return Object.keys(entity).map(columnName => ({ title: columnName, data: columnName }))
  }
}

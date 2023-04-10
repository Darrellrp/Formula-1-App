import { Component, OnInit } from '@angular/core';
import { Observable, combineLatest, map, of } from 'rxjs';
import { ApiResult } from 'src/app/models/api.result';
import { Entity } from 'src/app/models/entities/entity';
import { ApiService } from 'src/app/services/api.service';
import 'datatables.net-bs4'
import { ApiEndpoints } from 'src/app/services/api.endpoints';
import Circuit from 'src/app/models/entities/circuit';
import ConstructorResults from 'src/app/models/entities/constructor-results';

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

  constructor(private readonly apiService: ApiService) { }

  ngOnInit(): void {
    this.response$ = this.apiService.GetCircuits();
    this.entity$ = this.response$.pipe(map(response => response.meta.type));
    this.columns$ = this.response$.pipe(map(response => Object.keys(response.payload.data[0]).map(x => ({ title: x, data: x }))));
    this.entityList$ = this.response$.pipe(map(response => response.payload.data));

    combineLatest([this.columns$, this.entityList$]).subscribe(([columns, data]) => {
      this.table = $('#dataTable').DataTable({ columns, data, retrieve: true });
    });
  }
}

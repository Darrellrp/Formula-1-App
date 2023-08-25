import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, map, of } from 'rxjs';
import { Endpoint } from 'src/app/models/endpoint';
import { loadEndpoints } from 'src/app/store/endpoints/endpoints.actions';
import { selectEndpoints } from 'src/app/store/endpoints/endpoints.selectors';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  public endpoints$: Observable<Array<Endpoint | undefined>> = of();

  constructor(private readonly store: Store) { }

  ngOnInit(): void {
    this.store.dispatch(loadEndpoints());

    this.endpoints$ = this.store.select(selectEndpoints).pipe(
      map(entities => Object.values(entities)),
    );
  }

}

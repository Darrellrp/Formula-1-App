import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ApiService } from 'src/app/services/api/api.service';
import { ApiEndpointsActions } from './endpoints.actions';
import { EMPTY, catchError, exhaustMap, filter, map, switchMap, tap } from 'rxjs';
import { selectEndpoints } from './endpoints.selectors';

@Injectable()
export class EndpointsEffects {
  public constructor(
    private store: Store,
    private actions$: Actions,
    private apiService: ApiService
  ) { }

  loadedEndpoints$ = createEffect(() => this.actions$.pipe(
    ofType(ApiEndpointsActions.LoadEndpoints),
    switchMap(() =>
      this.store.select(selectEndpoints).pipe(
        filter(endpoints => Object.keys(endpoints).length == 0),
        exhaustMap(() => this.apiService.GetEndpoints()
          .pipe(
            map((endpoints) => ({
              type: ApiEndpointsActions.LoadedEndpoints,
              endpoints: endpoints
            })),
            catchError(() => EMPTY)
          )
        ))
    )
  ));
}

import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY, of } from 'rxjs';
import { map, exhaustMap, catchError, withLatestFrom, filter, tap, switchMap } from 'rxjs/operators';
import { ApiService } from 'src/app/services/api/api.service';
import { EntityApiActions } from './entities.actions';
import { Store } from '@ngrx/store';
import * as EntitiesSelectors from 'src/app/store/entities/entities.selectors';

@Injectable()
export class EntitiesEffects {

  constructor(
    private store: Store,
    private actions$: Actions,
    private apiService: ApiService
  ) { }

  loadEntities$ = createEffect(() => this.actions$.pipe(
    ofType(EntityApiActions.LoadEntities),
    switchMap((action: { collectionKey: string }) =>
      this.store.select(EntitiesSelectors.selectEntities(action.collectionKey)).pipe(
        filter(entities => !entities),
        exhaustMap(() => this.apiService.GetEntities(action.collectionKey)
          .pipe(
            map(apiResult => ({
              type: EntityApiActions.LoadedEntities,
              apiResult: apiResult
            })),
            catchError(() => EMPTY)
          )
        )
      )
    )
  ));
}

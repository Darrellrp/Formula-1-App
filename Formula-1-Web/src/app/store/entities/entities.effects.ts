import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY } from 'rxjs';
import { map, exhaustMap, catchError } from 'rxjs/operators';
import { ApiService } from 'src/app/services/api/api.service';
import { EntityApiActions } from './entities.actions';

@Injectable()
export class EntitiesEffects {

  constructor(
    private actions$: Actions,
    private apiService: ApiService
  ) {}

  loadEntities$ = createEffect(() => this.actions$.pipe(
    ofType(EntityApiActions.LoadEntities),
    exhaustMap((action: { collectionKey: string; }) => this.apiService.GetEntities(action.collectionKey)
      .pipe(
        map(apiResult => ({ type: EntityApiActions.LoadedEntities, collectionKey: apiResult.meta.key, entityCollection: apiResult.payload.data })),
        catchError(() => EMPTY)
      ))
    )
  );
}

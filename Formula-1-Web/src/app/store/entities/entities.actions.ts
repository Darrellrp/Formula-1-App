import { createAction, props } from '@ngrx/store';
import { ApiResult } from 'src/app/models/api.result';
import { Entity } from 'src/app/models/entities/entity';

export enum EntityApiActions {
  LoadEntities = '[Entities API] Load new entities in collection',
  LoadedEntities = '[Entities API] Collection Loaded Success',
  ResetEntities = '[Entities API] Reset collection'
}

export const loadEntities = createAction(EntityApiActions.LoadEntities, props<{ collectionKey: string }>());
export const loadedEntities = createAction(EntityApiActions.LoadedEntities, props<{ apiResult: ApiResult<Entity> }>());
export const resetEntities = createAction(EntityApiActions.ResetEntities);

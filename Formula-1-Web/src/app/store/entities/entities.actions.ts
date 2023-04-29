import { Action, createAction, props } from '@ngrx/store';
import { ApiResult } from 'src/app/models/api.result';
import { Entity } from 'src/app/models/entities/entity';

export enum EntityApiActions {
  LoadEntities = '[Entities API] Load new entities in collection',
  LoadedEntities = '[Entities API] Collection Loaded Success',
  ResetEntities = '[Entities API] Reset collection'
}

// export class LoadEntities implements Action {
//   readonly type = EntityApiActions.LoadEntities;

//   constructor(public collectionKey: string) {}
// }

// export class LoadedEntities implements Action {
//   readonly type = EntityApiActions.LoadedEntities;

//   constructor(public apiResult: ApiResult<Entity>) {}
// }

// export class ResetEntities implements Action {
//   readonly type = EntityApiActions.ResetEntities;

//   constructor(public apiResult: ApiResult<Entity>) {}
// }

export const load = createAction(EntityApiActions.LoadEntities, props<{ collectionKey: string }>());
export const loaded = createAction(EntityApiActions.LoadedEntities, props<{ collectionKey: string; entityCollection: Array<Entity> }>());
export const reset = createAction(EntityApiActions.ResetEntities);

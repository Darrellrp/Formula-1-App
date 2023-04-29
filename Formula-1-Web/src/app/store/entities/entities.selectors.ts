import { createSelector } from '@ngrx/store';
import { EntityCollectionsState, collectionsAdapter } from './entity-collections.state';
import { selectEntitiesState } from '../app.selectors';
import { Dictionary } from '@ngrx/entity';
import { ApiResult } from 'src/app/models/api.result';
import { Entity } from 'src/app/models/entities/entity';
import { CollectionState } from './entity-collection.state';

export const selectEntitiesList = (collectionKey: string) =>
  createSelector(
    selectEntitiesState,
    (state: EntityCollectionsState) => state.entities[collectionKey]
  );

const {
  selectAll,
  selectEntities,
  selectIds,
  selectTotal

} = collectionsAdapter.getSelectors();

export const selectEntityListFromDict = (collectionKey: string) =>
  createSelector(
    selectEntities,
    // (state: Dictionary<Collection<Entity>>) => state[collectionKey]?.items
    (state: Dictionary<CollectionState<Entity>>) => state[collectionKey]?.entities
  );

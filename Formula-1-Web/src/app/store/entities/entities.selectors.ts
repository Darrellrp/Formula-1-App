import { createSelector } from '@ngrx/store';
import { collectionsAdapter } from './entity-collections.state';
import { selectCollectionsState } from '../app.selectors';

export const {
  selectAll,
  selectEntities: selectCollections,
  selectIds,
  selectTotal

} = collectionsAdapter.getSelectors();

export const selectEntityCollections = createSelector(
  selectCollectionsState,
  selectCollections
);

export const selectEntities = (collectionKey: string) =>
createSelector(
  selectEntityCollections,
  (state) => state[collectionKey]?.entities
);

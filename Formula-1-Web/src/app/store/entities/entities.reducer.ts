import { createReducer, on } from '@ngrx/store';
import { loadedEntities, resetEntities } from './entities.actions';
import { collectionsAdapter, initialState } from './entity-collections.state';
import { collectionAdapter } from './entity-collection.state';

export const entitiesReducer = createReducer(
  initialState,
  on(loadedEntities, (state, { apiResult }) => {
    const entities = Object.assign({}, ...apiResult.payload.data.map((x) => ({ [x.id]: x })));

    // collectionAdapter.addMany(entityCollection);

    const newCollectionsState = collectionsAdapter.addOne({
      entityLabel: apiResult.meta.entityLabel,
      collectionLabel: apiResult.meta.collectionLabel,
      collectionKey: apiResult.meta.collectionKey,
      ids: apiResult.payload.data.map(x => x.id),
      entities: entities
    }, state);

    return { ...newCollectionsState };
  }),
  on(resetEntities, (state) => (initialState))
);

import { createReducer, on } from '@ngrx/store';
import { loaded, reset } from './entities.actions';
import { collectionsAdapter, initialState } from './entity-collections.state';
import { collectionAdapter } from './entity-collection.state';

export const entitiesReducer = createReducer(
  initialState,
  on(loaded, (state, { apiResult }) => {
    const entities = Object.assign({}, ...apiResult.payload.data.map((x) => ({[x.id]: x})));

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
  on(reset, (state) => (initialState))
);

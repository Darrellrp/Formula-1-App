import { createReducer, on } from '@ngrx/store';
import { loaded, reset } from './entities.actions';
import { collectionsAdapter, initialState } from './entity-collections.state';
import { collectionAdapter } from './entity-collection.state';

export const entitiesReducer = createReducer(
  initialState,
  on(loaded, (state, { collectionKey, entityCollection }) => {
    const entities = Object.assign({}, ...entityCollection.map((x) => ({[x.id]: x})));
    // collectionAdapter.addMany(entityCollection);
    const newCollectionsState = collectionsAdapter.addOne({
      key: collectionKey,
      ids: entityCollection.map(x => x.id),
      entities: entities
    }, state);

    return { ...newCollectionsState };
  }),
  on(reset, (state) => (initialState))
);

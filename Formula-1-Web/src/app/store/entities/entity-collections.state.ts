import { EntityAdapter, EntityState, createEntityAdapter } from '@ngrx/entity';
import { Entity } from 'src/app/models/entities/entity';
import { CollectionState } from './entity-collection.state';

export const collectionsAdapter : EntityAdapter<CollectionState<Entity>> = createEntityAdapter<CollectionState<Entity>>({
  selectId: (collections) => collections.collectionKey
});

export interface EntityCollectionsState extends EntityState<CollectionState<Entity>> {

}

export const initialState: EntityCollectionsState = collectionsAdapter.getInitialState();

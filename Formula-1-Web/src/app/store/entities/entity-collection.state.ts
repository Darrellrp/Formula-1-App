import { EntityAdapter, EntityState, createEntityAdapter } from '@ngrx/entity';
import { Entity } from 'src/app/models/entities/entity';

export const collectionAdapter : EntityAdapter<Entity> = createEntityAdapter<Entity>({
  selectId: (collection) => collection.id
});

export const initialState: CollectionState<Entity> = {
  entityLabel: '',
  collectionLabel: '',
  collectionKey: '',
  ...collectionAdapter.getInitialState()
};

export interface CollectionState<Entity> extends EntityState<Entity> {
  entityLabel: string;
  collectionLabel: string;
  collectionKey: string;
}

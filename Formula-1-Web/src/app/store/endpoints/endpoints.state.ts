import { EntityAdapter, EntityState, createEntityAdapter } from '@ngrx/entity';
import { Endpoint } from 'src/app/models/endpoint';

export const endpointsAdapter: EntityAdapter<Endpoint> = createEntityAdapter<Endpoint>({
  selectId: (collection) => collection.key
});

export const initialState: EndpointsState = {
  ...endpointsAdapter.getInitialState()
};

export interface EndpointsState extends EntityState<Endpoint> { }

import { ActionReducerMap } from '@ngrx/store';
import { AppState } from './app.state';
import { entitiesReducer } from './entities/entities.reducer';
import { endpointsReducer } from './endpoints/endpoints.reducer';

export const reducers: ActionReducerMap<AppState> = {
  entityCollections: entitiesReducer,
  endpoints: endpointsReducer
};

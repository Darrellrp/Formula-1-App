import { ActionReducerMap } from '@ngrx/store';
import { AppState } from './app.state';
import { entitiesReducer } from './entities/entities.reducer';

export const reducers: ActionReducerMap<AppState> = {
  entityCollections: entitiesReducer,
};

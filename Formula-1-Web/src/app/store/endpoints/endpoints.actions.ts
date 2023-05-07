import { createAction, props } from '@ngrx/store'
import { Endpoint } from 'src/app/models/endpoint';

export enum ApiEndpointsActions {
  LoadEndpoints = '[API Endpoints] Load endpoints from API',
  LoadedEndpoints = '[API Endpoints] Loaded endpoints from API',
  ResetEndpoints = '[API Endpoints] Reset endpoints'
}

export const loadEndpoints = createAction(ApiEndpointsActions.LoadEndpoints);
export const loadedEndpoints = createAction(ApiEndpointsActions.LoadedEndpoints, props<{ endpoints: Endpoint[] }>());
export const resetEndpoints = createAction(ApiEndpointsActions.ResetEndpoints);

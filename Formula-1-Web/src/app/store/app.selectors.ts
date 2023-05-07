import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AppState } from './app.state';

export const getAppState = createFeatureSelector<AppState>('app');

export const selectCollectionsState = createSelector(
  getAppState,
  (state: AppState) => state.entityCollections
);

export const selectEndpointsState = createSelector(
  getAppState,
  (state: AppState) => state.endpoints
);

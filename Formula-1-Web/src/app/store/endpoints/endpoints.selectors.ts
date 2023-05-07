import { createSelector } from '@ngrx/store';
import { selectEndpointsState } from '../app.selectors';
import { endpointsAdapter } from './endpoints.state';

export const {
  selectAll,
  selectEntities,
  selectIds,
  selectTotal

} = endpointsAdapter.getSelectors();

export const selectEndpoints = createSelector(
  selectEndpointsState,
  selectEntities
);

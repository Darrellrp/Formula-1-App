import { createReducer, on } from '@ngrx/store';
import { endpointsAdapter, initialState } from './endpoints.state';
import { loadedEndpoints, resetEndpoints } from './endpoints.actions';

export const endpointsReducer = createReducer(
  initialState,
  on(loadedEndpoints, (state, { endpoints }) => {
    const newEndpointsState = endpointsAdapter.addMany(endpoints, state);
    return { ...newEndpointsState };
  }),
  on(resetEndpoints, (state) => (initialState))
);

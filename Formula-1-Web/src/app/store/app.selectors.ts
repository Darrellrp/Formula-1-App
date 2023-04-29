import { AppState } from './app.state';

export const selectEntitiesState = (state: AppState) => state.entityCollections;

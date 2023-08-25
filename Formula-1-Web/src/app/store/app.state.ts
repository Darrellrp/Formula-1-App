import { EndpointsState } from './endpoints/endpoints.state';
import { EntityCollectionsState } from './entities/entity-collections.state';

export interface AppState {
  entityCollections: EntityCollectionsState,
  endpoints: EndpointsState
}

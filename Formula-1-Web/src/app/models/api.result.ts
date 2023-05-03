export interface ApiResult<Entity> {
  meta: {
    collectionLabel: string;
    collectionKey: string;
    entityLabel: string;
  }
  payload: {
    data: Array<Entity>
  }
}

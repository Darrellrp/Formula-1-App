export interface ApiResult<Entity> {
  meta: {
    type: string;
  }
  payload: {
    data: Array<Entity>
  }
}

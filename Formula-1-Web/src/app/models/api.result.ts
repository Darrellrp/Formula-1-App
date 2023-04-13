export interface ApiResult<Entity> {
  meta: {
    label: string;
    key: string;
  }
  payload: {
    data: Array<Entity>
  }
}

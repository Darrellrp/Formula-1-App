import { Entity } from './entity';

export default interface Circuit extends Entity {
  id: number,
  ref: string,
  name: string,
  location: string,
  country: string,
  lat: string,
  lng: string,
  url: string
}

import { Entity } from './entity';

export default class Circuit implements Entity {
  constructor(
    public id: number,
    public ref: string,
    public name: string,
    public location: string,
    public country: string,
    public lat: string,
    public lng: string,
    public url: string
    ) { }
}

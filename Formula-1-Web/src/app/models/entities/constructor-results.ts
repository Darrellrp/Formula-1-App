import { Entity } from './entity';

export default class ConstructorResults implements Entity {
  constructor(
    public id: number,
    public raceId: number,
    public constructorId: number,
    public points: number,
    public standing: string
  ) {}
}

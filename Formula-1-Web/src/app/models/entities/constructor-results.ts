import { Entity } from './entity';

export default interface ConstructorResults extends Entity {
  id: number,
  raceId: number,
  constructorId: number,
  points: number,
  standing: string
}

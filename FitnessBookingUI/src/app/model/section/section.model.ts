import { Coach } from './../coach/coach.model';
export class Section {
  id: number;

  constructor(
    id: number,
    name: string,
    typeId: number,
    gymId: number
  ) {
    this.id = id;
    this.name = name;
    this.typeId = typeId;
    this.gymId = gymId;
  }
  name: string;
  typeId: number;
  gymId: number;
}

import { Coach } from './../coach/coach.model';
export class NewSection {
  name: string;
  typeId: number;
  gymId: number;

  constructor(name: string, typeId: number, gymId: number) {
    this.name = name;
    this.typeId = typeId;
    this.gymId = gymId;
  }
}

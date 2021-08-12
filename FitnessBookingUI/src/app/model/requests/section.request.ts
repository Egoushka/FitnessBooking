export class SectionRequest {
  name: string;
  typeId: number;
  gymId: number;
  coachId: number;

  constructor(name: string, typeId: number, gymId: number, coachId: number) {
    this.name = name;
    this.typeId = typeId;
    this.gymId = gymId;
    this.coachId = coachId;
  }
}

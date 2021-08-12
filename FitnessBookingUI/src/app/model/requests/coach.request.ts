export class CoachRequest {
  id: number;
  sectionId: number;
  constructor(id: number, sectionId: number) {
    this.sectionId = sectionId;
    this.id = id;
  }
}

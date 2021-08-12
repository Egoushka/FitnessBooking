export class UpdateCoach {
  constructor(id: number, sectionId: number) {
    this.sectionId = sectionId;
    this.id = id;
  }
  public id: number;
  public sectionId: number;
}

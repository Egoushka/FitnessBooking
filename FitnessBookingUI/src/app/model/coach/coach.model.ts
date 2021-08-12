export class Coach {
  constructor(id: number, sectionId: number, userId: number) {
    this.sectionId = sectionId;
    this.userId = userId;
  }
  id: number;
  sectionId: number;
  userId: number;
}

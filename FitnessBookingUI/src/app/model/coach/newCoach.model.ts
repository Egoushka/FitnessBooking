export class NewCoach {
  constructor(sectionId: number, userId: number) {
    this.sectionId = sectionId;
    this.userId = userId;
  }
  sectionId: number;
  userId: number;
}

export class NewVisitorSchedule {
  userId: number;
  day: Date;
  sectionScheduleId: number;

  constructor(
    userId: number,
    day: Date,
    sectionScheduleId: number
  ) {
    this.userId = userId;
    this.day = day;
    this.sectionScheduleId = sectionScheduleId;
  }
}

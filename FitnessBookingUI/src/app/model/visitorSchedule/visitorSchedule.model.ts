export class VisitorSchedule {
  id: number;
  userId: number;
  visitTypeId: number;
  day: Date;
  sectionScheduleId: number;
  statusId: number;

  constructor(
    id: number,
    userId: number,
    visitTypeId: number,
    day: Date,
    sectionScheduleId: number,
    statusId: number
  ) {
    this.id = id;
    this.userId = userId;
    this.visitTypeId = visitTypeId;
    this.day = day;
    this.sectionScheduleId = sectionScheduleId;
    this.statusId = statusId;
  }
}

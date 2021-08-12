import { TimeSpan } from "src/app/tools/timeSpan";

export class SectionScheduleRequest {
  sectionId: number;
  startHour: number;
  endHour: number;

  constructor(
    sectionId: number,
    startHour: number,
    endHour: number,
  ) {
    this.sectionId = sectionId;
    this.startHour = startHour;
    this.endHour = endHour;
  }
}

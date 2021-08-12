import { TimeSpan } from './../../tools/timeSpan';
export class NewSectionSchedule {
  sectionId: number;
  startHour: number;
  endHour: number;

  constructor(
    sectionId: number,
    startHour: number,
    endHour: number
  ) {
    this.sectionId = sectionId;
    this.startHour = startHour;
    this.endHour = endHour;
  }
}

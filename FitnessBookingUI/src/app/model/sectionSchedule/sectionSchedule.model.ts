import { TimeSpan } from './../../tools/timeSpan';
export class SectionSchedule {
  constructor(
    id: number,
    sectionId: number,
    startHour: TimeSpan,
    endHour: TimeSpan
  ) {
    this.id = id;
    this.sectionId = sectionId;
    this.startHour = startHour;
    this.endHour = endHour;
  }

  id: number;
  sectionId: number;
  startHour: TimeSpan;
  endHour: TimeSpan;
}

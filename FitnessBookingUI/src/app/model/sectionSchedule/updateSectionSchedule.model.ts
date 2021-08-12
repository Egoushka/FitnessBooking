import { TimeSpan } from './../../tools/timeSpan';
export class UpdateSectionSchredule {
  constructor(
    id: number,
    sectionId: number,
    startHour: number,
    endHour: number
  ) {
    this.id = id;
    this.sectionId = sectionId;
    this.startHour = startHour;
    this.endHour = endHour;
  }

  id: number;
  sectionId: number;
  startHour: number;
  endHour: number;
}

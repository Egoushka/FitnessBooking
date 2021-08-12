import { Observable } from 'rxjs';
import { UpdateSectionSchredule } from './../../model/sectionSchedule/updateSectionSchedule.model';
import { NewSectionSchedule } from './../../model/sectionSchedule/newSectionSchedule.model';
import { TimeSpan } from './../../tools/timeSpan';
import { SectionScheduleRequest } from './../../model/requests/sectionSchedule.request';
import { SectionScheduleManagerApiService } from '../api/sectionScheduleApi.service';
import { Injectable } from '@angular/core';
import { SectionSchedule } from 'src/app/model/sectionSchedule/sectionSchedule.model';

@Injectable({
  providedIn: 'root',
})
export class SectionScheduleService {
  constructor(private apiService: SectionScheduleManagerApiService) {}
  get(sectionId?: number, startHour?: number, endHour?: number): Observable<SectionSchedule[]> {
    const request = new SectionScheduleRequest(
      sectionId,
      startHour,
      endHour
    );
    return this.apiService.get(request);
  }
  add(sectionId: number, startHour: number, endHour: number): any {
    const newObj = new NewSectionSchedule(sectionId, startHour,endHour);
    console.log(newObj)
    return this.apiService.add(newObj);
  }

  update(id:number, sectionId: number, startHour: number, endHour: number): any {
    const objToUpdate = new UpdateSectionSchredule(id, sectionId, startHour, endHour);
    return this.apiService.update(objToUpdate);
  }
}

import { SectionSchedule } from '../../model/sectionSchedule/sectionSchedule.model';
import { UpdateSectionSchredule } from '../../model/sectionSchedule/updateSectionSchedule.model';
import { NewSectionSchedule } from '../../model/sectionSchedule/newSectionSchedule.model';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { SectionScheduleRequest } from 'src/app/model/requests/sectionSchedule.request';

@Injectable({
  providedIn: 'root',
})
export class SectionScheduleManagerApiService {
  constructor(private http: HttpClient) {}

  private url = environment.baseUrl + 'SectionSchredule/';

  public add(sectionSchedule: NewSectionSchedule): any {
    const endpointUrl = this.url;
    return this.http
      .post(endpointUrl, sectionSchedule)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public update(sectionSchedule: UpdateSectionSchredule): any {
    const endpointUrl = this.url;
    return this.http
      .put(endpointUrl, sectionSchedule)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public get(request: SectionScheduleRequest): Observable<SectionSchedule[]> {
    return this.http.get<SectionSchedule[]>(this.url, {
      params: {
        sectionId:
          request.sectionId == null ? '' : request.sectionId.toString(),
        startHour:
          request.startHour == null ? '' : request.startHour.toString(),
        endHour: request.endHour == null ? '' : request.endHour.toString()
      },
    });
  }
}

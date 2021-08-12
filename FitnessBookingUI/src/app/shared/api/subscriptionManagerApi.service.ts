import { VisitorSchedule } from '../../model/visitorSchedule/visitorSchedule.model';
import { NewVisitorSchedule } from '../../model/visitorSchedule/newVisitorSchedule.model';
import { RemoveVisitorSchedule } from '../../model/visitorSchedule/removeVisitorSchedule.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { VisitorScheduleRequest } from 'src/app/model/requests/visitorSchedule.request';

@Injectable({
  providedIn: 'root',
})
export class SubscriptionManagerApiService {
  constructor(private http: HttpClient) {}

  private url = environment.baseUrl + 'Subscription/';

  public subscribe(sectionSchedule: NewVisitorSchedule): any {
    const endpointUrl = this.url + "subscribe/";
    console.log(sectionSchedule)
    return this.http
      .post(endpointUrl, sectionSchedule)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public unSubscribe(visitorSchredul: RemoveVisitorSchedule): any {
    const endpointUrl = this.url;
    return this.http
      .put(endpointUrl, visitorSchredul)
      .pipe(catchError((error) => of(console.log(error))));
  }
  public get(visitorSchreduleRequest: VisitorScheduleRequest): any {
    return this.http.get<VisitorSchedule[]>(this.url, {
      params: {
        userId:
             visitorSchreduleRequest.userId.toString(),
      }
    });
  }
}

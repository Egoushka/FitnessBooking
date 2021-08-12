import { NewVisitorSchedule } from '../../model/visitorSchedule/newVisitorSchedule.model';
import { SubscriptionManagerApiService } from '../api/subscriptionManagerApi.service';
import { LogService } from './log.service';
import { Injectable } from '@angular/core';
import { VisitorScheduleRequest } from 'src/app/model/requests/visitorSchedule.request';

@Injectable({
  providedIn: 'root',
})
export class VisitorScheduleService {
  constructor(
    private subscriptionManagerApiService: SubscriptionManagerApiService,
    private log: LogService
  ) {
  }
  add(
    userId: number,
    day: Date,
    sectionScheduleId: number

  ): any {
    const newObj = new NewVisitorSchedule(
      userId,
      day,
      sectionScheduleId,
    );
    return this.subscriptionManagerApiService.subscribe(newObj);

  }

  get(
    userId: number
  ): any {
    const request = new VisitorScheduleRequest(userId);
    return this.subscriptionManagerApiService.get(request);
  }
}

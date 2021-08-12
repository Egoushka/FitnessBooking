import { AuthService } from 'src/app/shared/service/user.service';
import { LogService } from './../../shared/service/log.service';
import { ScheduleStatus } from './../../model/enums/sheduleStatus.enum';
import { VisitType } from '../../model/enums/visitType.enum.';
import { VisitorSchedule } from './../../model/visitorSchedule/visitorSchedule.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VisitorScheduleService } from 'src/app/shared/service/visitorSchredule.service';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-visitor-home-page',
  templateUrl: './visitor-home-page.component.html',
})
export class VisitorHomePageComponent implements OnInit {
  public visitorSchedules$: VisitorSchedule[] = [];
  VisitType = VisitType;
  ScheduleStatus = ScheduleStatus;
  constructor(
    private visitorScheduleService: VisitorScheduleService,
    private authService: AuthService,
    private logger: LogService
  ) {
  }
  ngOnInit() {
    const userId: number = +this.authService.getUserId();
    this.visitorScheduleService.get(userId).subscribe(visitorSchedules =>{
      this.visitorSchedules$ = visitorSchedules;
    });
  }
}

import { TimeSpan } from '../../tools/timeSpan';
import { AuthService } from '../../shared/service/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SectionSchedule } from 'src/app/model/sectionSchedule/sectionSchedule.model';
import { SectionScheduleService } from 'src/app/shared/service/sectionSchedule.service';

@Component({
  selector: 'app-section-schedules-page',
  templateUrl: './section-schedules-page.component.html',
})
export class SectionSchedulesPageComponent implements OnInit {
  public sectionSchedules$: SectionSchedule[];
  public sectionId: number;
  public sectionName: string;
  public timeSpan = TimeSpan;

  constructor(
    public authService: AuthService,
    private sectionScheduleService: SectionScheduleService,
    private router: Router
  ) {}

  ngOnInit() {
    this.sectionId = +sessionStorage.getItem('sectionId');
    this.sectionName = sessionStorage.getItem('sectionName');
    this.sectionScheduleService.get(this.sectionId).subscribe((values) => {
      this.sectionSchedules$ = values;
    });
  }
  addSectionSchedule() {
    this.router.navigate(['add-edit-section-schedule-page'], {
      state: { sectionId: this.sectionId },
    });
  }
  editSectionSchedule(id: number, startHour: TimeSpan, endHour: TimeSpan) {
    this.router.navigate(['add-edit-section-schedule-page'], {
      state: {
        id: id,
        sectionId: this.sectionId,
        startHour: startHour,
        endHour: endHour,
      },
    });
  }
  subscribe(sectionScheduleId: number){
    this.router.navigate(['subscribe-page'], {
      state: {
        sectionScheduleId: sectionScheduleId,
        userId: this.authService.getUserId(),
      },
    });
  }
  deleteSectionSchedule(id: number) {}
}

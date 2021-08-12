import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SectionScheduleService } from 'src/app/shared/service/sectionSchedule.service';
import { LogService } from 'src/app/shared/service/log.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { TimeSpan } from 'src/app/tools/timeSpan';

@Component({ templateUrl: 'add-edit-section-schedule.component.html' })
export class AddEditSectionScheduleComponent implements OnInit {
  form: FormGroup = new FormGroup({
    startHour: new FormControl(''),
    endHour: new FormControl(''),
  });

  id: number;
  sectionId: number;
  startHour: TimeSpan;
  endHour: TimeSpan;

  isAddMode: boolean;
  loading: boolean = false;
  submitted: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private sectionScheduleService: SectionScheduleService,
    private logger: LogService
  ) {}

  ngOnInit(): void {
    this.id = +history.state.id;
    this.sectionId = +history.state.sectionId;
    this.isAddMode = !this.id;
    if (!this.isAddMode) {
      this.startHour = history.state.startHour;
      this.endHour = history.state.endHour;
    }
    this.form = this.formBuilder.group(
      {
        startHour: [this.isAddMode ? '' : TimeSpan.toStringValue(this.startHour), Validators.required],
        endHour: [this.isAddMode ? '' : TimeSpan.toStringValue(this.endHour), Validators.required],
      },
      { validator: this.checkHours('startHour', 'endHour') }
    );
  }
  checkHours(startHourField: string, endHourField: string) {
    return (group: FormGroup) => {
      const startHourContorl = group.controls[startHourField];
      const endHourContorl = group.controls[endHourField];

      const startHoursAndMinutes = startHourContorl.value.split(':');
      const endHoursAndMinutes = endHourContorl.value.split(':');
      if (startHoursAndMinutes[0] > endHoursAndMinutes[0]) {
        return startHourContorl.setErrors({ notCorrect: true });
      }
      else if (startHoursAndMinutes[0] == endHoursAndMinutes[0]) {
        if (startHoursAndMinutes[1] > endHoursAndMinutes[1])
          return startHourContorl.setErrors({ notCorrect: true });

        if (startHoursAndMinutes[1] == endHoursAndMinutes[1])
          return endHourContorl.setErrors({ notCorrect: true });
      }
      return startHourContorl.setErrors(null);
    };
  }
  get f() {
    return this.form.controls;
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    if (this.isAddMode) {
      this.createSectionSchedule();
    } else {
      this.updateSectionSchedule();
    }
  }

  private createSectionSchedule(): void {
    this.sectionScheduleService
      .add(
        this.sectionId,
        TimeSpan.FromStringToTimeSpan(this.f.startHour.value).TotalSeconds,
        TimeSpan.FromStringToTimeSpan(this.f.endHour.value).TotalSeconds
      )
      .subscribe((result) => {
        this.router.navigate(['section-schedules-page']);
      });
  }

  private updateSectionSchedule(): void {
    this.sectionScheduleService
      .update(
        this.id,
        this.sectionId,
        TimeSpan.FromStringToTimeSpan(this.f.startHour.value).TotalSeconds,
        TimeSpan.FromStringToTimeSpan(this.f.endHour.value).TotalSeconds
      )
      .subscribe((result) => {
        this.router.navigate(['section-schedules-page']);
      });
  }

}

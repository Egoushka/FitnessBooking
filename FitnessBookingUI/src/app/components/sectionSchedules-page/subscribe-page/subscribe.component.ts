import { VisitType } from './../../../model/enums/visitType.enum.';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { VisitorScheduleService } from 'src/app/shared/service/visitorSchredule.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html'
})
export class SubscribeComponent implements OnInit {

  public form: FormGroup;
  sectionScheduleId: number;
  userId: number;
  loading: boolean = false;
  submitted: boolean = false;
  constructor(
    private service: VisitorScheduleService,
    private formBuilder: FormBuilder,
    private router: Router) {}

  ngOnInit() {
    this.sectionScheduleId = +history.state.sectionScheduleId;
    this.userId = +history.state.userId;

    this.form = this.formBuilder.group({
      date:[new Date().getDate()]
    })
  }
  get f(){
    return this.form.controls;
  }
  onSubmit(): void{
  this.submitted = true;
  if(this.form.invalid){
      return;
    }
    this.loading = true;
    this.createVisitorSchedule();
  }
  private createVisitorSchedule(){
    this.service.add(this.userId, new Date(this.f.date.value), this.sectionScheduleId).subscribe((result) => {
      this.router.navigate(['section-schedule-page']);
    });

  }
}


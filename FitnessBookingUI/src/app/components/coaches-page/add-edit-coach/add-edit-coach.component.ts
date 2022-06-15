import { Roles } from './../../../model/enums/roles.enum';
import { User } from './../../../model/user/user.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CoachService } from 'src/app/shared/service/coach.service';
import { LogService } from 'src/app/shared/service/log.service';
import { AuthService } from 'src/app/shared/service/user.service';
import Swal from 'sweetalert2';
@Component({ templateUrl: 'add-edit-coach.component.html' })
export class AddEditCoachComponent implements OnInit {
  form: FormGroup;
  id: number;
  userId: number;
  sectionId: number;
  isAddMode: boolean;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private coachService: CoachService,
    private logger: LogService,
    private authService: AuthService
  ) {}
  public users: User[] = [];

  ngOnInit(): void {
    this.sectionId = +sessionStorage.getItem('sectionId');
    this.authService
      .get(null, Roles.Coach)
      .subscribe((users) => {
        this.users = users
      });

    this.form = this.formBuilder.group({
      coach: [
        '',
        Validators.required
      ],
    });
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

    this.createCoach();
  }

  private createCoach(): void {
    console.log(this.sectionId + " " + this.findCoachInUsersByName(this.f.coach.value))

    this.coachService
      .add(this.sectionId, this.findCoachInUsersByName(this.f.coach.value))
      .subscribe((result) => {
        this.exit();
      });
  }
  findCoachInUsersByName(coachName: string): number{
    let result = null;
    this.users.forEach(item => {
      if(item.name == coachName){
        result = item.id;
      }
    });
    if(!result){
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: "Some error occured in add-edit-coach-component method -> findCoachInUsersByName. Its suppose to be error with names comparing"
      })
    }
    
    return result;
  }
  private exit() {
    sessionStorage.removeItem('coaches');
    this.router.navigate(['coaches']);
  }
}

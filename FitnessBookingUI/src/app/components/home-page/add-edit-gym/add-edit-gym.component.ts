import { Component, OnInit } from '@angular/core';
import { GymService } from 'src/app/shared/service/gym.service';
import { LogService } from 'src/app/shared/service/log.service';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  NumberValueAccessor,
  Validators,
} from '@angular/forms';
@Component({ templateUrl: 'add-edit-gym.component.html' })
export class AddEditGymComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;

  id: number;
  isAddMode: boolean;
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private gymService: GymService,
    private logger: LogService
  ) {}

  ngOnInit(): void {
    this.id = +sessionStorage.getItem('gymId');
    this.isAddMode = !this.id;
    this.form = this.formBuilder.group({
      name: [this.isAddMode ? '' : sessionStorage.getItem('name')],
      location: [this.isAddMode ? '' : sessionStorage.getItem('location')],
      description: [this.isAddMode ? '' : sessionStorage.getItem('description')],
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
    if (this.isAddMode) {
      this.createGym();
    } else {
      this.updateGym();
    }
  }

  private createGym(): void {
    this.gymService
      .add(this.f.name.value, this.f.location.value, this.f.description.value)
      .subscribe((result) => {
        sessionStorage.removeItem('gymId');

        this.exit();
      });
  }

  private updateGym(): void {
    this.gymService
      .update(
        this.id,
        this.f.name.value,
        this.f.location.value,
        this.f.description.value
      )
      .subscribe((result) => {
        sessionStorage.removeItem('name');
        sessionStorage.removeItem('location');
        sessionStorage.removeItem('description');

        this.exit();
      });
  }
  private exit(){
    sessionStorage.removeItem('gymId');
    
    this.router.navigate(['/']);
  }
}

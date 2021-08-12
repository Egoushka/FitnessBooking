import { Roles } from './../../model/enums/roles.enum';
import { AuthService } from '../../shared/service/user.service';
import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
})
export class SignUpComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    repeatPassword: new FormControl(''),
    role: new FormControl('')
  });
  roles: Array<string> = [];
  loading = false;
  submitted = false;
  error = '';
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {
  }
  ngOnInit(): void {
    for (let value in Roles)
    if (typeof Roles[value] === 'number') this.roles.push(value);
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      repeatPassword: ['', Validators.required],
      role: [this.roles[1]]
    },
    {validator: this.checkPasswords('password', 'repeatPassword')}
    );
  }
  checkPasswords(passwordKey: string, passwordConfirmationKey: string) {
    return (group: FormGroup) => {
      const passwordInput = group.controls[passwordKey],
          passwordConfirmationInput = group.controls[passwordConfirmationKey];
      if (passwordInput.value !== passwordConfirmationInput.value) {
        return passwordConfirmationInput.setErrors({notSame: true});
      }
      else {
          return passwordConfirmationInput.setErrors(null);
      }
    };
  }
  get f() {
    return this.registerForm.controls;
  }

  onSubmit() {
    console.log(+Roles[this.f.role.value])
    this.submitted = true;
    if (this.registerForm.invalid ) {
      return;
    }
    this.loading = true;
    this.authService
      .signUp(this.f.username.value, this.f.email.value, this.f.password.value, this.f.repeatPassword.value, +Roles[this.f.role.value]);

  }
}

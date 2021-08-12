import { AuthService } from '../../shared/service/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-sign-in',
  templateUrl: 'sign-in.component.html',
})
export class SignInComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {
    if (localStorage.getItem('access_token')) {
      this.router.navigate(['/']);
    }
  }
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  get f() {
    return this.loginForm.controls;
  }
  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    this.authService.signIn(this.f.username.value, this.f.password.value);
  }
  signUp() {
    this.router.navigate(['sign-up']);
  }
}

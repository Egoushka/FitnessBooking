import { AddEditSectionComponent } from './components/sections-page/add-edit-section/add-edit-section.component';
import { VisitorHomePageComponent } from './components/visitor-home-page/visitor-home-page.component';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { SectionsPageComponent } from './components/sections-page/sections-page.component';
import { CoachesPageComponent } from './components/coaches-page/coaches-page.component';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { LogService } from './shared/service/log.service';
import { HomePageComponent } from './components/home-page/home-page.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { AuthService } from './shared/service/user.service';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserManagerApiService } from './shared/api/userManagerApi.service';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { AddEditGymComponent } from './components/home-page/add-edit-gym/add-edit-gym.component';
import { AddEditSectionScheduleComponent } from './components/sectionSchedules-page/add-edit-section-schedule/add-edit-section-schedule.component';
import { AddEditCoachComponent } from './components/coaches-page/add-edit-coach/add-edit-coach.component';
import { SectionSchedulesPageComponent } from './components/sectionSchedules-page/section-schedules-page.component';
import { SubscribeComponent } from './components/sectionSchedules-page/subscribe-page/subscribe.component';

@NgModule({

  declarations: [
    AppComponent,
    SignInComponent,
    SignUpComponent,
    CoachesPageComponent,
    SubscribeComponent,
    HomePageComponent,
    VisitorHomePageComponent,
    SectionsPageComponent,
    SectionSchedulesPageComponent,
    AddEditCoachComponent,
    AddEditSectionScheduleComponent,
    AddEditSectionComponent,
    AddEditGymComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    AppRoutingModule,
    NgbModule,

  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AuthService,
    UserManagerApiService,
    LogService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

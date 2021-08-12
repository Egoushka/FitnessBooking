import { AddEditSectionComponent } from './components/sections-page/add-edit-section/add-edit-section.component';
import { VisitorHomePageComponent } from './components/visitor-home-page/visitor-home-page.component';
import { SectionsPageComponent } from './components/sections-page/sections-page.component';
import { BrowserModule } from '@angular/platform-browser';
import { CoachesPageComponent } from './components/coaches-page/coaches-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SectionSchedulesPageComponent } from './components/sectionSchedules-page/section-schedules-page.component';
import { AddEditGymComponent } from './components/home-page/add-edit-gym/add-edit-gym.component';
import { AddEditSectionScheduleComponent } from './components/sectionSchedules-page/add-edit-section-schedule/add-edit-section-schedule.component';
import { AddEditCoachComponent } from './components/coaches-page/add-edit-coach/add-edit-coach.component';
import { SubscribeComponent } from './components/sectionSchedules-page/subscribe-page/subscribe.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'coaches', component: CoachesPageComponent },
  { path: 'visitor-home-page', component:VisitorHomePageComponent },
  { path: 'sections', component: SectionsPageComponent},
  { path: 'section-schedules-page', component:SectionSchedulesPageComponent},
  { path: 'add-edit-section-page', component:AddEditSectionComponent},
  { path: 'add-edit-section-schedule-page', component:AddEditSectionScheduleComponent},
  { path: 'add-edit-gym-page', component:AddEditGymComponent},
  { path: 'add-edit-coach-page', component: AddEditCoachComponent },
  { path: 'subscribe-page', component: SubscribeComponent },
  { path: 'sign-in', component: SignInComponent },
  { path: 'sign-up', component: SignUpComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), BrowserModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}

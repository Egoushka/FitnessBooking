import { CoachService } from '../../shared/service/coach.service';
import { Coach } from 'src/app/model/coach/coach.model';
import { Component, ElementRef, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-coaches-page',
  templateUrl: './coaches-page.component.html',
})
export class CoachesPageComponent implements OnInit {
  public coaches$: Coach[] = [];
  constructor(public coachService: CoachService, private router: Router) {}

  ngOnInit() {
    this.coachService.get().subscribe((values) => {
      this.coaches$ = values;
      console.log(this.coaches$)
    });
  }
  editCoach(id: number, userId: number) {
    sessionStorage.setItem('coachId', id.toString());
    sessionStorage.setItem('userId', userId.toString());
    sessionStorage.setItem('coaches', JSON.stringify(this.coaches$));

    this.router.navigate([`add-edit-coach-page`]);
  }
  newCoach() {
    this.router.navigate([`add-edit-coach-page`]);
  }
}

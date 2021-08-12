import { map } from 'rxjs/operators';
import { LogService } from './log.service';
import { UpdateCoach } from './../../model/coach/updateCoach.model';
import { CoachRequest } from './../../model/requests/coach.request';
import { Coach } from './../../model/coach/coach.model';
import { NewCoach } from './../../model/coach/newCoach.model';
import { CoachManagenerApiService } from '../api/coachManagenerApi.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CoachService {

  constructor(
    private coachMagamentService: CoachManagenerApiService,
    private log: LogService
  ) {
  }

  get(id?: number, sectionId?: number): Observable<Coach[]> {
    const request = new CoachRequest(id, sectionId);
    return this.coachMagamentService.get(request);

  }
  add(sectionId: number, userId: number): any {
    const newObj = new NewCoach(sectionId, userId);
    return this.coachMagamentService.add(newObj);
  }

  update(sectionId: number, id: number): any {
    const valueToUpdate = new UpdateCoach(id, sectionId);
    return this.coachMagamentService.update(valueToUpdate);
  }
}

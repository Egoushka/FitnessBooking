import { Observable } from 'rxjs';
import { GymRequest } from './../../model/requests/gym,request';
import { UpdateGym } from './../../model/gym/updateSection.model';
import { NewGym } from './../../model/gym/newGym.model';
import { GymManagerApiService } from '../api/gymManagementApi.service';
import { LogService } from './log.service';
import { Injectable } from '@angular/core';
import { Gym } from 'src/app/model/gym/gym.model';

@Injectable({
  providedIn: 'root',
})
export class GymService {

  constructor(
    private gymManagenerApiService: GymManagerApiService,
    private log: LogService
  ) {
  }
  get(name?: string, location?: string) {
    const request = new GymRequest(location, name);
    return this.gymManagenerApiService.get(request);
  }
  add(name: string, location: string, description: string): Observable<Gym[]> {
    const newObj = new NewGym(name, location, description);
    return this.gymManagenerApiService.add(newObj);
  }

  update(
    id: number,
    name: string,
    location: string,
    description: string
  ): Observable<Gym[]> {
    const valueToUpdate = new UpdateGym(id, name, location, description);
    return this.gymManagenerApiService.update(valueToUpdate);
  }
}

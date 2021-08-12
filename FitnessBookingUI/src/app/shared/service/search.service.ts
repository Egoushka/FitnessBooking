import { NewGym } from './../../model/gym/newGym.model';
import { SectionRequest } from './../../model/requests/section.request';
import { SearchRequest } from './../../model/requests/search.request';
import { GymRequest } from './../../model/requests/gym,request';
import { LogService } from './log.service';
import { Injectable } from '@angular/core';
import { SearchManagerApiService } from '../api/searchManagementApi.service';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  constructor(
    private gymManagenerApiService: SearchManagerApiService,
    private log: LogService
  ) {
  }
  get(
    name?: string,
    location?: string,
    sectionName?: string,
    typeId?: number,
    gymId?: number,
    coachId?: number
  ): any {
    const gymRequest = new GymRequest(location, name);
    const sectionRequest = new SectionRequest(
      sectionName,
      typeId,
      gymId,
      coachId
    );

    const request = new SearchRequest(gymRequest, sectionRequest);
    return this.gymManagenerApiService.get(request);
  }
}

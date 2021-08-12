import { SearchRequest } from '../../model/requests/search.request';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Gym } from 'src/app/model/gym/gym.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root',
})
export class SearchManagerApiService {
  constructor(private http: HttpClient) {}

  private url = environment.baseUrl + 'Gym/';

  public get(request: SearchRequest): Observable<Gym[]> {

    return this.http.get<Gym[]>(this.url, {params:
    {
      name: request.gymRequest.name == null? '' : request.gymRequest.name.toString(),
      location: request.gymRequest.location == null ? '' : request.gymRequest.location.toString(),
      sectionName: request.sectionRequest.name == null ? '' : request.sectionRequest.name.toString(),
      typeId : request.sectionRequest.typeId == null ? '' : request.sectionRequest.typeId.toString(),
      gymId : request.sectionRequest.gymId == null ? '' : request.sectionRequest.gymId.toString(),
      coachId: request.sectionRequest.coachId == null ? '' : request.sectionRequest.coachId.toString()
    }});
  }
}

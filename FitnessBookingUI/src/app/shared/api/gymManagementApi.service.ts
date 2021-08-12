import { Gym } from '../../model/gym/gym.model';
import { GymRequest } from '../../model/requests/gym,request';
import { UpdateGym } from '../../model/gym/updateSection.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { NewGym } from 'src/app/model/gym/newGym.model';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GymManagerApiService {
  constructor(private http: HttpClient) {}

  private url = environment.baseUrl + 'Gym/';

  public add(gym: NewGym): any {
    const endpointUrl = this.url;

    return this.http
      .post(endpointUrl, gym)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public update(gym: UpdateGym): any {
    const endpointUrl = this.url;
    return this.http
      .put(endpointUrl, gym)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public get(request: GymRequest) {
    return this.http.get<Gym[]>(this.url, {
      params: {
        name: request.name == null ? '' : request.name,
        location: request.location == null ? '' : request.location,
      },
    });
  }

}

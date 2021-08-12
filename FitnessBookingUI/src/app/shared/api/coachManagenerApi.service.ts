import { CoachRequest } from '../../model/requests/coach.request';
import { Coach } from '../../model/coach/coach.model';
import { UpdateCoach } from '../../model/coach/updateCoach.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { NewCoach } from '../../model/coach/newCoach.model';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CoachManagenerApiService {
  constructor(private http: HttpClient) {}

  private url = environment.baseUrl + 'Coach/';

  public add(coach: NewCoach): any {
    const endpointUrl = this.url;

    return this.http
      .post(endpointUrl, coach)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public update(coach: UpdateCoach): any {
    const endpointUrl = this.url;
    console.log(coach);
    return this.http
      .put(endpointUrl, coach)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public get(request: CoachRequest): Observable<Coach[]> {
    return this.http.get<Coach[]>(this.url, {
      params: {
        sectionId:
          request.sectionId == null ? '' : request.sectionId.toString(),
      },
    });
  }
}

import { UpdateSection } from '../../model/section/updateSection.model';
import { Section } from '../../model/section/section.model';
import { SectionRequest } from '../../model/requests/section.request';
import { NewSection } from '../../model/section/newSection.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class SectionManagerApiService {
  constructor(private http: HttpClient) {}

  private url = environment.baseUrl + 'Section/';

  public add(section: NewSection): any {
    const endpointUrl = this.url;

    return this.http
      .post(endpointUrl, section)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public update(section: UpdateSection): any {
    const endpointUrl = this.url;
    return this.http
      .put(endpointUrl, section)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public get(sectionRequest: SectionRequest) {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.get<Section[]>(this.url, {
      params: {
        coachId:
          sectionRequest.name == null ? '' : sectionRequest.name.toString(),
        name:
          sectionRequest.coachId == null ? '' : sectionRequest.coachId.toString(),
        gymId:
          sectionRequest.gymId == null ? '' : sectionRequest.gymId.toString(),
        typeId:
          sectionRequest.typeId == null ? '' : sectionRequest.typeId.toString(),
      },
    });
  }
}

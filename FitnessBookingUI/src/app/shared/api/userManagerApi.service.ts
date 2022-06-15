import { User } from './../../model/user/user.model';
import { UserLoginModel } from '../../model/user/login.model';
import { UserRegisterModel } from '../../model/user/register.model';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { UserRequest } from 'src/app/model/requests/user.request';

@Injectable({
  providedIn: 'root',
})
export class UserManagerApiService {
  constructor(private http: HttpClient) {}

  private url = environment.baseUrl + 'User/';

  public putRegistration(user: UserRegisterModel): any {
    const endpointUrl = this.url;

    return this.http
      .put(endpointUrl, user)
      .pipe(catchError((error) => of(console.log(error))));
  }

  public postLogin(user: UserLoginModel): any {
    const endpointUrl = this.url;

    return this.http
      .post(endpointUrl, user)
      .pipe(catchError((error) => of(console.log(error))));
  }
  public get(request: UserRequest): any {
    const endpointUrl = this.url;

    return this.http.get<User>(endpointUrl, {
      params: {
        id: request.id == null ? '' : request.id.toString(),
        roleId: request.roleId == null ? '' : request.roleId.toString(),
        name: request.name == null ? '' : request.name,
        email: request.email == null ? '' : request.email,
      },
    });
  }
}

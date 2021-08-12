import { Observable } from 'rxjs';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthService } from '../shared/service/user.service';
@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const isApiUrl = request.url.startsWith(environment.baseUrl);
    if (localStorage.getItem('access_token')) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${localStorage.getItem('access_token')}`,
        },
      });
    }
    return next.handle(request);
  }
}

import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from '../shared/service/user.service';

@Injectable()
export class RestrictionGuard implements CanActivate {
  constructor(private authService: AuthService, public router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const restrictions = route.data.restrictions as Array<string>;

    if (this.authService.hasRestrictions(restrictions)) {
      return true;
    }
    else {
      //this.router.navigate(['error/forbidden']);
      return false;
    }
  }
}

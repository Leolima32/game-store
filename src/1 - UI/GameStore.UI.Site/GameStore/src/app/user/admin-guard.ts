import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from '@angular/router';
import { UserService } from './user.service';
import { Observable } from 'rxjs/Rx';
import 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AdminGuard implements CanActivate {

    isAdminLogged: boolean;

    constructor(private userService: UserService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        let decodedToken = JSON.parse(atob(localStorage.token.split('.')[1]))
        if (decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin") {
            return true;
        } else {
            this.router.navigate(['/login']);
        }
    }
}
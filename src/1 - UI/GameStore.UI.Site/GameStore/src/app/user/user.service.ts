import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs';
import { UserDetail } from './user-detail.model';
import { environment } from '../../environments/environment';
import { UserLoginModel } from './user.model';

@Injectable()
export class UserService {

    // Observable navItem source
    private isLoggedSource = new BehaviorSubject<boolean>(false);
    // Observable navItem stream
    isLogged$ = this.isLoggedSource.asObservable();
    // service command
    changeForIsLoggedState(isLogged: boolean) {
        this.isLoggedSource.next(isLogged);
    }

    constructor(private http: HttpClient) { }

    login(model: UserLoginModel): Observable<any> {
        return this.http.post(`${environment.API_ROOT}/api/account/login`, model, { responseType: 'text' });
    }

    getUserInformation(): Observable<UserDetail> {
        var customHeaders = new HttpHeaders({ Authorization: `bearer ${localStorage.getItem('userToken')}` });
        return this.http.get<UserDetail>(`${environment.API_ROOT}/api/account/userclaims`, { headers: customHeaders });
    }
}
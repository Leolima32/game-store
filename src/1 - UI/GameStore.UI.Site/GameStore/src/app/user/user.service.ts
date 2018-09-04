import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs';
import { UserDetail } from './user-detail.model';
import { environment } from '../../environments/environment';
import { UserLoginModel } from './user.model';
import { UserRegisterModel } from './user-register.model';

@Injectable()
export class UserService {

    private isLoggedSource = new BehaviorSubject<boolean>(false);

    isLogged$ = this.isLoggedSource.asObservable();

    changeForIsLoggedState(isLogged: boolean) {
        this.isLoggedSource.next(isLogged);
    }

    constructor(private http: HttpClient) { }

    login(model: UserLoginModel): Observable<any> {
        return this.http.post(`${environment.API_ROOT}/api/account/login`, model, { responseType: 'text' });
    }

    register(model: UserRegisterModel): Observable<any> {
        return this.http.post(`${environment.API_ROOT}/api/account/register`,model);
    }

    getUserInformation(): Observable<UserDetail> {
        var customHeaders = new HttpHeaders({ Authorization: `bearer ${localStorage.getItem('userToken')}` });
        return this.http.get<UserDetail>(`${environment.API_ROOT}/api/account/userclaims`, { headers: customHeaders });
    }
}
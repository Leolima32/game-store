import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, BehaviorSubject, Subject } from 'rxjs';
import { UserDetail } from './user-detail.model';
import { environment } from '../../environments/environment';
import { UserLoginModel } from './user.model';
import { UserRegisterModel } from './user-register.model';

@Injectable()
export class UserService {

    public userToken: string;
    public currentUserChange: Subject<UserDetail> = new Subject<UserDetail>();
    constructor(private http: HttpClient) { }

    login(model: UserLoginModel): Promise<any> {
        const promise = new Promise((resolve, reject) => {
            this.http.post(`${environment.API_ROOT}/api/account/login`, model, { responseType: 'text' }).subscribe((token: any) => {
                if (token) {
                    localStorage.token = token;
                    this.currentUserChange.next(token);
                    return resolve(token);
                } else {
                    return reject(token);
                }
            }, (err: HttpErrorResponse) => {
                return reject(err);
            });
        });
        return promise;
    }

    logOut() {
        localStorage.removeItem('token');
    }

    register(model: UserRegisterModel): Observable<any> {
        return this.http.post(`${environment.API_ROOT}/api/account/register`, model);
    }
}
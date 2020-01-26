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
    public currentUser: UserDetail = null;

    //Event that notifies components from user change
    public currentUserChange: Subject<UserDetail> = new Subject<UserDetail>();

    constructor(private http: HttpClient) { }

    login(model: UserLoginModel): Promise<any> {
        let that = this;
        const promise = new Promise((resolve, reject) => {
            this.http.post(`${environment.API_ROOT}/api/account/login`, model, { responseType: 'text' }).subscribe((token: any) => {
                if (token) {
                    this.userToken = token;
                    // Por enquanto decodifica token no back end
                    // TODO: decodificar token no front.
                    this.getUserInformation().subscribe((data: any) => {
                        that.currentUser = data;
                        that.currentUser.isAdmin = data.roles.indexOf('Admin') !== -1
                        that.currentUserChange.next(data);
                        return resolve(data);
                    });
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
        this.currentUser = null;
        this.currentUserChange.next(this.currentUser);
        this.userToken = null;
    }

    register(model: UserRegisterModel): Observable<any> {
        return this.http.post(`${environment.API_ROOT}/api/account/register`, model);
    }

    // Metodo utilizado para decodificar token no back end
    // TODO: decodificar token no front e apagar este método
    getUserInformation(): Observable<UserDetail> {
        const customHeaders = new HttpHeaders({ Authorization: `bearer ${this.userToken}` });
        return this.http.get<UserDetail>(`${environment.API_ROOT}/api/account/userclaims`, { headers: customHeaders });
    }
}
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { UserDetail } from './user-detail.model';
import { environment } from '../../environments/environment';

@Injectable()
export class UserService {

    constructor(private http: HttpClient) { }
    
    getUserInformation(): Observable<UserDetail> {
        var customHeaders = new HttpHeaders({ Authorization: `bearer ${localStorage.getItem('userToken')}`});
        return this.http.get<UserDetail>(`${environment.API_ROOT}/api/account/userclaims`, { headers: customHeaders});
    }
}
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AddGameService {
    constructor(private http: HttpClient) { }

    postGame(json: any): Observable<any> {
        var customHeaders = new HttpHeaders({ Authorization: `bearer ${localStorage.getItem('userToken')}` });
        return this.http.post(`${environment.API_ROOT}/api/games`, json, { headers: customHeaders })
    }
} 
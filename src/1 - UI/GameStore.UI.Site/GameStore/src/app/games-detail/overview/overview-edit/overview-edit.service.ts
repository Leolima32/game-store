import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class OverviewEditService {    
    customHeaders: HttpHeaders;
    
    constructor(private httpClient: HttpClient) { 
        this.customHeaders = new HttpHeaders({ Authorization: `bearer ${localStorage.token}` });
    }
    
    Submit (json: any): Observable<any> {
        return this.httpClient.post(`${environment.API_ROOT}/api/games/overview`,json, { headers: this.customHeaders});
    }
}
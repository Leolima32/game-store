import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class AddConsoleService {
    
    customHeaders: HttpHeaders;
    
    constructor(private httpClient: HttpClient) { 
        this.customHeaders = new HttpHeaders({ Authorization: `bearer ${localStorage.token}` });
    }
    
    Add (json: any): Observable<any> {
        return this.httpClient.post(`${environment.API_ROOT}/api/platforms`,json, { headers: this.customHeaders});
    }
}
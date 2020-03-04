import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class OverviewService {
    constructor(private httpClient: HttpClient) { }
    
    get(id: string) : Observable<any> {
        return this.httpClient.get(`${environment.API_ROOT}/api/games/${id}/overview`)
    }
}
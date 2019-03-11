import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Platform } from './platform.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class PlatformsService {
    constructor(private http: HttpClient) { }
    
    getAllPlatforms(): Observable<Platform[]> {
        return this.http.get<Platform[]>(`${environment.API_ROOT}/api/platforms`);
    }
}
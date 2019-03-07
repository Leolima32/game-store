import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Company } from './company.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class CompaniesService {
    constructor(private http: HttpClient) { }
    
    getAllCompanies(): Observable<Company[]> {
        return this.http.get<Company[]>(`${environment.API_ROOT}/api/companies`);
    }
}
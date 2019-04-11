import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AddGameService {

    customHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.customHeaders = new HttpHeaders({ Authorization: `bearer ${localStorage.getItem('userToken')}` });
     }

    postGame(json: any): Observable<any> {
        return this.http.post(`${environment.API_ROOT}/api/games`, json, { headers: this.customHeaders })
    }

    postThumbImage(id, files): Observable<any> {

        if (files.length === 0)
        return;

        const formData = new FormData();

        for (let file of files)
            formData.append(file.name, file);

        return this.http.put(`${environment.API_ROOT}/api/games/${id}/uploadthumbimage`, formData, { headers: this.customHeaders });
    }
} 
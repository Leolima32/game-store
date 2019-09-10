import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from '../game.model';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class UpdateGameService {

    customHeaders: HttpHeaders;

    constructor(private httpClient: HttpClient) {
        this.customHeaders = new HttpHeaders({ Authorization: `bearer ${localStorage.getItem('userToken')}` });
    }

    selectGame(id: string): Observable<Game> {
        return this.httpClient.get<Game>(`${environment.API_ROOT}/api/games/${id}`);
    }

    updateGame(json: any): Observable<any> {
        return this.httpClient.put(`${environment.API_ROOT}/api/games`, json, { headers: this.customHeaders });
    }
}

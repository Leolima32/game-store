import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from '../game.model';
import { environment } from 'src/environments/environment';
import { UserService } from 'src/app/user/user.service';

@Injectable({ providedIn: 'root' })
export class UpdateGameService {

    customHeaders: HttpHeaders;

    constructor(private httpClient: HttpClient, private userService: UserService) {
        this.customHeaders = new HttpHeaders({ Authorization: `bearer ${userService.userToken}` });
    }

    selectGame(id: string): Observable<Game> {
        return this.httpClient.get<Game>(`${environment.API_ROOT}/api/games/${id}`);
    }

    updateGame(json: any): Observable<any> {
        return this.httpClient.put(`${environment.API_ROOT}/api/games`, json, { headers: this.customHeaders });
    }

    postThumbImage(id, files): Observable<any> {

        if (files.length === 0) {
            return;
        }

        const formData = new FormData();

        for (const file of files) {
            formData.append(file.name, file);
        }

        return this.httpClient.put(`${environment.API_ROOT}/api/games/${id}/uploadthumbimage`, formData, { headers: this.customHeaders });
    }
}

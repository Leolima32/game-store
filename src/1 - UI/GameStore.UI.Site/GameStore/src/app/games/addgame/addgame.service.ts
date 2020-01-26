import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserService } from 'src/app/user/user.service';

@Injectable({ providedIn: 'root' })
export class AddGameService {

    customHeaders: HttpHeaders;

    constructor(private http: HttpClient, private userService: UserService) {
        this.customHeaders = new HttpHeaders({ Authorization: `bearer ${userService.userToken}` });
    }

    postGame(json: any): Observable<any> {
        return this.http.post(`${environment.API_ROOT}/api/games`, json, { headers: this.customHeaders });
    }

    postThumbImage(id, files): Observable<any> {

        if (files.length === 0) {
            return;
        }

        const formData = new FormData();

        for (const file of files) {
            formData.append(file.name, file);
        }

        return this.http.put(`${environment.API_ROOT}/api/games/${id}/uploadthumbimage`, formData, { headers: this.customHeaders });
    }
}

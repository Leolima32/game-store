import { Game } from "./game.model";
import { GAMESTORE_API } from "../app.api";
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class GamesService {

    currentGame: Game;

    constructor(private http: HttpClient) { }

    getAllGames(): Game[] {
        return new Array<Game>();
    }

    bestSellerGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${GAMESTORE_API}/games`);
    }

    gameById(id: string): Observable<Game> {
        return this.http.get<Game>(`${GAMESTORE_API}/games/${id}`);
    }
}
import { Game } from "./game.model";
import { GAMESTORE_API, GAMESTORE_API_ROOT } from "../app.api";
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable()
export class GamesService {

    currentGame: Game;

    constructor(private http: HttpClient) { }

    getAllGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${GAMESTORE_API}/games`).pipe(
            map(game => {
              game.map((game) => game.imagePath = `${GAMESTORE_API_ROOT + game.imageRelativePath}`);
              game.map((game) => game.coverImagePath = `${GAMESTORE_API_ROOT + game.coverImageRelativePath}`);
              return game
            }));
    }

    bestSellerGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${GAMESTORE_API}/games/bestrated`).pipe(
            map(game => {
              game.map((game) => game.imagePath = `${GAMESTORE_API_ROOT + game.imageRelativePath}`);
              game.map((game) => game.coverImagePath = `${GAMESTORE_API_ROOT + game.coverImageRelativePath}`);
              return game
            }));
    }

    bestRatedGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${GAMESTORE_API}/games/bestrated`).pipe(
            map(game => {
              game.map((game) => game.imagePath = `${GAMESTORE_API_ROOT + game.imageRelativePath}`);
              game.map((game) => game.coverImagePath = `${GAMESTORE_API_ROOT + game.coverImageRelativePath}`);
              return game
            }));
    }

    gameById(id: string): Observable<Game> {
        return this.http.get<Game>(`${GAMESTORE_API}/games/${id}`).pipe(
            map(game => { 
                game.coverImagePath = `${GAMESTORE_API_ROOT + game.coverImageRelativePath}`
                return game;
            }));
    }
}
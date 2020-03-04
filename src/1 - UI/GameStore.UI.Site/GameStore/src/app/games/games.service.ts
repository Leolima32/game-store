import { Game } from "./game.model";
import { environment } from '../../environments/environment';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { map } from "rxjs/operators";

@Injectable()
export class GamesService {

    currentGame: Subject<Game> = new Subject<Game>();

    constructor(private http: HttpClient) { }

    getAllGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${environment.API_ROOT}/api/games`).pipe(
            map(game => {
              game.map((game) => game.imagePath = game.imageRelativePath != null ? `${environment.API_ROOT + game.imageRelativePath}` : game.imageRelativePath);
              game.map((game) => game.coverImagePath = `${environment.API_ROOT + game.coverImageRelativePath}`);
              return game
            }));
    }

    bestSellerGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${environment.API_ROOT}/api/games/bestrated`).pipe(
            map(game => {
              game.map((game) => game.imagePath = game.imageRelativePath != null ? `${environment.API_ROOT + game.imageRelativePath}` : game.imageRelativePath);
              game.map((game) => game.coverImagePath = `${environment.API_ROOT + game.coverImageRelativePath}`);
              return game
            }));
    }

    bestRatedGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${environment.API_ROOT}/api/games/bestrated`).pipe(
            map(game => {
              game.map((game) => game.imagePath = game.imageRelativePath != null ? `${environment.API_ROOT + game.imageRelativePath}` : game.imageRelativePath);
              game.map((game) => game.coverImagePath = `${environment.API_ROOT + game.coverImageRelativePath}`);
              return game
            }));
    }

    gameById(id: string): Observable<Game> {
        return this.http.get<Game>(`${environment.API_ROOT}/api/games/${id}`).pipe(
            map(game => { 
                game.coverImagePath = `${environment.API_ROOT + game.coverImageRelativePath}`
                this.currentGame.next(game);
                return game;
            }));
    }
}
import { Game } from "../games/game.model";
import { Genre } from "../genres/genre.model";
import { environment } from '../../environments/environment';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable()
export class GenresService {

    currentGenre: Genre;

    constructor(private http: HttpClient) { }

    getAllGenres(): Observable<Genre[]> {
        return this.http.get<Genre[]>(`${environment.API_ROOT}/api/genres`).pipe(
            map(genre => {
              genre.map((genre) => genre.quantityOfGames = genre.gamesOfThisGenre.length);
              return genre
            }));
    }

    getGamesByGenre(id: string): Observable<Game[]> {
        return this.http.get<Game[]>(`${environment.API_ROOT}/api/games/listbygenre/${id}`).pipe(
            map(game => {
              game.map((game) => game.imagePath = `${environment.API_ROOT + game.imageRelativePath}`);
              game.map((game) => game.coverImagePath = `${environment.API_ROOT + game.coverImageRelativePath}`);
              return game
            }));
    }
}
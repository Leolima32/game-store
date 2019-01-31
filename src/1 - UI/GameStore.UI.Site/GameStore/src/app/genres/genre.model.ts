import { Game } from "../games/game.model";

export class Genre {
    name: string
    quantityOfGames: number
    gamesOfThisGenre: Game[]
}
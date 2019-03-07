import { Game } from "../games/game.model";

export class Genre {
    id: string
    name: string
    quantityOfGames: number
    gamesOfThisGenre: Game[]
}
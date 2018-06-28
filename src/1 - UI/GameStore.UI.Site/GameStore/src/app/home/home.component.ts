import { Component, OnInit } from '@angular/core';
import { GamesService } from '../games/games.service';
import { Game } from '../games/game.model';

@Component({
  selector: 'gs-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  bestSellerGames: Game[];

  constructor(private gamesService: GamesService) { }

  ngOnInit() {
    this.bestSellerGames = this.gamesService.bestSellerGames()
  }

}

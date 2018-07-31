import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../games/games.service';
import { Game } from '../../games/game.model';

@Component({
  selector: 'gs-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  game: Game;

  constructor(private gamesService: GamesService) { }

  ngOnInit() {
    this.game = this.gamesService.currentGame; 
  }

}

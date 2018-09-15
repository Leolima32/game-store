import { Component, OnInit } from '@angular/core';
import { GamesService } from './games.service';
import { Game } from './game.model';

@Component({
  selector: 'gs-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {

  allGames: Game[];

  constructor(private service: GamesService) { }

  ngOnInit() {
    this.service.getAllGames()
      .subscribe(_ => this.allGames = _);
  }

}

import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../games/games.service';
import { Game } from '../../games/game.model';

@Component({
  selector: 'gs-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  isAdmin = false;
  game: Game;
  showEdit = false;

  constructor(private gamesService: GamesService) { }

  ngOnInit() {
    this.game = this.gamesService.currentGame;
    let decodedToken = JSON.parse(atob(localStorage.token.split('.')[1]))
    this.isAdmin = (decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin")
  }

  toggleEdit() {
    this.showEdit = !this.showEdit;
  }
}

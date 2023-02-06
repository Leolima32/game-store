import { Component, OnInit, Input } from '@angular/core';
import { Game } from '../game.model';

@Component({
  selector: 'gs-game-item',
  templateUrl: './game-item.component.html',
  styleUrls: ['./game-item.component.css']
})
export class GameItemComponent implements OnInit {

  isAdmin: Boolean = false;

  @Input() game: Game;

  constructor() { }

  ngOnInit() {
    if(localStorage.token) {
      this.isAdmin = (JSON.parse(atob(localStorage.token.split('.')[1]))['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin")
    }

  }

}

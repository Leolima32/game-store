import { Component, OnInit, Input } from '@angular/core';
import { Game } from '../game.model';

@Component({
  selector: 'gs-game-item',
  templateUrl: './game-item.component.html',
  styleUrls: ['./game-item.component.css']
})
export class GameItemComponent implements OnInit {

  @Input() game: Game;

  constructor() { }

  ngOnInit() {
  }

}

import { Component, OnInit } from '@angular/core';
import { Game } from '../game.model';
import { UpdateGameService } from './updategame.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'gs-updategame',
  templateUrl: './updategame.component.html',
  styleUrls: ['./updategame.component.css']
})
export class UpdategameComponent implements OnInit {

  updatedGame: Game;

  constructor(private updateGameService: UpdateGameService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.updateGameService.selectGame(this.route.snapshot.params['id']).subscribe((x) => { this.updatedGame = x; });
  }

}

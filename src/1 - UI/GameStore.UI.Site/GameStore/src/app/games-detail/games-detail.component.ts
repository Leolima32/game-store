import { Component, OnInit } from '@angular/core';
import { GamesService } from '../games/games.service';
import { Game } from '../games/game.model';
import { ActivatedRoute } from "@angular/router";
import { ShoppingCartService } from '../shopping-cart/shopping-cart.service';

@Component({
  selector: 'gs-games-detail',
  templateUrl: './games-detail.component.html',
  styleUrls: ['./games-detail.component.css'],
  providers: [GamesService]
})
export class GamesDetailComponent implements OnInit {

  game: Game

  constructor(private gamesService: GamesService,
    private shoppingCartService: ShoppingCartService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.gamesService.gameById(this.route.snapshot.params['id'])
      .subscribe(game => this.game = game)
  }

  addToCart() {
    this.shoppingCartService.addToCart(this.game.id);
  }

}

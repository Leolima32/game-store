import { Component, OnInit } from '@angular/core';
import { Genre } from '../genres/genre.model';
import { GenresService } from '../genres/genres.service';
import { ActivatedRoute } from '@angular/router';
import { Game } from '../games/game.model';

@Component({
  selector: 'gs-genres-detail',
  templateUrl: './genres-detail.component.html',
  styleUrls: ['./genres-detail.component.css']
})
export class GenresDetailComponent implements OnInit {

  allGames: Game[];

  constructor(private service: GenresService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.service.getGamesByGenre(this.route.snapshot.params['id'])
      .subscribe(_ => this.allGames = _);
  }

}

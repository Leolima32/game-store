import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../games/games.service';
import { Game } from '../../games/game.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'gs-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  isAdmin = false;
  gameId: string;
  showEdit = false;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.gameId = this.route.parent.snapshot.params['id']
    let decodedToken = JSON.parse(atob(localStorage.token.split('.')[1]))
    this.isAdmin = (decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin")
  }

  toggleEdit() {
    this.showEdit = !this.showEdit;
  }
}

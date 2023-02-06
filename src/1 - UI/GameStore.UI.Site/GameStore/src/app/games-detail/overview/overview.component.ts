import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OverviewService } from './overview.service';

@Component({
  selector: 'gs-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  isAdmin = false;
  gameId: string;
  showEdit = false;
  overviewHtml: any;

  constructor(private route: ActivatedRoute, private service: OverviewService) { }

  ngOnInit() {
    this.gameId = this.route.parent.snapshot.params['id']
    let decodedToken = JSON.parse(atob(localStorage.token.split('.')[1]))
    this.isAdmin = (decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin")
    this.service.get(this.gameId).subscribe(_ => this.overviewHtml = _.html)
  }

  toggleEdit() {
    this.showEdit = !this.showEdit;
  }

  updateHtml(event) {
    this.overviewHtml = event;
  }
}

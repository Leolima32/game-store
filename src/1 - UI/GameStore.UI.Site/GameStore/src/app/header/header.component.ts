import { Component, OnInit } from '@angular/core';
import { UserService } from '../user/user.service';
import { UserDetail } from '../user/user-detail.model';

@Component({
  selector: 'gs-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {

  logedInUser: UserDetail
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserInformation().subscribe(x => this.logedInUser = x);
  }

  logOut() {
    localStorage.removeItem('userToken');
    this.logedInUser = null;
  }

}

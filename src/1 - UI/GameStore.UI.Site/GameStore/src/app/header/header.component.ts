import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { UserService } from '../user/user.service';
import { UserDetail } from '../user/user-detail.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'gs-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit, OnDestroy {

  sub: Subscription;
  currentUser: UserDetail;
  openMenu = false;

  constructor(private userService: UserService) {
    this.currentUser = userService.currentUser;

    this.sub = userService.currentUserChange.subscribe(_ => { this.currentUser = _ })
  }

  ngOnInit() { }

  logOut() {
    this.userService.logOut();
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  changeMenuState() {
    console.log(this.openMenu);
    this.openMenu = (this.openMenu) ? false : true;
  }

}

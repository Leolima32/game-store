import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { UserService } from '../user/user.service';
import { UserDetail } from '../user/user-detail.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'gs-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit, OnDestroy {

  loggedUser: UserDetail;
  sub: Subscription;
  isAdmin: boolean = false;
  openMenu: boolean = false;

  constructor(private userService: UserService) { }

  ngOnInit() {
    if (localStorage.getItem('userToken') == null) {
      this.sub = this.userService.isLogged$.subscribe(isLogged => {
        if (isLogged == true)
          this.getUserInformation();
      });
    } else {
      this.getUserInformation();
    }
  }

  getUserInformation() {
    this.userService.getUserInformation().subscribe(user => {
      this.loggedUser = user;
      if(user.roles.indexOf('Admin') != -1)
        this.isAdmin = true;
    });
  }

  logOut() {
    localStorage.removeItem('userToken');
    this.userService.changeForIsLoggedState(false);
    this.loggedUser = null;
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  changeMenuState() {
    console.log(this.openMenu);
    this.openMenu = (this.openMenu) ? false: true;
  }

}

import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { UserService } from '../user/user.service';
import { UserDetail } from '../user/user-detail.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'gs-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit, OnDestroy {

  logedInUser: UserDetail;
  sub: Subscription;

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
    this.userService.getUserInformation().subscribe(x => this.logedInUser = x);
  }

  logOut() {
    localStorage.removeItem('userToken');
    this.userService.changeForIsLoggedState(false);
    this.logedInUser = null;
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}

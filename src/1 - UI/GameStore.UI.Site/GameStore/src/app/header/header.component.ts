import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { UserService } from '../user/user.service';
import { UserDetail } from '../user/user-detail.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'gs-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  sub: Subscription;
  currentUser: any;
  openMenu = false;
  isAdmin = false;
  isCustomer = false;

  constructor(private userService: UserService) {
    this.sub = userService.currentUserChange.subscribe(_ => this.reloadCurrentUser())
  }

  ngOnInit() {
    if (localStorage.getItem('token')) {
      this.reloadCurrentUser();
    }
  }

  logOut() {
    this.userService.logOut();
    this.currentUser = null;
    this.isAdmin = false;
    this.isCustomer = false;
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  changeMenuState() {
    console.log(this.openMenu);
    this.openMenu = (this.openMenu) ? false : true;
  }

  reloadCurrentUser() {
    let decodedToken = JSON.parse(atob(localStorage.token.split('.')[1]))
    this.currentUser = decodedToken;
    this.isAdmin = (decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin")
    this.isCustomer = (decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Customer")
  }

}

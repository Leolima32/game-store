import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserLoginModel } from '../user/user.model';
import { Router } from '@angular/router';
import { UserService } from '../user/user.service';

@Component({
  selector: 'gs-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  model = new UserLoginModel('', '', '');
  invalidUser = false;

  constructor(private userService: UserService, private router: Router) { }

  sendForm() {
    const self = this;
    this.userService.login(this.model).then(function (data) {
      self.router.navigate(['/']);
    }).catch(function () {
      this.invalidUser = true;
    });
  }

  clear() {
    this.model = new UserLoginModel('', '', '');
  }
}

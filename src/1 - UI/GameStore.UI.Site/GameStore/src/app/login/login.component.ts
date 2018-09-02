import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserLoginModel } from '../user/user.model';
import { Router } from "@angular/router";
import { UserService } from '../user/user.service';

@Component({
  selector: 'gs-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  model = new UserLoginModel('', '', '')
  token: string;
  invalidUser: boolean = false;

  constructor(private userService: UserService, private router: Router) { }

  sendForm() {
    this.userService.login(this.model).subscribe(
      x => { 
        this.token = x; 
        localStorage.setItem('userToken',this.token);
        this.userService.changeForIsLoggedState(true);
        this.router.navigate(['/']);
      },
      error => this.invalidUser = true
    );
  }

  clear() {
    this.model = new UserLoginModel('', '', '');
  }
}

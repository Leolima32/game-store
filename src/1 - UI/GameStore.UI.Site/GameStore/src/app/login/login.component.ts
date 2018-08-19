import { Component, OnInit } from '@angular/core';
import { User } from './user.model';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { GAMESTORE_API } from '../../app/app.api';
import { Observable } from 'rxjs';
import { Router } from "@angular/router";

@Component({
  selector: 'gs-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  model = new User('', '', '')
  token: string;
  invalidUser: boolean = false;

  constructor(private http: HttpClient, private router: Router) { }

  sendForm() {
    this.postLogin(this.model).subscribe(
      x => { 
        this.token = x; 
        console.log(this.token) 
        this.router.navigate(['/']);
      },
      error => this.invalidUser = true
    );
  }

  postLogin(model: User): Observable<any> {
    return this.http.post(`${GAMESTORE_API}/account/login`, model, { responseType: 'text' });
  }

  clear() {
    this.model = new User('', '', '');
  }
}

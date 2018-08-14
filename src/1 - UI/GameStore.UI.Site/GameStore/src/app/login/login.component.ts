import { Component, OnInit } from '@angular/core';
import { User } from './user.model';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { GAMESTORE_API } from '../../app/app.api';

@Component({
  selector: 'gs-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  model = new User('TonyHalkins','Lol123*','tony.com')

  constructor(private http: HttpClient) { }

  postLogin(model: User) {
    return this.http.post(`${GAMESTORE_API}/login`,model);
  }
}

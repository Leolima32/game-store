import { Component, OnInit } from '@angular/core';
import { UserDetail } from '../user/user-detail.model';
import { UserRegisterModel } from '../user/user-register.model';
import { UserService } from '../user/user.service';
import { Router } from '@angular/router';
import { RegisterError } from './register-error.model';

@Component({
  selector: 'gs-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model = new UserRegisterModel('', '', '')
  token: string;
  error: boolean = false;
  listError: RegisterError[];

  constructor(private userService: UserService, private router: Router) { }

  sendForm() {
    this.userService.register(this.model).subscribe(
      x => {
        this.router.navigate(['/login']);
      },
      message => { 
        this.error = true 
        this.listError = message.error.value;
      }
    );
  }

  ngOnInit() {
  }

}

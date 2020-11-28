import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private authService: AuthService
  ) { }

  ngOnInit(): void {
  }

  public get isLoggetIn() : boolean {
    return this.authService.isAuthenticated()
  }

  login(form: NgForm) {
    this.authService.login(form.value.email, form.value.password)
      .subscribe(res => { }, error => {
        alert('Не правильный логин или пароль')
      })
  }
}
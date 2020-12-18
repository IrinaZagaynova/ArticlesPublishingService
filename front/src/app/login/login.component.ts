import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  login(form: NgForm) {
    this.authService.login(form.value.email, form.value.password)
    .subscribe({
      next: (res: any) => {
        this.router.navigate([''], {skipLocationChange: true})
      },
      error: err => {
        alert('Не правильный логин или пароль')
      }
    })
  }
}

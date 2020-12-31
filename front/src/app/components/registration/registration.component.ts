import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  register(form: NgForm) {
    this.authService.register(form.value.login, form.value.email, form.value.name, form.value.password)
    .subscribe({
      next: (res: any) => {
        this.router.navigate([''], {skipLocationChange: true})
      },
      error: err => {
        alert('Ошибка')
      }
    })
  }


}

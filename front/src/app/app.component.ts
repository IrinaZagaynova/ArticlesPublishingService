import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  public get isLoggedIn() : boolean {
    return this.as.isAuthenticated()
  }

  constructor(private as: AuthService) {}

  login(email: string, password: string) {
    this.as.login(email, password)
    .subscribe(res => {
    }, error => {
      alert('Wrong login or password')
    })
  }

  logout() {
    this.as.logout()
  }
}

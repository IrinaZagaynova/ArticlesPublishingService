import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
  constructor(
    private authService: AuthService
  ) {
  }

  public get isLoggedIn(): boolean{
    return this.authService.isAuthenticated()
  }

  logout() {
    this.authService.logout();
    location.reload()
  }

}

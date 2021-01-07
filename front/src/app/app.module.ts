import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { AppComponent } from './app.component';
import { ArticleCardComponent } from './components/article-card/article-card.component';
import { ArticlesListComponent } from './components/articles-list/articles-list.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { environment } from 'src/environments/environment';
import { ACCESS_TOKEN_KEY } from './services/auth.service';
import { API_URL } from './app-injection-tokens';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './components/login/login.component';
import { ArticleComponent } from './components/article/article.component';
import { CommentComponent } from './components/comment/comment.component';
import { CreateArticleComponent } from './components/create-article/create-article.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { CategoryComponent } from './components/category/category.component';
import { UserArticlesListComponent } from './components/user-articles-list/user-articles-list.component';
import { EditArticleComponent } from './components/edit-article/edit-article.component';

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

@NgModule({
  declarations: [
    AppComponent,
    ArticleCardComponent,
    ArticlesListComponent,
    NavBarComponent,
    LoginComponent,
    ArticleComponent,
    CreateArticleComponent,
    CommentComponent,
    RegistrationComponent,
    CategoryComponent,
    UserArticlesListComponent,
    EditArticleComponent,
   ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,

    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: environment.tokenWhitelistedDomains
      }
    }),

    AppRoutingModule
  ],
  providers: [{
    provide: API_URL,
    useValue: environment.api
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { AppComponent } from './app.component';
import { ArticleCardComponent } from './article-card/article-card.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { environment } from 'src/environments/environment';
import { ACCESS_TOKEN_KEY } from './services/auth.service';
import { API_URL } from './app-injection-tokens';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './login/login.component';
import { ArticleComponent } from './article/article.component';
import { CommentComponent } from './comment/comment.component';
import { CreateArticleComponent } from './create-article/create-article.component';
import { RegistrationComponent } from './registration/registration.component';
import { CategoryComponent } from './category/category.component';
import { UserArticlesListComponent } from './user-articles-list/user-articles-list.component';

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

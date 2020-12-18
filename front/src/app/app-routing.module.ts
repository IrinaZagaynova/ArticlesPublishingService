import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { ArticleComponent } from './article/article.component';
import { CreateArticleComponent } from './create-article/create-article.component';
import { RegistrationComponent } from './registration/registration.component';
import { UserArticlesListComponent } from './user-articles-list/user-articles-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';

const routes: Routes = [
  { path: '', component: ArticlesListComponent},
  { path: 'user-atricles', component: UserArticlesListComponent},
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'create-article', component: CreateArticleComponent},
  { path: 'article/:id', component: ArticleComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

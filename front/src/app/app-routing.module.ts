import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { CreateArticleComponent } from './create-article/create-article.component';
import { ArticleComponent } from './article/article.component';

const routes: Routes = [
  { path: '', component: PropertyListComponent },
  { path: 'login', component: LoginComponent },
  { path: 'create-article', component: CreateArticleComponent},
  { path: 'article/:id', component: ArticleComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

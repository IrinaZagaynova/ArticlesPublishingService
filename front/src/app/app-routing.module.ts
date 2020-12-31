import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ArticlesListComponent } from './components/articles-list/articles-list.component';
import { ArticleComponent } from './components/article/article.component';
import { CreateArticleComponent } from './components/create-article/create-article.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { UserArticlesListComponent } from './components/user-articles-list/user-articles-list.component';

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

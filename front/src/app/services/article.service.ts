import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { ArticleModel } from '../models/article.model';
import { HttpClient } from '@angular/common/http'
import { API_URL } from '../app-injection-tokens';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class ArticleService {
  articles: BehaviorSubject<ArticleModel[]>;

  constructor(
    private http: HttpClient,
    @Inject(API_URL) private apiUrl: string,
    private router: Router
  ) {
    this.articles = new BehaviorSubject<ArticleModel[]>([]);
    this.http.get<ArticleModel[]>(apiUrl + `api/Article/articles`).subscribe(data => {
      this.articles.next(data);
    })
  }

  getArticleById(id: number) {
    return this.http.get<ArticleModel>(this.apiUrl + `api/Article/article/${id}`)
  }

  getAtriclesByTitle(title: string) {
    return this.http.get<ArticleModel[]>(this.apiUrl + `api/Article/articles-by-title?title=${title}`)
  }

  getAtriclesByAuthor(author: string) {
    return this.http.get<ArticleModel[]>(this.apiUrl + `api/Article/articles-by-author?login=${author}`)
  }

  getUserArticles() {
    return this.http.get<ArticleModel[]>(this.apiUrl + `api/Article/get-user-articles`);
  }

  deleteArticle(id: number) {
    return this.http.delete(this.apiUrl +  `api/Article/delete-own-article/${id}`);
  }

}


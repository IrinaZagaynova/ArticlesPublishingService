import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { ArticleModel } from '../models/article.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { API_URL } from '../app-injection-tokens';
import { Router } from '@angular/router';
import { ArticleCardModel } from "../models/article-card.model";
import { UserArticleCardModel } from "../models/user-article-card.mode";

@Injectable({
  providedIn: 'root'
})

export class ArticleService {
  articles: BehaviorSubject<ArticleCardModel[]>;

  constructor(
    private http: HttpClient,
    @Inject(API_URL) private apiUrl: string,
    private router: Router
  ) {
    this.articles = new BehaviorSubject<ArticleCardModel[]>([]);
    this.http.get<ArticleCardModel[]>(apiUrl + `api/Article/articles`).subscribe(data => {
      this.articles.next(data);
    })
  }

  getArticleById(id: number) {
    return this.http.get<ArticleModel>(this.apiUrl + `api/Article/article/${id}`)
  }

  getAtriclesByTitle(title: string) {
    return this.http.get<ArticleCardModel[]>(this.apiUrl + `api/Article/articles-by-title?title=${title}`)
  }

  getAtriclesByAuthor(author: string) {
    return this.http.get<ArticleCardModel[]>(this.apiUrl + `api/Article/articles-by-author?login=${author}`)
  }

  getUserArticles() {
    return this.http.get<UserArticleCardModel[]>(this.apiUrl + `api/Article/get-user-articles`);
  }

  deleteArticle(id: number) {
    return this.http.delete(this.apiUrl +  `api/Article/delete-own-article/${id}`);
  }

  createArticle(title: string, description: string, content: string, categoriesResult: number[], imageIds: number[]) {
    return this.http.post(this.apiUrl + `api/Article/create-article`, {title, description, content, categoryIds: categoriesResult, imageIds: imageIds});
  }

  getArticlesByCategories(categoriesResult: number[]) {
    return this.http.post<ArticleCardModel[]>(this.apiUrl + `api/Article/articles-by-categories`, categoriesResult)
  }
}


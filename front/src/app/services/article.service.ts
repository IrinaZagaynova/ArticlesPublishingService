import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { ArticleModel } from '../models/article.model';
import { HttpClient } from '@angular/common/http'
import { API_URL } from '../app-injection-tokens';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class ArticleRepository {

  articles: BehaviorSubject<ArticleModel[]>;

  constructor(
    private http: HttpClient,
    @Inject(API_URL) private apiUrl: string,
    private router: Router
  ) {
    this.articles = new BehaviorSubject<ArticleModel[]>([]);
    this.http.get<ArticleModel[]>(apiUrl + 'api/Article/get-articles').subscribe(data => {
      this.articles.next(data);
    })
  }

}


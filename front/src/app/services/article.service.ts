import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { ArticleModel } from '../models/article.model';
import { HttpClient } from '@angular/common/http'
import { API } from "../config"
import { API_URL } from '../app-injection-tokens';
import { stringify } from 'querystring';

@Injectable({
  providedIn: 'root'
})

export class ArticleRepository {

  articles: BehaviorSubject<ArticleModel[]>;

  constructor(private http: HttpClient) {
    this.articles = new BehaviorSubject<ArticleModel[]>([]);
    this.http.get<ArticleModel[]>(API + 'api/Article/get-articles').subscribe(data => {
      this.articles.next(data);
    })
  }

}


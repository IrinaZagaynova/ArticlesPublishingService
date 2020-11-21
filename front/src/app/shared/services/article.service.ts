import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { ArticleModel } from '../models/article.model';
import { HttpClient } from '@angular/common/http'
import { API } from "../config"


@Injectable({
  providedIn: 'root'
})

export class ArticleRepository {
  articles: BehaviorSubject<ArticleModel[]>

  constructor(private http: HttpClient){
    this.articles = new BehaviorSubject<ArticleModel[]>([]);
    this.http.get<ArticleModel[]>(API + 'api/Article/get-articles').subscribe(date => {
      this.articles.next(date)
    })
  }

}

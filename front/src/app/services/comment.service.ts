import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { CommentModel } from '../models/comment.model';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../app-injection-tokens';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class CommentService {
  comments: BehaviorSubject<CommentModel[]>

  constructor(
    private http: HttpClient,
    @Inject(API_URL) private apiUrl: string,
    private router: Router
  ) { }

  getComments(articleId: number) {
    return this.http.get<CommentModel[]>(this.apiUrl + `api/Comment/comments/${articleId}`)
  }

  getCommentsCount(articleId: number) {
    return this.http.get<number>(this.apiUrl + `api/Comment/comments-count/${articleId}`)
  }

  createComment(articleId: number, text: string) {
    return this.http.post(this.apiUrl + `api/Comment/create-comment`, {articleId, text})
  }
}

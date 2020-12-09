import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { CommentModel } from '../models/comment.model';
import { HttpClient } from '@angular/common/http'
import { API_URL } from '../app-injection-tokens';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class CommentsService {
  comments: BehaviorSubject<CommentModel[]>

  constructor(
    private http: HttpClient,
    @Inject(API_URL) private apiUrl: string,
    private router: Router
  ) { }

    getComments(id: number) {
      return this.http.get<CommentModel[]>(this.apiUrl + `api/Comment/comments/${id}`)
    }
}

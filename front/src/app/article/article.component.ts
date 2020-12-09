import { ThisReceiver } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { BehaviorSubject } from 'rxjs';

import { ArticleModel } from '../models/article.model';
import { CommentModel } from '../models/comment.model';
import { ArticleService } from '../services/article.service';
import { CommentsService } from '../services/comments.service';


@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit{
  article: ArticleModel
  comments: CommentModel[] = []

  constructor(
    private articleService: ArticleService,
    private commentService: CommentsService,
    private router: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.articleService.getArticleById(this.router.snapshot.params.id).subscribe(res => {
      this.article = res
    });
    this.commentService.getComments(this.router.snapshot.params.id).subscribe(data => {
      this.comments  = data
    });
  }

}

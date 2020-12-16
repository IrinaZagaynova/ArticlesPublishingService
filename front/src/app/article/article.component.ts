import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute} from '@angular/router';

import { ArticleModel } from '../models/article.model';
import { CommentModel } from '../models/comment.model';
import { CategoryModel } from '../models/category.model';
import { ArticleService } from '../services/article.service';
import { CommentService } from '../services/comment.service';
import { CategoryService } from '../services/category.service';
import { AuthService } from '../services/auth.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css'],
})
export class ArticleComponent implements OnInit{
  @Output() update: EventEmitter<any> = new EventEmitter<any>()
  article: ArticleModel
  comments: CommentModel[] = []
  commentForm: FormGroup
  text: string = ''
  categories: CategoryModel[] = []

  constructor(
    private articleService: ArticleService,
    private commentService: CommentService,
    private categoryService: CategoryService,
    private authService: AuthService,
    private router: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.articleService.getArticleById(this.router.snapshot.params.id).subscribe(res => {
      this.article = res
    });
    this.getComments()
    this.getCategories()
  }

  getComments() {
    this.commentService.getComments(this.router.snapshot.params.id).subscribe(data => {
      this.comments = data
    });
  }

  public get isLoggedIn(): boolean {
    return this.authService.isAuthenticated()
  }

  createComment() {
    if (!this.text)
    {
      alert("Комментарий не может быть пустым.")
      return
    }

    this.commentService.createComment(this.article.id, this.text)
    .subscribe(res => {
      this.getComments()
      this.text = "";
    }, error => {
      alert("Не удалось добавить комментарий.")
    })
  }

  getCategories() {
    this.categoryService.getCategoies(this.router.snapshot.params.id).subscribe(data => {
      this.categories = data
    });
  }
}

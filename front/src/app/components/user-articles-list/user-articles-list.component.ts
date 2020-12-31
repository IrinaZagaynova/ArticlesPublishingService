import { Component, OnInit } from '@angular/core';
import { ArticleModel } from '../../models/article.model';
import { ArticleService } from '../../services/article.service';

@Component({
  selector: 'app-user-articles-list',
  templateUrl: './user-articles-list.component.html',
  styleUrls: ['./user-articles-list.component.css']
})
export class UserArticlesListComponent implements OnInit {
  articles: ArticleModel[] = [];

  constructor(
    private articleService: ArticleService
  ) {
  }

  ngOnInit() {
    this.getArticlesByUser()
  }

  getArticlesByUser() {
    this.articleService.getUserArticles().subscribe(data => {
      this.articles = data
    })
  }

  deleteArticle(id: number) {
    this.articleService.deleteArticle(id).subscribe(res => {
      this.getArticlesByUser()
    });
  }
}

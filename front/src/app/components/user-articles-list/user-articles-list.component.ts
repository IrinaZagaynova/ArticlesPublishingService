import { Component, OnInit } from '@angular/core';
import { UserArticleCardModel } from 'src/app/models/user-article-card.mode';
import { ArticleService } from '../../services/article.service';

@Component({
  selector: 'app-user-articles-list',
  templateUrl: './user-articles-list.component.html',
  styleUrls: ['./user-articles-list.component.css']
})
export class UserArticlesListComponent implements OnInit {
  articles: UserArticleCardModel[] = []

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
    })
  }

  isUserHasArticles(): boolean {
    return this.articles.length != 0
  }
}

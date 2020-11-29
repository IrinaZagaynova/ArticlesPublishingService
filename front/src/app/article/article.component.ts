import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';

import { ArticleModel } from '../models/article.model'
import { ArticleService } from '../services/article.service';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit{
  article: ArticleModel

  constructor(
    private articleService: ArticleService,
    private router: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.articleService.getArticleById(this.router.snapshot.params.id).subscribe(res => {
      this.article = res
    })
  }
}

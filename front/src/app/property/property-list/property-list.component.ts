import { Component, OnInit } from '@angular/core';
import { ArticleModel } from '../../models/article.model'
import { ArticleService} from '../../services/article.service'

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit{

  articles: ArticleModel[] = [];

  constructor(private articleRepository: ArticleService) {}

  public ngOnInit() {
    this.articleRepository.articles.subscribe(data => {
      this.articles = data
    })
  }
}

import { Component, OnInit } from '@angular/core';
import { ArticleModel } from '../../shared/models/article.model'
import { ArticleRepository} from '../../shared/services/article.service'

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit{

  articles: ArticleModel[] = [];

  constructor(private articleRepository: ArticleRepository) {
    this.articleRepository.articles.subscribe(data => {
      this.articles = data
    })
  }

  ngOnChanges() {
    this.articleRepository.articles.subscribe(data => {
      this.articles = data
    })
  }

  public ngOnInit() {
    this.articleRepository.articles.subscribe(data => {
      this.articles = data
    })
  }
}

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
  title: string = ''
  author: string = ''

  constructor(private articleService: ArticleService,) {}

  public ngOnInit() {
    this.articleService.articles.subscribe(data => {
      this.articles = data
    })
  }

  getArticlesByTitle() {
    if (!this.title)
    {
      alert("Форма не может быть пустой")
      return
    }

    this.articleService.getAtriclesByTitle(this.title)
    .subscribe(res => {
      this.articles = res
      this.title = "";
    }, error => {
      alert("Ошибка поиска")
    })
  }

  getArticlesByAutor() {
    if (!this.author)
    {
      alert("Форма не может быть пустой")
      return
    }

    this.articleService.getAtriclesByAuthor(this.author)
    .subscribe(res => {
      this.articles = res
      this.author = "";
    }, error => {
      alert("Ошибка поиска")
    })
  }

}

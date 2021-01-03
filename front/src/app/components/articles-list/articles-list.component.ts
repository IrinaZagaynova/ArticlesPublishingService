import { QueryList } from '@angular/core';
import { ElementRef } from '@angular/core';
import { ViewChildren } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ArticleCardModel } from 'src/app/models/article-card.model';
import { CategoryModel } from '../../models/category.model';
import { ArticleService} from '../../services/article.service';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit{
  @ViewChildren("checkboxes") checkboxes: QueryList<ElementRef>
  articles: ArticleCardModel[] = []
  categories: CategoryModel[] = []
  selected: CategoryModel[] = []
  title: string
  author: string

  constructor(
    private articleService: ArticleService,
    private categoryService: CategoryService
    ) {
  }

  public ngOnInit() {
    this.getArticles()
    this.getAllCategories()
  }

  getArticles() {
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
      this.title = ""
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
      this.author = ""
    }, error => {
      alert("Ошибка поиска")
    })
  }

  getArticlesByCategories() {
    this.articleService.getArticlesByCategories(this.selected.map(x => x.id))
    .subscribe(res => {
      this.articles = res
    }, error => {
      alert("Ошибка поиска")
    })
  }

  getAllCategories() {
    this.categoryService.getAllCategories().subscribe(data => {
      this.categories = data
    })
  }

  addSelected(item, evt) {
    if (evt) {
      this.selected.push(item);
    } else {
      let i = this.selected.indexOf(item)
      this.selected.splice(i, 1)
    }
  }

  discardSearch() {
    this.getArticles()
    this.uncheckAll()
  }

  uncheckAll() {
    this.checkboxes.forEach((element) => {
      element.nativeElement.checked = false
    })
  }
}

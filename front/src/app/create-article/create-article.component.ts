import { Component, OnInit } from '@angular/core';
import { CategoryModel } from '../models/category.model';
import { ArticleService } from '../services/article.service';
import { CategoryService} from '../services/category.service';

@Component({
  selector: 'app-create-article',
  templateUrl: './create-article.component.html',
  styleUrls: ['./create-article.component.css']
})
export class CreateArticleComponent implements OnInit{
  title: string
  description: string
  content: string
  categories: CategoryModel[] = []
  selected: CategoryModel[] = []

  constructor(
    private articleService: ArticleService,
    private categoryService: CategoryService
  ) {
  }

  ngOnInit(): void {
    this.getAllCategories()
  }

  createArticle() {
    this.articleService.createArticle(this.title, this.description, this.content, this.selected.map(x => x.id))
    .subscribe(res => {
      location.reload()
    }, error => {
      alert("Не удалось добавить статью")
    })
  }

  getAllCategories() {
    this.categoryService.getAllCategories().subscribe(data => {
      this.categories = data
    });
  }

  addSelected(item, evt) {
    if (evt) {
      this.selected.push(item);
    }else {
      let i = this.selected.indexOf(item)
      this.selected.splice(i,1)
    }
  }
}

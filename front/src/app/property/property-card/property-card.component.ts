import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryModel } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { ArticleModel } from '../../models/article.model'

@Component({
  selector: 'app-property-card',
  templateUrl: 'property-card.component.html',
  styleUrls: ['property-card.component.css']
})
export class PropertyCardComponent implements OnInit{
  @Input() article: ArticleModel
  categories: CategoryModel[] = []

  constructor(
    private categoryService: CategoryService,
  ) {
  }

  ngOnInit(): void {
    this.getCategories()
  }

  getCategories() {
    this.categoryService.getCategoies(this.article.id).subscribe(data => {
      this.categories = data
    });
  }
}

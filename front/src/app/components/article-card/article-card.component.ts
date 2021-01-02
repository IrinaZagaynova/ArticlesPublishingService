import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticleCardModel } from 'src/app/models/article-card.model';
import { CategoryModel } from 'src/app/models/category.model';
import { ImageModel } from 'src/app/models/image.model';
import { CategoryService } from 'src/app/services/category.service';
import { ImageService } from 'src/app/services/image.service';
import { ArticleModel } from '../../models/article.model'

@Component({
  selector: 'app-article-card',
  templateUrl: 'article-card.component.html',
  styleUrls: ['article-card.component.css']
})
export class ArticleCardComponent implements OnInit{
  @Input() article: ArticleCardModel
  categories: CategoryModel[] = []
  images: ImageModel[]= []

  constructor(
    private categoryService: CategoryService,
    private imageService: ImageService
  ) {
  }

  ngOnInit(): void {
    this.getCategories()
    this.getImages()
  }

  getCategories() {
    this.categoryService.getCategoies(this.article.id).subscribe(data => {
      this.categories = data
    });
  }

  getImages() {
    this.imageService.getImages(this.article.id).subscribe(data => {
      this.images = data;
    })
  }
}

import { HttpClient } from '@angular/common/http';
import { Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { EventEmitter } from 'events';
import { CategoryModel } from '../../models/category.model';
import { ArticleService } from '../../services/article.service';
import { CategoryService} from '../../services/category.service';
import { ImageService } from '../../services/image.service';

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
  selectedCategories: CategoryModel[] = []
  imageIds: number[] = []
  selectedFiles: File = null
  form: FormGroup
  myFiles: string[] = []


  constructor(
    private articleService: ArticleService,
    private categoryService: CategoryService,
    private imageService: ImageService
  ) {
  }

  ngOnInit(): void {
    this.getAllCategories()
    this.form = new FormGroup({
      Files: new FormControl(null)
    });
  }

  createArticle() {
    const formData = new FormData();
    for (var i = 0; i < this.myFiles.length; i++) {
      formData.append("Files", this.myFiles[i]);
    }

    this.imageService.uploadImage(formData).subscribe(
      data => {
        this.articleService.createArticle(this.title, this.description, this.content, this.selectedCategories.map(x => x.id), data)
        .subscribe(() => {
        }, () => {
          alert("Не удалось добавить статью")
        })
      }
    )
  }

  getAllCategories() {
    this.categoryService.getAllCategories().subscribe(data => {
      this.categories = data
    })
  }

  addSelected(item, evt) {
    if (evt) {
      this.selectedCategories.push(item);
    } else {
      let i = this.selectedCategories.indexOf(item)
      this.selectedCategories.splice(i, 1)
    }
  }

  getFileDetails(e) {
    for (var i = 0; i < e.target.files.length; i++) {
      this.myFiles.push(e.target.files[i]);
    }
  }

}


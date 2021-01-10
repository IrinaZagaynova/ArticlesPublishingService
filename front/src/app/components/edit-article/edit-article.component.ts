import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryModel } from 'src/app/models/category.model';
import { ImageModel } from 'src/app/models/image.model';
import { SelectedCategoryModel } from 'src/app/models/selected-category.model';
import { ArticleService } from 'src/app/services/article.service';
import { CategoryService } from 'src/app/services/category.service';
import { ImageService } from 'src/app/services/image.service';

@Component({
  selector: 'app-edit-article',
  templateUrl: './edit-article.component.html',
  styleUrls: ['./edit-article.component.css']
})
export class EditArticleComponent implements OnInit {
  title: string
  description: string
  content: string
  isImagesСhanged: boolean = false
  selectedCategories: SelectedCategoryModel[] = []
  myFiles: string[] = []
  options: SelectedCategoryModel[] = []
  images: ImageModel[] = []

  constructor(
    private articleService: ArticleService,
    private categoryService: CategoryService,
    private imageService: ImageService,
    private router: ActivatedRoute
  ) {
    articleService.getArticle(this.router.snapshot.params.id).subscribe(res => {
      this.title = res.title
      this.description = res.description
      this.content = res.content
    });
  }

  ngOnInit(): void {
    this.getDefaultSelectedCetegories()
    this.getImages()
  }

  getDefaultSelectedCetegories() {
    this.categoryService.getSelectedCategories(this.router.snapshot.params.id).subscribe(data => {
      this.options = data
      this.options.forEach(option => {
        if (option.checked) {
          this.selectedCategories.push(option)
        }
      });
    })
  }

  editArticle() {
    let imagesData: number[] = []

    if (this.isImagesСhanged) {
      const formData = new FormData();

      if (this.myFiles.length != 0) {
        for (var i = 0; i < this.myFiles.length; i++) {
          formData.append("Files", this.myFiles[i])
        }

        this.imageService.uploadImage(formData).subscribe(
          data => {
            this.articleService.editArticle(this.router.snapshot.params.id, this.title, this.description, this.content, this.selectedCategories.map(x => x.id), data)
            .subscribe(() => {
            }, () => {
              alert("Не удалось добавить статью")
            })
          })
        return
      }
    }
    else {
      imagesData = this.images.map(x => x.id)
    }

    this.articleService.editArticle(this.router.snapshot.params.id, this.title, this.description, this.content, this.selectedCategories.map(x => x.id), imagesData)
    .subscribe(() => {
      location.reload()
    }, () => {
      alert("Не удалось изменить статью")
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
      this.myFiles.push(e.target.files[i])
    }
  }

  getImages() {
    this.imageService.getImages(this.router.snapshot.params.id).subscribe(data => {
      this.images = data
    });
  }

  viewUploadImagesBlock() {
    this.isImagesСhanged = true
    document.getElementById("upload-images").style.display = "block"
    document.getElementById("current-images").style.display = "none"
    document.getElementById("change-images-button").style.display = "none"
  };

  viewCurrentImagesBlock() {
    this.isImagesСhanged = false
    document.getElementById("upload-images").style.display = "none"
    document.getElementById("current-images").style.display = "block"
    document.getElementById("change-images-button").style.display = "inline-block"
  }

}

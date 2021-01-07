import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { CategoryModel } from '../models/category.model';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../app-injection-tokens';
import { Router } from '@angular/router';
import { SelectedCategoryModel } from "../models/selected-category.model";

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
  constructor(
    private http: HttpClient,
    @Inject(API_URL) private apiUrl: string,
    private router: Router
  ) {
  }

  getCategoies(articleId: number) {
    return this.http.get<CategoryModel[]>(this.apiUrl + `api/Category/categories/${articleId}`)
  }

  getAllCategories() {
    return this.http.get<CategoryModel[]>(this.apiUrl + `api/Category/all-categories`)
  }

  getSelectedCategories(articleId: number) {
    return this.http.get<SelectedCategoryModel[]>(this.apiUrl + `api/Category/selected-categories/${articleId}`)
  }
}


import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';
import { ImageModel } from '../models/image.model';
import { HttpClient } from '@angular/common/http'
import { API_URL } from '../app-injection-tokens';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class ImageService {
  images: BehaviorSubject<ImageModel[]>;

  constructor(
    private http: HttpClient,
    @Inject(API_URL) private apiUrl: string,
    private router: Router
  ) {
  }

  getImages(articleId: number) {
    return this.http.get<ImageModel[]>(this.apiUrl + `api/Image/images/${articleId}`)
  }

}

import { Component, Input, OnInit } from '@angular/core';
import { ArticleRepository } from 'src/app/shared/services/article.service';
import { ArticleModel } from '../../shared/models/article.model'

@Component({
  selector: 'app-property-card',
  templateUrl: 'property-card.component.html',
  styleUrls: ['property-card.component.css']
})
export class PropertyCardComponent{
  @Input() article: ArticleModel
}

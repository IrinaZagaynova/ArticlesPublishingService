import { Component, Input, OnInit } from '@angular/core';
import { ArticleRepository } from 'src/app/services/article.service';
import { ArticleModel } from '../../models/article.model'

@Component({
  selector: 'app-property-card',
  templateUrl: 'property-card.component.html',
  styleUrls: ['property-card.component.css']
})
export class PropertyCardComponent{
  @Input() article: ArticleModel
}

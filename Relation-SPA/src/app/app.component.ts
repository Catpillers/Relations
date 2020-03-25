import { Component } from '@angular/core';
import { RelationService } from './_services/relation.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private _relationService: RelationService) {
   
  }







}

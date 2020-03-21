import { Component } from '@angular/core';
import { RelationService } from './relation.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Relation-SPA';

  constructor(private _relationService: RelationService) {
   this._relationService.GetRelations().subscribe(_ => {
       console.log(_);
    },
    error =>{
      console.log(error);
    });
  }







}

import { Component, OnInit } from '@angular/core';
import { RelationService } from '../_services/relation.service';

@Component({
  selector: 'app-relation-table',
  templateUrl: './relation-table.component.html',
  styleUrls: ['./relation-table.component.scss']
})
export class RelationTableComponent implements OnInit {
  ralation: any = [];
  constructor(private _relationService: RelationService) { }

  ngOnInit() {

  }

  loadAllRelations() {
    this._relationService.GetRelations().subscribe(_ => {
      this.ralation = _;
    });
  }

}

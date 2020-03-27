import { Component, OnInit } from '@angular/core';

import { RelationService } from '../_services/relation.service';

import { Relation } from '../_models/relation';
import { Category } from '../_models/category';

@Component({
  selector: 'app-relation-table',
  templateUrl: './relation-table.component.html',
  styleUrls: ['./relation-table.component.scss']
})
export class RelationTableComponent implements OnInit {
  relations: Relation[];
  categoryList: any = [];
  categories: Category[];
  constructor(private _relationService: RelationService) {}

  ngOnInit() {
    this._relationService.GetCategorys().subscribe(_ => {
      this.categoryList = _;
      this.categories = _;
    });

    this._relationService.GetRelations().subscribe(_ => {
      this.relations = _;
    });
  }

  loadAllRelations() {
    this._relationService.GetRelations().subscribe(_ => {
      this.relations = _;
    });
  }

  sendCategoryId(id: string) {
    this._relationService.GetRelations(id).subscribe(_ => {
      this.relations = _;
    });
  }
}

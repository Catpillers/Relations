import { Component, OnInit, TemplateRef } from '@angular/core';

import { RelationService } from '../_services/relation.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { Relation } from '../_models/relation';
import { Category } from '../_models/category';


@Component({
  selector: 'app-relation-table',
  templateUrl: './relation-table.component.html',
  styleUrls: ['./relation-table.component.scss']
})
export class RelationTableComponent implements OnInit {
  relations: Relation[];
  categories: Category[];
  modalRef: BsModalRef;

  constructor(private _relationService: RelationService, private _modalService: BsModalService) { }

  ngOnInit() {
    this._relationService.GetCategorys().subscribe(_ => {
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
  openModal(template: TemplateRef<any>) {
    this.modalRef = this._modalService.show(template);
  }
}

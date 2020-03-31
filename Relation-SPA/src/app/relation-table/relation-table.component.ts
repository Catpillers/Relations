import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { RelationService } from '../_services/relation.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { Relation } from '../_models/relation';
import { Category } from '../_models/category';
import { Country } from '../_models/country';
import { __values } from 'tslib';



@Component({
  selector: 'app-relation-table',
  templateUrl: './relation-table.component.html',
  styleUrls: ['./relation-table.component.scss']
})
export class RelationTableComponent implements OnInit {
  relations: Relation[];
  categories: Category[];
  countries: Country[];
  addRelationForm: FormGroup;
  modalRef: BsModalRef;
  relation: Relation;
  relationsToDisable: number[] = [];
  clicked = false;

  constructor(private _relationService: RelationService, private _modalService: BsModalService) { }

  ngOnInit() {
    this._relationService.GetCategorys().subscribe(categories => {
      this.categories = categories;
    });

    this._relationService.GetRelations().subscribe(relations => {
      this.relations = relations;
    });

    this._relationService.GetCounties().subscribe(countries => {
      this.countries = countries;
    });

    this.addRelationForm = new FormGroup({
      'relationCategoryId': new FormControl("00000000-0000-0000-0000-000000000001", Validators.required),
      'name': new FormControl(null, [Validators.required,
      Validators.pattern('^[A-z]*'), Validators.minLength(2), Validators.maxLength(11)]),

      'fullName': new FormControl(null, [Validators.required,
      Validators.pattern('^[A-z ]*'), Validators.minLength(2), Validators.maxLength(15)]),

      'emailAddress': new FormControl(null, [Validators.required, Validators.email]),

      'telephoneNumber': new FormControl(null, [Validators.required,
      Validators.pattern('^[+0-9]*'), Validators.minLength(12)]),

      'countryId': new FormControl("00000000-0000-0000-0000-000000000001", Validators.required),

      'city': new FormControl(null, [Validators.required, Validators.minLength(2),
      Validators.pattern('^[A-z ]*')]),

      'street': new FormControl(null, [Validators.required, Validators.minLength(2),
      Validators.pattern('^[A-z ]*')]),

      'number': new FormControl(null, [Validators.required, Validators.minLength(2),
      Validators.pattern('^[0-9]*')]),

      'postalCode': new FormControl(null, Validators.required)
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

  onSubmit() {
    this._relationService.AddRelation(this.addRelationForm.value);
    console.log(this.addRelationForm.value);
  }

  addRelationId(value: number) {
    console.log(value);
    this.relationsToDisable.push(value);
    console.log(this.relationsToDisable);
  }

  disableRelations() {
    this._relationService.DisableRelations(this.relationsToDisable);
  }

  disableButton(id: number) {
    if (this.relationsToDisable.includes(id)) {
      return true;
    }
    return false;
  }

  discardSelected() {
    this.relationsToDisable.pop();
  }

  discardAll() {
    this.relationsToDisable.length = 0;
  }
}

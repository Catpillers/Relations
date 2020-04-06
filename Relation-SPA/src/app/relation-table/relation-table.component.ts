import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { RelationService } from '../_services/relation.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { Relation } from '../_models/relation';
import { Category } from '../_models/category';
import { Country } from '../_models/country';
import { __values } from 'tslib';
import { RelationToUpdate } from '../_models/relationToUpdate';
import { of } from 'rxjs';


enum SortDirection {
  Ascending = 'asc',
  Descending = 'dsc',
}

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
  editRelationForm: FormGroup;
  modalRef: BsModalRef;
  relation: Relation;
  totalItems: number;
  relationsToDisable: number[] = [];
  sorting = {
    fieldName: 'Name',
    direction: 'asc',
  }
  tableHeaders = [
    'Name', 'FullName',
    'EmailAddress', 'TelephoneNumber',
    'CountryName', 'City ', 'Street', 'Number', 'PostalCode',
    'Actions'
  ];
  
  constructor(private _relationService: RelationService, private _modalService: BsModalService) { }

  ngOnInit() {
    this._relationService.GetCategorys().subscribe(categories => {
      this.categories = categories;
    });

    this._relationService.GetRelations().subscribe(relations => {
      this.relations = relations.items;
      this.totalItems = relations.totalCount;
    });

    this._relationService.GetCounties().subscribe(countries => {
      this.countries = countries;
    });

    this.addRelationForm = new FormGroup({
      'relationCategoryId': new FormControl(null, Validators.required),

      'name': new FormControl(null, [Validators.required,
      Validators.pattern('^[A-z]*'), Validators.minLength(2), Validators.maxLength(11)]),

      'fullName': new FormControl(null, [Validators.required,
      Validators.pattern('^[A-z ]*'), Validators.minLength(2), Validators.maxLength(15)]),

      'emailAddress': new FormControl(null, [Validators.required, Validators.email]),

      'telephoneNumber': new FormControl(null, [Validators.required,
      Validators.pattern('^[+0-9]*'), Validators.minLength(12)]),

      'countryId': new FormControl(null, Validators.required),

      'city': new FormControl(null, [Validators.required, Validators.minLength(2),
      Validators.pattern('^[A-z ]*')]),

      'street': new FormControl(null, [Validators.required, Validators.minLength(2),
      Validators.pattern('^[A-z ]*')]),

      'number': new FormControl(null, [Validators.required, Validators.minLength(2),
      Validators.pattern('^[0-9]*')]),

      'postalCode': new FormControl(null, Validators.required)
    });

    this.editRelationForm = new FormGroup({
      'id': new FormControl(null),

      'relationCategoryId': new FormControl(null, Validators.required),

      'name': new FormControl(null, [Validators.required,
      Validators.pattern('^[A-z]*'), Validators.minLength(2), Validators.maxLength(11)]),

      'fullName': new FormControl(null, [Validators.required,
      Validators.pattern('^[A-z ]*'), Validators.minLength(2), Validators.maxLength(15)]),

      'emailAddress': new FormControl(null, [Validators.required, Validators.email]),

      'telephoneNumber': new FormControl(null, [Validators.required,
      Validators.pattern('^[+0-9]*'), Validators.minLength(12)]),

      'countryId': new FormControl(null, Validators.required),

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
      this.relations = _.items;
    });
  }

  sendCategoryId(id: string) {
    this._relationService.GetRelations(id).subscribe(_ => {
      this.relations = _.items;
    });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this._modalService.show(template);
  }

  openModal2(template: TemplateRef<any>, relation: Relation) {
    this.modalRef = this._modalService.show(template);
    const relationToUpdate = {
      id: relation.id,
      relationCategoryId: relation.relationCategoryId,
      countryId: relation.countryId,
      name: relation.name,
      fullName: relation.fullName,
      telephoneNumber: relation.telephoneNumber,
      emailAddress: relation.emailAddress,
      city: relation.city,
      street: relation.street,
      number: relation.number,
      postalCode: relation.postalCode
    };
    this.editRelationForm.setValue(relationToUpdate);
  }


  onSubmit() {
    this._relationService.AddRelation(this.addRelationForm.value).subscribe(() => {
      this.loadAllRelations();
      this.addRelationForm.reset();
    });

  }

  submitEdit() {
    this._relationService.UpdateRelation(this.editRelationForm.value).subscribe(() => {
      this.loadAllRelations();
      this.editRelationForm.reset();
    });
  }

  addRelationId(value: number) {
    console.log(value);
    this.relationsToDisable.push(value);
  }

  disableRelations() {
    this._relationService.DisableRelations(this.relationsToDisable).subscribe(() => {
      this.loadAllRelations();
    });
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

  sort(sortName: string, dir: string) {
    if (this.sorting.fieldName !== sortName) {
      this.sorting = {
        fieldName: sortName,
        direction: dir
      };
    } else {
      this.sorting.direction = this.sorting.direction === SortDirection.Ascending
        ? SortDirection.Descending
        : SortDirection.Ascending;
    }
    this._relationService.GetRelations(null, this.sorting.fieldName, this.sorting.direction)
      .subscribe(_ => {
        this.relations = _.items;
      });
  }

}

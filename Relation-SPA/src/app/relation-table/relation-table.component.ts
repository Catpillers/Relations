import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { RelationService } from '../_services/relation.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { __values } from 'tslib';

import { Relation } from '../_models/relation';
import { Category } from '../_models/category';
import { Country } from '../_models/country';

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
  relationsToDisable: number[] = [];
  addRelationForm: FormGroup;
  editRelationForm: FormGroup;
  totalItems: number;
  currentCategory: string;
  currentPage: string = '1';
  currentDirection: string;
  categoryToDisplay: string;
  modalRef: BsModalRef;
  sorting = {
    fieldName: 'Name',
    direction: undefined
  };
  tableHeaders = [
    'Name', 'FullName',
    'EmailAddress', 'TelephoneNumber',
    'CountryName', 'City', 'Street', 'Number', 'PostalCode'];


  constructor(private _relationService: RelationService, private _modalService: BsModalService) { }

  ngOnInit() {
    this._relationService.GetCategorys().subscribe(categories => {
      this.categories = categories;
    });
    this._relationService.GetRelations().subscribe(relations => {
      this.relations = relations.items;
      this.totalItems = relations.totalCount;
      this.categoryToDisplay = '';
      this.sorting.direction = '';
      this.sorting.fieldName = 'Name';
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
    this.currentCategory = null;
    this._relationService.GetRelations().subscribe(_ => {
      this.relations = _.items;
      this.totalItems = _.totalCount;
      this.categoryToDisplay = '';
    });
  }

  sendCategoryId(id: string, name: string) {
    console.log(this.categoryToDisplay);
    this.currentCategory = id;
    this.categoryToDisplay = name;
    console.log(this.categoryToDisplay);
    this._relationService.GetRelations(this.currentCategory, this.currentPage, null, null).subscribe(_ => {
      this.relations = _.items;
      this.totalItems = _.totalCount;
    });
  }

  addRelationModal(template: TemplateRef<any>) {
    this.modalRef = this._modalService.show(template);
  }

  editRelationModal(template: TemplateRef<any>, relation: Relation) {
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

  addRelationSubmit() {
    this._relationService.AddRelation(this.addRelationForm.value).subscribe(() => {
      this._relationService.GetRelations(this.currentCategory, this.currentPage).subscribe(_ => {
        this.relations = _.items;
        this.totalItems = _.totalCount;
      });
      this.addRelationForm.reset();
    });

  }

  editRelationSubmit() {
    this._relationService.UpdateRelation(this.editRelationForm.value).subscribe(() => {
      if (this.currentCategory === null) {
        this._relationService.GetRelations(null, this.currentPage, null, null)
          .subscribe(_ => {
            this.relations = _.items;

          });
      }
      this._relationService.GetRelations(this.currentCategory, this.currentPage).subscribe(_ => {
        this.relations = _.items;
        this.totalItems = _.totalCount;
      });
      this.editRelationForm.reset();
    });
  }

  addRelationId(value: number) {
    this.relationsToDisable.push(value);
  }

  sort(sortName: string) {
    if (this.sorting.fieldName !== sortName) {
      this.sorting = {
        fieldName: sortName,
        direction: 'asc'
      };
      this.currentDirection = this.sorting.direction;
    } else {
      this.sorting.direction = this.sorting.direction === SortDirection.Ascending
        ? SortDirection.Descending
        : SortDirection.Ascending;
      this.currentDirection = this.sorting.direction;
    }
    this._relationService.GetRelations(this.currentCategory, this.currentPage, this.sorting.fieldName, this.currentDirection)
      .subscribe(_ => {
        this.relations = _.items;
      });
  }

  getSelectedCategoryNameOrDefault(): string {
    return this.categoryToDisplay ? this.categoryToDisplay : 'Select Category';
  }

  disableRelations() {
    this._relationService.DisableRelations(this.relationsToDisable).subscribe(() => {
      this._relationService.GetRelations(this.currentCategory, this.currentPage).subscribe(_ => {
        this.relations = _.items;
        this.totalItems = _.totalCount;
        this.relationsToDisable = [];
      });
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

  pageChanged(pageNumber: any) {
    this.currentPage = pageNumber.page;
    this._relationService.GetRelations(this.currentCategory, this.currentPage, this.sorting.fieldName, this.currentDirection)
      .subscribe(_ => {
        this.relations = _.items;
      });
  }

}

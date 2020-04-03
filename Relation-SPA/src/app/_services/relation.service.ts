import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Relation } from '../_models/relation';
import { Category } from '../_models/category';
import { environment } from 'src/environments/environment';
import { Country } from '../_models/country';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})

export class RelationService {
  baseUrl = environment.apiUrl;
  constructor(private _httpClient: HttpClient) { }

  public GetRelations(id?: string): Observable<Relation[]> {
    let params = new HttpParams();
    if (id != null) {
      params = params.append('categoryId', id);
    }
    return this._httpClient.get<Relation[]>(this.baseUrl + 'Relations', { params });
  }

  public GetCategorys(): Observable<Category[]> {
    return this._httpClient.get<Category[]>(this.baseUrl + 'Categories');
  }

  public GetCounties(): Observable<Country[]> {
    return this._httpClient.get<Country[]>(this.baseUrl + 'Countries');
  }

  public AddRelation(relation: Relation) {
    return this._httpClient.post(this.baseUrl + 'Relations', relation).subscribe();
  }

  public DisableRelations(relationIds: number[]) {
    return this._httpClient.put(this.baseUrl + 'Relations', relationIds).subscribe();
  }
}


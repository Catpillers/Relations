import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Relation } from '../_models/relation';
import { Category } from '../_models/category';
import { environment } from 'src/environments/environment';

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
}


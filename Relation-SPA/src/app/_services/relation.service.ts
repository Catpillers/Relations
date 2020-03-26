import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Relation } from '../_models/relation';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';


@Injectable({
  providedIn: 'root'
})

export class RelationService {
  constructor(private _httpClient: HttpClient) { }

  public GetRelations(id?: string): Observable<Relation[]> {
    let params = new HttpParams();
    if (id != null) {
      params = params.append('categoryId', id);
    }
    return this._httpClient.get<Relation[]>('http://localhost:5000/api/Relations', { params });
  }

  public GetCategorys(): Observable<Category[]> {
    return this._httpClient.get<Category[]>('http://localhost:5000/api/Categories');
  }
}


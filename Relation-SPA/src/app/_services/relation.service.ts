import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class RelationService {
  constructor(private _httpClient: HttpClient) { }



  public GetRelations() {
   return this._httpClient.get('http://localhost:5000/api/Relations');
  }


}


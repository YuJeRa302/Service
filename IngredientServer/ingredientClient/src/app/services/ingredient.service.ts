import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Ingredient} from "../ingredients";
import { isNgTemplate } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {
  
  private appUrl = environment.appUrl;
  private apiUrl = 'api/ingredients';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) { }

  getIngredientList(): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(`${this.appUrl + this.apiUrl}`);
  }

  getIngredient(id: number): Observable<Ingredient> {
    return this.http.get<Ingredient>(`${this.appUrl + this.apiUrl}/${id}`);
  }

  createIngredient(ingredient: object): Observable<Ingredient> {
    return this.http.post<Ingredient>(`${this.appUrl + this.apiUrl}`, ingredient, this.httpOptions);
  }

  updateIngredient(id: number, ingredient: object): Observable<Ingredient> {
    return this.http.put<Ingredient>(`${this.appUrl + this.apiUrl}/${id}`, ingredient, this.httpOptions);
  }

  deleteIngredient(id: number): Observable<any> {
    return this.http.delete(`${this.appUrl + this.apiUrl}/${id}`, {responseType: 'text'});
  }
}
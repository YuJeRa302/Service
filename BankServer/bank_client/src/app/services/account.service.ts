import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {BankAccount} from "../bank-account";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private appUrl = environment.appUrl;
  private apiUrl = 'api/accounts';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) { }

  getAccountList(): Observable<BankAccount[]> {
    return this.http.get<BankAccount[]>(`${this.appUrl + this.apiUrl}`);
  }

  getAccount(id: number): Observable<BankAccount> {
    return this.http.get<BankAccount>(`${this.appUrl + this.apiUrl}/${id}`);
  }

  createAccount(account: object): Observable<BankAccount> {
    return this.http.post<BankAccount>(`${this.appUrl + this.apiUrl}`, account, this.httpOptions);
  }

  updateAccount(id: number, account: object): Observable<BankAccount> {
    return this.http.put<BankAccount>(`${this.appUrl + this.apiUrl}/${id}`, account, this.httpOptions);
  }

  deleteAccount(id: number): Observable<any> {
    return this.http.delete(`${this.appUrl + this.apiUrl}/${id}`, {responseType: 'text'});
  }
}

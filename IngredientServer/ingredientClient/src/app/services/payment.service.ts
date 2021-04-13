import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  private appUrl = environment.appUrl;
  private apiUrl = 'api/payment';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) { }

  payPurchase(number: string, account: object): Observable<any> {
    return this.http.put<Account>(`${this.appUrl + this.apiUrl}/${number}`, account, this.httpOptions);
  }
}

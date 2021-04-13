import { Component, OnInit } from '@angular/core';
import {BankAccount} from "../bank-account";
import {AccountService} from "../services/account.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {AccountEditComponent} from "../account-edit/account-edit.component";

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styleUrls: ['./account-list.component.css']
})
export class AccountListComponent implements OnInit {

  accounts: BankAccount[] = [];
  account: BankAccount = new BankAccount();

  constructor(private accountService: AccountService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.loadAccounts();
  }

  loadAccounts() {
    this.accountService.getAccountList().subscribe(
      data => {
        this.accounts = data;
      },
      error => {
        console.log(error);
      });
  }

  deleteAccount(id: number) {
    this.accountService.deleteAccount(id)
      .subscribe(
        data => {
          this.loadAccounts();
        },
        error => console.log(error));
  }

  save() {
    this.accountService.createAccount(this.account).subscribe(
      data => {
        this.account = new BankAccount();
        this.loadAccounts();
      },
      error => {
        console.log(error)
      });
  }

  topUpMoney(account: BankAccount) {
    const ref = this.modalService.open(AccountEditComponent, { centered: true });
    ref.componentInstance.account = account;

    ref.result.then(() => {
        this.loadAccounts();
      },
      (cancel) => {this.loadAccounts();
      });
  }

}

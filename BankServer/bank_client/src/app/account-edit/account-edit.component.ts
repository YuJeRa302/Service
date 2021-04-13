import { Component, OnInit } from '@angular/core';
import {BankAccount} from "../bank-account";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../services/account.service";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-account-edit',
  templateUrl: './account-edit.component.html',
  styleUrls: ['./account-edit.component.css']
})
export class AccountEditComponent implements OnInit {

  account: BankAccount = new BankAccount();

  accountForm: FormGroup  = this.fb.group({
    id: [this.account.accountId, Validators.required ],
    accountNumber: [this.account.accountNumber, Validators.required ],
    accountMoney: [this.account.accountMoney, [Validators.required, Validators.pattern('^[0-9]*[.,]?[0-9]+$')]]
  });


  constructor(private accountService: AccountService,
              private fb: FormBuilder,
              public modal: NgbActiveModal) { }

  ngOnInit(): void {
    this.getAccountDetails(this.account.accountId);
  }

  getAccountDetails(id: number) {
    this.accountService.getAccount(id).subscribe(
      data => {
        this.account = data;
      },
      error => console.log(error));
  }

  updateAccount() {
    this.account.accountNumber = String(this.account.accountNumber);
    this.account.accountMoney = Number(this.account.accountMoney);

    this.accountService.updateAccount(this.account.accountId, this.account)
      .subscribe(data => {
          this.modal.close('Save');
        },
        error => {
          console.log(error)
        });
  }

  onSubmit() {
    this.updateAccount();
  }

}

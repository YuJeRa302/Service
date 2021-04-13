import { Component, OnInit } from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {PaymentService} from "../services/payment.service";
import {Account} from "../account";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  account: Account = new Account();
  totalCost: number = 0;

  paymentForm: FormGroup  = this.fb.group({
    accountNumber: ['', [Validators.required, Validators.pattern('^\\d{9}')]]
  });

  incorrectPayment = false;
  errorMessage: string = "";

  constructor(private paymentService: PaymentService,
              public modal: NgbActiveModal,
              private fb: FormBuilder) { }

  ngOnInit(): void {
    this.account.accountNumber = "000000000";
    this.account.accountMoney = -this.totalCost;
  }

  pay() {
    this.paymentService.payPurchase(this.account.accountNumber, this.account)
      .subscribe(data => {
          window.alert("Payment is successful!")
          this.modal.close('Save');
        },
        error => {
          if (error.error == "Not enough money in the account!" || error.error == "Account not found!") {
            this.incorrectPayment = true;
            this.errorMessage = error.error;
          }
          else {
            console.log(error)
          }
        });
  }

  onSubmit() {
    this.pay();
  }

}

import { Component, OnInit } from '@angular/core';
import {CartItem} from "../cartItem";
import {CartItemService} from "../services/cart-item.service";
import {PaymentComponent} from "../payment/payment.component";
import {NgbActiveModal, NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-cartshop',
  templateUrl: './cartshop.component.html',
  styleUrls: ['./cartshop.component.css']
})
export class CartshopComponent implements OnInit {

  cartItems: CartItem[] = [];
  totalCount: number = 0;
  totalCost: number = 0;

  constructor(private cartItemService: CartItemService,
              public modal: NgbActiveModal,
              private modalService: NgbModal) { }

  ngOnInit(): void {
    this.loadCartItems();
  }

  loadCartItems() {
    this.cartItemService.getCartItemList().subscribe(
      data => {
        this.cartItems = data;
        this.calculateTotalCostAndCount();
      },
      error => {
        console.log(error);
      });
  }

  deleteCartItem(id: number) {
    this.cartItemService.deleteCartItem(id)
      .subscribe(
        data => {
          this.loadCartItems();
        },
        error => console.log(error));
  }

  updateIngredient(id: number, cartItem: CartItem) {
    this.cartItemService.updateCartItem(id, cartItem)
      .subscribe(data => {
          this.loadCartItems();
        },
        error => {
          console.log(error)
        })
  };

  calculateTotalCostAndCount() {
    this.totalCost = 0;
    this.cartItems.forEach(item => {
      this.totalCost += item.ingredientPrice;
    })
  }

  moveToPayment() {
    const ref = this.modalService.open(PaymentComponent, { centered: true });
    ref.componentInstance.totalCost = this.totalCost;
    ref.result.then((result) => {
      if (result === 'Cancel') {
        this.loadCartItems();
      }
      else {
        this.modal.close('Save');
      }
      },
      (cancel) => {
        this.loadCartItems();
      });
  }
}

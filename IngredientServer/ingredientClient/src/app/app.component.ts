import { Component } from '@angular/core';
import {CartItemService} from "./services/cart-item.service";
import {Router} from "@angular/router";
import { CartshopComponent } from './cartshop/cartshop.component';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'ingredientClient';

  static cartItemsCount: number = 0;

  constructor(private cartItemService: CartItemService,
    private modalService: NgbModal,
    private router: Router) {
}
}

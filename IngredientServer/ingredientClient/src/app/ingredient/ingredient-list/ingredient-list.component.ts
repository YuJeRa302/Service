import { Component, OnInit } from '@angular/core';
import {Ingredient} from "../../ingredients";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

import { IngredientEditComponent } from '../ingredient-edit/ingredient-edit.component';
import { IngredientAddComponent } from '../ingredient-add/ingredient-add.component';
import { CartshopComponent } from '../.././cartshop/cartshop.component';
import { AppComponent } from '../../app.component';

import {CartItemService} from "../../services/cart-item.service";
import { IngredientService } from '../../services/ingredient.service';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.css']
})
export class IngredientListComponent implements OnInit {
  

  ingredients: Ingredient[] = [];
  ingredient: Ingredient = new Ingredient();

  constructor(private ingredientService: IngredientService, 
    private cartItemService: CartItemService, 
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.loadIngredient();
  }

  loadIngredient() {
    this.ingredientService.getIngredientList().subscribe(
      data => {
        this.ingredients = data;
      },
      error => {
        console.log(error);
      });
  }

  deleteIngredient(id: number) {
    this.ingredientService.deleteIngredient(id)
      .subscribe(
        data => {
          this.loadIngredient();
        },
        error => console.log(error));
  }

  save() {
    this.ingredientService.createIngredient(this.ingredient).subscribe(
      data => {
        this.ingredient = new Ingredient();
        this.loadIngredient();
      },
      error => {
        console.log(error)
      });
  }

  EditIngredient(ingredient: Ingredient) {
    const ref = this.modalService.open(IngredientEditComponent, { centered: true });
    ref.componentInstance.ingredient = ingredient;

    ref.result.then(() => {
        this.loadIngredient();
      },
      (cancel) => {this.loadIngredient();
      });
  }

  AddIngredient(ingredient: Ingredient) {
    const ref = this.modalService.open(IngredientAddComponent, { centered: true });
    ref.componentInstance.ingredient = ingredient;

    ref.result.then(() => {
        this.loadIngredient();
      },
      (cancel) => {this.loadIngredient();
      });
  }

  ShowCart(ingredient: Ingredient) {
    const ref = this.modalService.open(CartshopComponent, { centered: true });
    ref.componentInstance.ingredient = ingredient;

    ref.result.then(() => {
        this.loadIngredient();
      },
      (cancel) => {this.loadIngredient();
      });
  }

  addIngredientToCart(cartItem: { ingredientId: number;}) {
    this.cartItemService.createCartItem(cartItem).subscribe(
      data => {
        window.alert("ADD to CART!")
        window.alert("cartItem = "+cartItem.ingredientId)
      },
      error => {
        console.log(error)
      });
  }

}

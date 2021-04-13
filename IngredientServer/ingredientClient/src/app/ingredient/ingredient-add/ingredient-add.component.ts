import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

import {Ingredient} from "../../ingredients";
import { IngredientService } from '../../services/ingredient.service';

import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-ingredient-add',
  templateUrl: './ingredient-add.component.html',
  styleUrls: ['./ingredient-add.component.css']
})
export class IngredientAddComponent implements OnInit {

  ingredient: Ingredient = new Ingredient();
  
  AddingredientForm: FormGroup  = this.fb.group({
    id: [this.ingredient.ingredientId, Validators.required ],
    ingredientArticle: [this.ingredient.ingredientArticle, Validators.required ],
    ingredientName: [this.ingredient.ingredientName, Validators.required ],
    ingredientPrice: [this.ingredient.ingredientPrice, [Validators.required, Validators.pattern('^[0-9]*[.,]?[0-9]+$')]]
  });

  constructor(private ingredientService: IngredientService,
              private fb: FormBuilder,
              public modal: NgbActiveModal) { }

  ngOnInit(): void {
    this.getIngredientDetails(this.ingredient.ingredientId);
  }

  getIngredientDetails(id: number) {
    this.ingredientService.getIngredient(id).subscribe(
      data => {
        this.ingredient = data;
      },
      error => console.log(error));
  }

  updateIngredient() {

    this.ingredient.ingredientName = String(this.ingredient.ingredientName);
    this.ingredient.ingredientArticle = String(this.ingredient.ingredientArticle);
    this.ingredient.ingredientPrice = Number(this.ingredient.ingredientPrice);

    this.ingredientService.createIngredient(this.ingredient)
      .subscribe(data => {
          this.modal.close('Save');
        },
        error => {
          console.log(error)
        });
  }

  onSubmit() {
    this.updateIngredient();
  }
}

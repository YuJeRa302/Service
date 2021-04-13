import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IngredientListComponent } from './ingredient/ingredient-list/ingredient-list.component';
import { IngredientEditComponent } from './ingredient/ingredient-edit/ingredient-edit.component';
import { IngredientAddComponent } from './ingredient/ingredient-add/ingredient-add.component';

import { CartshopComponent } from './cartshop/cartshop.component';

const routes: Routes = [
  { path: '', component: IngredientListComponent, pathMatch: 'full' },
  { path: 'edit-ingredient/:id', component: IngredientEditComponent },

  { path: '', component: IngredientAddComponent, pathMatch: 'full' },
  { path: 'add-ingredient/:id', component: IngredientAddComponent },

  { path: '', component: CartshopComponent, pathMatch: 'full' },
  { path: 'cartshop/:id', component: CartshopComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

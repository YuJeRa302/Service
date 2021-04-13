import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { IngredientListComponent } from './ingredient/ingredient-list/ingredient-list.component';
import { IngredientEditComponent } from './ingredient/ingredient-edit/ingredient-edit.component';
import { IngredientAddComponent } from './ingredient/ingredient-add/ingredient-add.component';

import { CartshopComponent } from './cartshop/cartshop.component';
import { CartshopListComponent } from './cartshop/cartshop-list/cartshop-list.component';
import { PaymentComponent } from './payment/payment.component';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
    IngredientListComponent,
    IngredientEditComponent,
    CartshopComponent,
    PaymentComponent,
    CartshopListComponent,
    IngredientAddComponent
  ],
  imports: [
    AppRoutingModule,
    HttpClientModule,
    BrowserModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

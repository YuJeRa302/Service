import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountListComponent } from './account-list/account-list.component';
import { AccountEditComponent } from './account-edit/account-edit.component';

const routes: Routes = [
  { path: '', component: AccountListComponent, pathMatch: 'full' },
  { path: 'edit-account/:id', component: AccountEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

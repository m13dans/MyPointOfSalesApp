import { Routes } from '@angular/router';
import { ItemPageComponent } from './item/item-page/item-page.component';
import { SignUpComponent } from './account/signup/signup.component';
import { Login2Component } from './account/login2/login2.component';

export const routes: Routes = [
  { path: '', redirectTo: 'items', pathMatch: 'full' },
  { path: 'items', component: ItemPageComponent },
  { path: 'signup', component: SignUpComponent },
  { path: 'login', component: Login2Component },
  // { path: 'account', component: AccountPageComponent, title: 'account' },
];

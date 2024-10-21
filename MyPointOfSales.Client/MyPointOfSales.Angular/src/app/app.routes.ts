import { Routes } from '@angular/router';
import { ItemsHomePageComponent } from './page/items/items-home-page/items-home-page.component';

export const routes: Routes = [
  { path: 'items', component: ItemsHomePageComponent, title: 'items-list' },
];

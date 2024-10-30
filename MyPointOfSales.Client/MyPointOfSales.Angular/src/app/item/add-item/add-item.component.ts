import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
    selector: 'app-add-item',
    standalone: true,
    imports: [
        CommonModule,
    ],
    templateUrl: './add-item.component.html',
    styles: `
    :host {
      display: block;
    }
  `,
})
export class AddItemComponent { }

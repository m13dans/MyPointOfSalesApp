import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
    selector: 'app-items-add-page',
    standalone: true,
    imports: [
        CommonModule,
    ],
    templateUrl: './items-add-page.component.html',
    styleUrl: './items-add-page.component.css',
})
export class ItemsAddPageComponent { }

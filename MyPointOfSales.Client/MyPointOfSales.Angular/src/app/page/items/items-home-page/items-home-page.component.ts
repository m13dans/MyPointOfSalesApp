import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
    selector: 'app-items-home-page',
    standalone: true,
    imports: [
        CommonModule,
    ],
    templateUrl: './items-home-page.component.html',
    styleUrl: './items-home-page.component.css',
})
export class ItemsHomePageComponent { }

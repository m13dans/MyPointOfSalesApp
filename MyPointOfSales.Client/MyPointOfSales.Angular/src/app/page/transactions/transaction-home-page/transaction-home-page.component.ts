import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
    selector: 'app-transaction-home-page',
    standalone: true,
    imports: [
        CommonModule,
    ],
    templateUrl: './transaction-home-page.component.html',
    styleUrl: './transaction-home-page.component.css',
})
export class TransactionHomePageComponent { }

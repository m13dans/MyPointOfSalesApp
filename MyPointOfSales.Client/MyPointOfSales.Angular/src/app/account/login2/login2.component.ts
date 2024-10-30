import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-login2',
  standalone: true,
  imports: [CommonModule, CardModule, InputTextModule],
  templateUrl: './login2.component.html',
  styles: `
    :host {
      display: block;
    }
  `,
})
export class Login2Component {}

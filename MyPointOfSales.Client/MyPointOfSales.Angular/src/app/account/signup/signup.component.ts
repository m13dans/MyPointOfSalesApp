import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ButtonModule,
    CardModule,
    InputTextModule,
    FloatLabelModule,
  ],
  templateUrl: './signup.component.html',
  styles: `
    :host {
      display: block;
    }
  `,
})
export class SignUpComponent {
  username = 'arya';
}

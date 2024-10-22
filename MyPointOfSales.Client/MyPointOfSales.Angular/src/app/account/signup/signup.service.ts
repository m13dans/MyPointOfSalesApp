import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { SignUpModel } from './signup.model';

@Injectable({
  providedIn: 'root',
})
export class SignUpService {
  private http = inject(HttpClient);

  post(signupModel: SignUpModel) {
    return this.http.post('https://localhost:7260', signupModel);
  }
}

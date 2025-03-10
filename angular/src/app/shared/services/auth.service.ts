import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  constructor() {}

  // Retrieve the token from localStorage or your preferred method
  getToken(): string | null {
    return localStorage.getItem('authToken'); // You can adjust this to your application's needs
  }
}

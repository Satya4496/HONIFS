import { Component } from '@angular/core';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  model: any = {
    userName: '',
    email: '',
    password: '',
    confirmPassword: '',
  };

  constructor(private accountService: AccountService, private router: Router) {}

  onRegister() {
    // Call the API to register the user
    this.accountService
      .register({
        userName: this.model.userName,
        email: this.model.email,
        password: this.model.password,
      })
      .subscribe(
        (result) => {
          // On success, redirect to login page or dashboard
          this.router.navigate(['/account/login']);
        },
        (error) => {
          console.error('Error during registration', error);
        }
      );
  }
}


import { Component } from '@angular/core';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
   styleUrl: './register.component.scss'
})
export class RegisterComponent {
  tenantTypes = ['Building', 'Department'];
  model: any = {
    firstName: '',
    lastName: '',
    userName: '',
    email: '',
    password: '',
    contact: '',
    address: '',
    tenantName: '',
    tenantType: '',
  };

  constructor(private accountService: AccountService, private router: Router) {}

  onRegister() {
    // Call the API to register the user
    this.accountService
      .register({
        firstName: this.model.firstName,
        lastName: this.model.lastName,
        userName: this.model.userName,
        email: this.model.email,
        password: this.model.password,
        contact: this.model.phoneNo,
        address: this.model.address,
        tenantName: this.model.tenantName,
        tenantType: this.model.tenantType,
      })
      .subscribe(
        result => {
          // On success, redirect to login page or dashboard
          this.router.navigate(['/account/login']);
        },
        error => {
          console.error('Error during registration', error);
        }
      );
  }
}

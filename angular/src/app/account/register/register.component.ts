import { Component } from '@angular/core';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  tenantTypes = ['Building', 'Department'];
  offeringName = '';
  model: any = {
    firstName: '',
    lastName: '',
    userName: '',
    email: '',
    contact: '',
    address: '',
    tenantName: '',
    type: '',
  };

  constructor(
    private accountService: AccountService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    // Subscribe to the queryParams observable
    this.route.queryParams.subscribe(params => {
      // Access query parameters
      this.offeringName = params['offeringName']; // e.g., 'John'
    });
  }

  onRegister() {
    // Call the API to register the user
    this.accountService
      .register({
        firstName: this.model.firstName,
        lastName: this.model.lastName,
        userName: this.model.userName,
        email: this.model.email,
        contact: this.model.contactNumber,
        address: this.model.address,
        tenantName: this.model.tenantName,
        type: this.offeringName=='building' ? 1 : 2,
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

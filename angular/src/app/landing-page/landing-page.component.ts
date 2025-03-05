import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.scss'
})
export class LandingPageComponent {

  constructor(private router: Router) {}
   // Mock data for offerings
   offerings = [
    { id: 1, name: 'Building Services', description: 'A basic offering with essential features',path: 'building' },
    { id: 2, name: 'Department Services', description: 'A premium offering with additional features', path:'department' }
  ];

  navigateToRegister(offeringPath): void {
    this.router.navigate([`${offeringPath}/account/registration`], {
      queryParams: { returnUrl: '', offeringName: offeringPath }  // Remove the returnUrl completely
    });  // Default ABP registration URL
  }

  navigateToLogin(): void {
    this.router.navigate(['/account/login'], {
      queryParams: { returnUrl: '/home' }  // Remove the returnUrl completely
    });  // Default ABP registration URL
  }
}

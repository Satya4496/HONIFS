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
    { id: 1, name: 'Building Services', description: 'A basic offering with essential features' },
    { id: 2, name: 'Department Services', description: 'A premium offering with additional features' }
  ];

  navigateToRegister(): void {
    this.router.navigate(['/account/registration'], {
      queryParams: { returnUrl: '' }  // Remove the returnUrl completely
    });  // Default ABP registration URL
  }

  navigateToLogin(): void {
    this.router.navigate(['/account/login'], {
      queryParams: { returnUrl: '' }  // Remove the returnUrl completely
    });  // Default ABP registration URL
  }
}

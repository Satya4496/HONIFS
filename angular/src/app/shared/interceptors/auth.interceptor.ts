import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service'; // You can modify this import to your actual Auth service

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  // Inject your AuthService or any service that provides the token
  private authService = inject(AuthService);

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Get the authentication token from the service or localStorage
    const token = this.authService.getToken(); // You might get it from a service or localStorage

    // If the token exists, clone the request and add the Authorization header
    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    // Pass the cloned request with the Authorization header attached
    return next.handle(request);
  }
}


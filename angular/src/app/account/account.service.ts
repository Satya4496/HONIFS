import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) {}

  register(registerDto: any): Observable<any> {
    return this.http.post('/api/app/leads', registerDto);
  }
}

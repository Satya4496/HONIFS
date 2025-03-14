import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) {}

  register(registerDto: any): Observable<any> {
    return this.http.post(environment.apis.default.url+'/api/app/leads', registerDto);
  }
}

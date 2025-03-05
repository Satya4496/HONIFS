import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PagedResultDto } from '@abp/ng.core';
import { Observable } from 'rxjs';
import { TenantRequest } from '../models/tenant-request';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor(private http: HttpClient) {}

  getData(skipCount: number, maxResultCount: number): Observable<PagedResultDto<TenantRequest>> {
    return this.http.get<PagedResultDto<TenantRequest>>(`/api/data/getAll?SkipCount=${skipCount}&MaxResultCount=${maxResultCount}`);
  }
}


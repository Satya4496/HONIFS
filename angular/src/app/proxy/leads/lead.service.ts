import type {
  GetLeadsInput,
  LeadCreateDto,
  LeadDto,
  LeadExcelDownloadDto,
  LeadUpdateDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AppFileDescriptorDto, DownloadTokenResultDto, GetFileInput } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class LeadService {
  apiName = 'Default';

  create = (input: LeadCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LeadDto>(
      {
        method: 'POST',
        url: '/api/app/leads',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/leads/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetLeadsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/leads/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          firstName: input.firstName,
          lastName: input.lastName,
          userName: input.userName,
          email: input.email,
          contact: input.contact,
          address: input.address,
          tenantName: input.tenantName,
          type: input.type,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (leadIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/leads',
        params: { leadIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LeadDto>(
      {
        method: 'GET',
        url: `/api/app/leads/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/leads/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/leads/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetLeadsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LeadDto>>(
      {
        method: 'GET',
        url: '/api/app/leads',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          firstName: input.firstName,
          lastName: input.lastName,
          userName: input.userName,
          email: input.email,
          contact: input.contact,
          address: input.address,
          tenantName: input.tenantName,
          type: input.type,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: LeadExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/leads/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          firstName: input.firstName,
          lastName: input.lastName,
          userName: input.userName,
          email: input.email,
          contact: input.contact,
          address: input.address,
          tenantName: input.tenantName,
          type: input.type,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: LeadUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LeadDto>(
      {
        method: 'PUT',
        url: `/api/app/leads/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/leads/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}

import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { LeadType } from './lead-type.enum';

export interface GetLeadsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  firstName?: string;
  lastName?: string;
  userName?: string;
  email?: string;
  contact?: string;
  address?: string;
  tenantName?: string;
  type?: LeadType;
}

export interface LeadCreateDto {
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  contact: string;
  address?: string;
  tenantName: string;
  type: LeadType;
}

export interface LeadDto extends FullAuditedEntityDto<string> {
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  contact: string;
  address?: string;
  tenantName: string;
  type: LeadType;
  concurrencyStamp?: string;
}

export interface LeadExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  firstName?: string;
  lastName?: string;
  userName?: string;
  email?: string;
  contact?: string;
  address?: string;
  tenantName?: string;
  type?: LeadType;
}

export interface LeadUpdateDto {
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  contact: string;
  address?: string;
  tenantName: string;
  type: LeadType;
  concurrencyStamp?: string;
}

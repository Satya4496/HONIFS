import { mapEnumToOptions } from '@abp/ng.core';

export enum LeadType {
  Undefined = 0,
  Building = 1,
  Department = 2,
}

export const leadTypeOptions = mapEnumToOptions(LeadType);

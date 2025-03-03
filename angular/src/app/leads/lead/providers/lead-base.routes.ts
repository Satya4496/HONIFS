import { ABP, eLayoutType } from '@abp/ng.core';

export const LEAD_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/leads',
    iconClass: 'fas fa-file-alt',
    name: '::Menu:Leads',
    layout: eLayoutType.application,
    requiredPolicy: 'HONIFS.Leads',
    breadcrumbText: '::Leads',
  },
];

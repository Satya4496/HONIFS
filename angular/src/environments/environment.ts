 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44350/',
  redirectUri: baseUrl+'/home',
  clientId: 'HONIFS_App',
  responseType: 'code',
  scope: 'offline_access HONIFS',
  requireHttps: true,
  impersonation: {
    tenantImpersonation: true,
    userImpersonation: true,
  }
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'HONIFS',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44350',
      rootNamespace: 'HONIFS',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;

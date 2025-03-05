import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'HONIFS.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'HONIFS.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}

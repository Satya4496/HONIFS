import { Component } from '@angular/core';
import { PagedResultDto } from '@abp/ng.core';
import { DataService } from '../shared/services/data.service';
import { TenantRequest } from '../shared/models/tenant-request';

@Component({
  selector: 'app-admin-tenant-requests',
  templateUrl: './admin-tenant-requests.component.html',
  styleUrl: './admin-tenant-requests.component.scss'
})
export class AdminTenantRequestsComponent {
  columns = [
    { name: 'Tenant Name', prop: 'tenantName' },
    { name: 'Tenant Type', prop: 'tenantType' },
    { name: 'User Name', prop: 'userName' },
    { name: 'Email', prop: 'email' }
  ];

  tableData: TenantRequest[] = [];  // Store the data to be displayed
  totalCount: number = 0;  // Total number of records in the backend
  currentPage: number = 1;  // Current page (1-based index)
  pageSize: number = 10;  // Number of items per page
  showActionsColumn = true;
  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.loadTableData();
  }

  loadTableData(): void {
    // Fetch data based on current page and page size
    // this.dataService
    //   .getData((this.currentPage - 1) * this.pageSize, this.pageSize)
    //   .subscribe((result: PagedResultDto<TenantRequest>) => {
    //     this.tableData = result.items; 
    //     this.totalCount = result.totalCount; // Assign data to tableData
        
    //       // Total record count for pagination
    //   });
      this.tableData = [
        { tenantName: 'Prestige Group',  tenantType: 'building', email: 'prestige.group@gmail.com', userName:'prestige' },
        { tenantName: 'Sattva Builders',  tenantType: 'building', email: 'sattva@gmail.com', userName:'sattva' },
        { tenantName: 'Seattle Fire Department',  tenantType: 'department', email: 'seattle.fire@gmail.com', userName:'Seattle_Fire' },
        { tenantName: 'Newyork Fire Department',  tenantType: 'department', email: 'newyork.fire@gmail.com', userName:'Newyork_Fire' }
      ];
      this.totalCount = 4
  }

  onPageChange(event: any): void {
    this.currentPage = event.offset + 1;  // Set current page based on pagination offset
    this.loadTableData();  // Reload data for the new page
  }

  onButtonClick(row: any) {
    console.log('Button clicked for:', row);
    // You can navigate or perform any action you want with the clicked row data
  }
}

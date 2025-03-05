import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminTenantRequestsComponent } from './admin-tenant-requests.component';

describe('AdminTenantRequestsComponent', () => {
  let component: AdminTenantRequestsComponent;
  let fixture: ComponentFixture<AdminTenantRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminTenantRequestsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminTenantRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

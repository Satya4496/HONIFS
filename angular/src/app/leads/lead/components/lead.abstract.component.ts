import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import { leadTypeOptions } from '../../../proxy/leads/lead-type.enum';
import type { LeadDto } from '../../../proxy/leads/models';
import { LeadViewService } from '../services/lead.service';
import { LeadDetailViewService } from '../services/lead-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractLeadComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(LeadViewService);
  public readonly serviceDetail = inject(LeadDetailViewService);
  protected title = '::Leads';

  leadTypeOptions = leadTypeOptions;

  ngOnInit() {
    this.service.hookToQuery();
  }

  clearFilters() {
    this.service.clearFilters();
  }

  showForm() {
    this.serviceDetail.showForm();
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: LeadDto) {
    this.serviceDetail.update(record);
  }

  delete(record: LeadDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }
}

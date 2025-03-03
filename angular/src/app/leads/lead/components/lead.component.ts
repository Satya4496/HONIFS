import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  NgbDateAdapter,
  NgbTimeAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { leadTypeOptions } from '../../../proxy/leads/lead-type.enum';
import { LeadViewService } from '../services/lead.service';
import { LeadDetailViewService } from '../services/lead-detail.service';
import { LeadDetailModalComponent } from './lead-detail.component';
import {
  AbstractLeadComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './lead.abstract.component';

@Component({
  selector: 'app-lead',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,

    NgxValidateCoreModule,

    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    LeadDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    LeadViewService,
    LeadDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './lead.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class LeadComponent extends AbstractLeadComponent {}

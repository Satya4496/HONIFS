import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import { leadTypeOptions } from '../../../proxy/leads/lead-type.enum';
import type { LeadDto } from '../../../proxy/leads/models';
import { LeadService } from '../../../proxy/leads/lead.service';

export abstract class AbstractLeadDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(LeadService);
  public readonly list = inject(ListService);

  leadTypeOptions = leadTypeOptions;

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.id, {
        ...formValues,
        concurrencyStamp: this.selected.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const { firstName, lastName, userName, email, contact, address, tenantName, type } =
      this.selected || {};

    this.form = this.fb.group({
      firstName: [firstName ?? null, [Validators.required]],
      lastName: [lastName ?? null, [Validators.required]],
      userName: [userName ?? null, [Validators.required]],
      email: [email ?? null, [Validators.required]],
      contact: [contact ?? null, [Validators.required]],
      address: [address ?? null, []],
      tenantName: [tenantName ?? null, [Validators.required]],
      type: [type ?? null, [Validators.required]],
    });
  }

  showForm() {
    this.buildForm();
    this.isVisible = true;
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: LeadDto) {
    this.selected = record;
    this.showForm();
  }

  hideForm() {
    this.isVisible = false;
  }

  submitForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = this.createRequest().pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm()),
    );

    request.subscribe(this.list.get);
  }

  changeVisible($event: boolean) {
    this.isVisible = $event;
  }
}

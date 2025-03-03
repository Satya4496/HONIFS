import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { LEAD_BASE_ROUTES } from './lead-base.routes';

export const LEADS_LEAD_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...LEAD_BASE_ROUTES];
    routesService.add(routes);
  };
}

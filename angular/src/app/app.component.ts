import { AuthService, ReplaceableComponentsService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { eThemeLeptonXComponents } from '@volosoft/abp.ng.theme.lepton-x';
import { NoSidebarLayoutComponent } from './shared/layouts/no-sidebar-layout/no-sidebar-layout.component';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  template: `
    <ng-container>
      <abp-loader-bar></abp-loader-bar>
      <ng-container *ngIf="layout">
        <ng-container
          *ngComponentOutlet="layout"
        ></ng-container>
      </ng-container>
      <abp-gdpr-cookie-consent></abp-gdpr-cookie-consent>
    </ng-container>
  `,
})
export class AppComponent {
  layout: any = this.replaceableComponents.get(eThemeLeptonXComponents.ApplicationLayout)?.component;

  constructor(private router: Router,public replaceableComponents: ReplaceableComponentsService) {
    // Listen for route changes to set the layout dynamically
    this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(() => {
      const layoutType = this.router.routerState.snapshot.root.firstChild?.data['layout'];
      layoutType === 'no-sidebar' ? this.layout = NoSidebarLayoutComponent :this.layout;
      
    });
  }

  // constructor(
  //   public replaceableComponents: ReplaceableComponentsService, // injected the service
  //   private router: Router
  // ) {}

  // ngOnInit() {
  //   this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(() => {
  //     const currentRoute = this.router.routerState.snapshot.url;
  //     console.log('Current Route:', currentRoute);

  //     if (currentRoute.includes('landing-page')) {
  //       console.log(this.replaceableComponents.get(eThemeLeptonXComponents.ApplicationLayout));
  //       this.replaceableComponents.add({
  //         component: NoSidebarLayoutComponent,
  //         key: eThemeLeptonXComponents.ApplicationLayout,
  //       });
  //       console.log(this.replaceableComponents.get(eThemeLeptonXComponents.ApplicationLayout));
  //     }
  //     // else {
  //     //   this.replaceableComponents.add({
  //     //     component: MainLayoutComponent,
  //     //     key: eThemeLeptonXComponents.ApplicationLayout
  //     //   });
  //     // }
  //   });
  // }
}

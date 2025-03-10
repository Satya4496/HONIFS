import { NgModule } from '@angular/core';
    import { CommonModule } from '@angular/common';
    import { LoginComponent } from './login/login.component';
    import { CoreModule } from '@abp/ng.core';
    import { ThemeSharedModule } from '@abp/ng.theme.shared';
    import { AccountLayoutComponent } from '../shared/layouts/account-layout/account-layout.component';  
    @NgModule({
    declarations: [
    LoginComponent,
    AccountLayoutComponent
    ],
    imports: [
    CommonModule,
    CoreModule, 
    ThemeSharedModule
    ],
    exports: [LoginComponent, AccountLayoutComponent]
    })
    export class AccountModule { } 
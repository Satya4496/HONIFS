import { Component, OnInit } from '@angular/core';
    import { AuthWrapperService } from '@volo/abp.ng.account.core';
    @Component({
    selector: 'app-account-layout',
    templateUrl: './account-layout.component.html',
    styleUrls: ['./account-layout.component.scss'],
    providers: [AuthWrapperService],
    })
    export class AccountLayoutComponent implements OnInit {
    constructor(
    public authWrapperService: AuthWrapperService,
    ) { }
    ngOnInit(): void {
    }
    }
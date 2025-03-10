import { AuthService, ConfigStateService } from '@abp/ng.core';
import { ToasterService } from '@abp/ng.theme.shared';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  eAccountComponents,
  getRedirectUrl,
  RecaptchaService,
  RECAPTCHA_STRATEGY,
  SecurityCodeData,
  SecurityCodeService,
} from '@volo/abp.ng.account/public';
import { IdentityLinkUserService, LinkUserInput } from '@volo/abp.ng.account/public/proxy';
import { of, pipe, throwError } from 'rxjs';
import { catchError, finalize, switchMap, tap } from 'rxjs/operators';

const { maxLength, required } = Validators;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [RecaptchaService],
})
export class LoginComponent implements OnInit, AfterViewInit {
  @ViewChild('recaptcha', { static: false })
  recaptchaRef: ElementRef;

  form: FormGroup;

  inProgress: boolean;

  isSelfRegistrationEnabled = true;

  authWrapperKey = eAccountComponents.AuthWrapper;

  linkUser: LinkUserInput;

  protected fb: FormBuilder;
  protected toasterService: ToasterService;
  protected authService: AuthService;
  protected configState: ConfigStateService;
  protected route: ActivatedRoute;
  protected router: Router;
  protected identityLinkUserService: IdentityLinkUserService;
  protected recaptchaService: RecaptchaService;
  protected securityCodeService: SecurityCodeService;

  constructor(protected injector: Injector) {
    this.fb = injector.get(FormBuilder);
    this.toasterService = injector.get(ToasterService);
    this.authService = injector.get(AuthService);
    this.configState = injector.get(ConfigStateService);
    this.route = injector.get(ActivatedRoute);
    this.router = injector.get(Router);
    this.identityLinkUserService = injector.get(IdentityLinkUserService);
    this.recaptchaService = injector.get(RecaptchaService);
    this.securityCodeService = injector.get(SecurityCodeService);
  }

  ngOnInit() {
    this.init();
    this.buildForm();
    this.setLinkUserParams();
  }

  ngAfterViewInit() {
    this.recaptchaService.setStrategy(
      RECAPTCHA_STRATEGY.Login(this.configState, this.recaptchaRef.nativeElement)
    );
  }

  protected setLinkUserParams() {
    const {
      linkUserId: userId,
      linkToken: token,
      linkTenantId: tenantId,
    } = this.route.snapshot.queryParams;

    if (userId && token) {
      this.identityLinkUserService.verifyLinkToken({ token, userId, tenantId }).subscribe(res => {
        if (res) {
          this.linkUser = { userId, token, tenantId };
        }
      });
    }
  }

  protected init() {
    this.isSelfRegistrationEnabled =
      (
        (this.configState.getSetting('Abp.Account.IsSelfRegistrationEnabled') as string) || ''
      ).toLowerCase() !== 'false';
  }

  protected buildForm() {
    this.form = this.fb.group({
      username: ['', [required, maxLength(255)]],
      password: ['', [required, maxLength(128)]],
      rememberMe: [false],
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    this.inProgress = true;

    const { username, password, rememberMe } = this.form.value;
    const redirectUrl = getRedirectUrl(this.injector) || (this.linkUser ? null : '/');
    const loginParams = { username, password, rememberMe, redirectUrl };

    (this.recaptchaService.isEnabled ? this.recaptchaService.validate() : of(true))
      .pipe(
        switchMap(isValid =>
          isValid
            ? this.authService
                .login(loginParams)
                .pipe(this.handleLoginError(loginParams))
                .pipe(this.linkUser ? this.switchToLinkUser() : tap())
            : of(null)
        ),
        finalize(() => (this.inProgress = false))
      )
      .subscribe();
  }

  private switchToLinkUser() {
    return pipe(
      switchMap(() => this.identityLinkUserService.link(this.linkUser)),
      tap(() => {
        this.router.navigate(['/account/link-logged'], {
          queryParams: this.route.snapshot.queryParams,
        });
      })
    );
  }

  private handleLoginError(loginParams?: Omit<SecurityCodeData, 'twoFactorToken' | 'userId'>) {
    return catchError(err => {
      if (err.error?.error_description === 'RequiresTwoFactor') {
        this.securityCodeService.data = {
          ...loginParams,
          twoFactorToken: err.error.twoFactorToken,
          userId: err.error.userId,
        };
        this.router.navigate(['/account/send-security-code']);
        return of();
      }

      this.recaptchaService.reset();
      this.toasterService.error(
        err.error?.error_description ||
          err.error?.error?.message ||
          'AbpAccount::DefaultErrorMessage',
        null,
        { life: 7000 }
      );
      return throwError(err);
    });
  }
}

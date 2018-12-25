import { Component, Inject, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { SettingsService } from '@yoyo/theme';
import { AppComponentBase } from '@shared/component-base';
import { AppAuthService } from '@shared/auth/app-auth.service';
import { ChangePasswordComponent } from '../change-password/change-password.component';
import { CreateRoleComponent } from '@app/roles/create-role/create-role.component';

@Component({
  selector: 'header-user',
  template: `
  <nz-dropdown nzPlacement="bottomRight">
    <div class="alain-default__nav-item d-flex align-items-center px-sm" nz-dropdown>
      <nz-avatar  nzSize="small" class="mr-sm"></nz-avatar>
      
    </div>
    <div nz-menu class="width-sm">

      <div nz-menu-item  (click)="changePassword()">
        <i nz-icon type="edit" class="mr-sm"></i>
        {{l("ChangePassword")}}
      </div>
      <li nz-menu-divider></li>
      <div nz-menu-item (click)="logout()">
        <i nz-icon type="logout" class="mr-sm"></i>
        {{l('Logout')}}
      </div>
    </div>
  </nz-dropdown>
  `,
})
export class HeaderUserComponent extends AppComponentBase {

  constructor(
    injector: Injector,
    private _authService: AppAuthService
  ) {
    super(injector);
  }

  logout(): void {
    this._authService.logout();
  }
  changePassword(): void {
    //
    this.modalHelper
      .open(ChangePasswordComponent, {}, 'md', {
        nzMask: true,
        nzClosable: false,
      })
      .subscribe(isSave => {

      });
  }
}


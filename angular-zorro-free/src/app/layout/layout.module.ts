import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { HeaderComponent } from './default/header/header.component';
import { SidebarComponent } from './default/sidebar/sidebar.component';
import { HeaderFullScreenComponent } from './default/header/components/fullscreen.component';
import { HeaderI18nComponent } from './default/header/components/i18n.component';
import { HeaderStorageComponent } from './default/header/components/storage.component';
import { HeaderUserComponent } from './default/header/components/user.component';
import { ChangePasswordComponent } from './default/header/change-password/change-password.component';
import { CommonModule } from '@angular/common';
import { AppComponent } from '@app/app.component';
import { LocalizationService } from 'yoyo-ng-module/src/abp';

const COMPONENTS = [
  HeaderComponent,
  SidebarComponent,
  ChangePasswordComponent,
];

const HEADERCOMPONENTS = [
  HeaderFullScreenComponent,
  HeaderI18nComponent,
  HeaderStorageComponent,
  HeaderUserComponent,
];
const Entry = [
  AppComponent,
  ChangePasswordComponent,

]

// passport


@NgModule({
  imports: [SharedModule],
  declarations: [...COMPONENTS, ...HEADERCOMPONENTS,],
  entryComponents: [...Entry],
  exports: [...COMPONENTS],
  providers: [LocalizationService],
})
export class LayoutModule { }

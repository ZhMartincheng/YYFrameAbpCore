import { Injector, ElementRef } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppSessionService } from '@shared/session/app-session.service';
import { NotifyService, SettingService, MessageService, LocalizationService, AbpMultiTenancyService, FeatureCheckerService, PermissionCheckerService } from '@yoyo/abp';
import { ModalHelper } from '@yoyo/theme';
import { Data } from '@angular/router';

export abstract class AppComponentBase {
  localizationSourceName = AppConsts.localization.defaultLocalizationSourceName;

  localization: LocalizationService;
  permission: PermissionCheckerService;
  feature: FeatureCheckerService;
  notify: NotifyService;
  setting: SettingService;
  message: MessageService;
  multiTenancy: AbpMultiTenancyService;
  appSession: AppSessionService;
  elementRef: ElementRef;
  modalHelper: ModalHelper;

  /**
   * 保存状态
   */
  saving = false;

  constructor(injector: Injector) {
    this.localization = injector.get(LocalizationService);
    this.permission = injector.get(PermissionCheckerService);
    this.feature = injector.get(FeatureCheckerService);
    this.notify = injector.get(NotifyService);
    this.setting = injector.get(SettingService);
    this.message = injector.get(MessageService);
    this.multiTenancy = injector.get(AbpMultiTenancyService);
    this.appSession = injector.get(AppSessionService);
    this.elementRef = injector.get(ElementRef);
    this.modalHelper = injector.get(ModalHelper);
  }

  l(key: string, ...args: any[]): string {
    let localizedText = this.localization.localize(
      key,
      this.localizationSourceName,
    );

    if (!localizedText) {
      localizedText = key;
    }

    if (!args || !args.length) {
      return localizedText;
    }

    args.unshift(localizedText);
    return abp.utils.formatString.apply(this, args);
  }

  isGranted(permissionName: string): boolean {
    return this.permission.isGranted(permissionName);
  }

  dateFormat(date: any): Data {
    if (date === null) {
      return null;
    }
    let d = new Date(date);
    let y = d.getFullYear().toString();
    let m = (d.getMonth() + 1).toString();
    let day = d.getDate().toString();
    // return y + '-' + m + '-' + day;
    //return d;
    let data = y + '-' + m + '-' + day;
    return new Date(data.replace(/-/g, "/"));
    // let dateStr:string = this.datePipe.transform(d,'yyyy-MM-dd');
    // return dateStr;
  }
}

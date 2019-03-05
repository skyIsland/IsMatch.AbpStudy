import { state } from '@angular/animations';
import {
  NzModalService,
  NzNotificationService,
  NzNotificationDataOptions,
  NzMessageService,
} from 'ng-zorro-antd';
import { parse } from 'date-fns';

export class AppConsts {
  static remoteServiceBaseUrl: string;

  static appBaseUrl: string;
  static uploadApiUrl = '/api/File/Upload';

  static readonly userManagement = {
    defaultAdminUserName: 'admin',
  };

  static readonly localization = {
    defaultLocalizationSourceName: 'AbpStudy',
  };

  static readonly authorization = {
    encrptedAuthTokenName: 'enc_auth_token',
  }

  /**
   * ??????????????????
   */
  // tslint:disable-next-line:member-ordering
  static readonly grid = {
    /**
     * ?????????????????????
     */
    defaultPageSize: 10,
    /**
     * ?????????????????????????????????
     */
    defaultPageSizes: [5, 10, 15, 20, 25, 30, 50, 80, 100],
  };
}

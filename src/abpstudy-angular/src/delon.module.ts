/**
 * ???????????????????????????????????????
 * ??????????????????????????????????????????https://github.com/ng-alain/ng-alain/issues/180
 */
import {
  NgModule,
  Optional,
  SkipSelf,
  ModuleWithProviders,
} from '@angular/core';
import { throwIfAlreadyLoaded } from '@shared/module-import-guard';

import { AlainThemeModule } from '@delon/theme';
import { DelonABCModule, STConfig } from '@delon/abc';
import { DelonChartModule } from '@delon/chart';
import { DelonACLModule } from '@delon/acl';
import { DelonCacheModule } from '@delon/cache';
import { DelonUtilModule } from '@delon/util';

// #region mock
import { DelonMockModule } from '@delon/mock';
import * as MOCKDATA from '../_mock';
import { environment } from '@env/environment';
const MOCK_MODULES = !environment.production
  ? [DelonMockModule.forRoot({ data: MOCKDATA })]
  : [];
// #endregion

// #region reuse-tab
/**
 * ?????????[????????????](https://ng-alain.com/components/reuse-tab)?????????
 * 1????????? `REUSETAB_PROVIDES`
 * 2?????? `src/app/layout/default/default.component.html` ?????????
 *  ```html
 *  <section class="alain-default__content">
 *    <reuse-tab></reuse-tab>
 *    <router-outlet></router-outlet>
 *  </section>
 *  ```
 */
import { RouteReuseStrategy } from '@angular/router';
import { ReuseTabService, ReuseTabStrategy } from '@delon/abc/reuse-tab';
const REUSETAB_PROVIDES = [
  {
    provide: RouteReuseStrategy,
    useClass: ReuseTabStrategy,
    deps: [ReuseTabService],
  },
];
// #endregion

// #region global config functions

import { PageHeaderConfig } from '@delon/abc';
export function fnPageHeaderConfig(): PageHeaderConfig {
  return Object.assign(new PageHeaderConfig(), { homeI18n: '??????' });
}



export function fnSTConfig(): STConfig {
  return Object.assign(new STConfig(), <STConfig>{
    modal: { size: 'lg' },
  });
}

const GLOBAL_CONFIG_PROVIDES = [
  // TIPS???@delon/abc ??????????????????????????????????????????????????? `st` ?????????????????? `20` ???
  { provide: STConfig, useFactory: fnSTConfig },
  { provide: PageHeaderConfig, useFactory: fnPageHeaderConfig },
];

// #endregion

@NgModule({
  imports: [
    AlainThemeModule.forRoot(),
    DelonABCModule.forRoot(),
    DelonChartModule.forRoot(),
    DelonACLModule.forRoot(),
    DelonCacheModule.forRoot(),
    DelonUtilModule.forRoot(),
    // mock
    //...MOCK_MODULES,
  ],
})
export class DelonModule {
  constructor(
    @Optional()
    @SkipSelf()
    parentModule: DelonModule,
  ) {
    throwIfAlreadyLoaded(parentModule, 'DelonModule');
  }

  static forRoot(): ModuleWithProviders {
    return {
      ngModule: DelonModule,
      providers: [...REUSETAB_PROVIDES, ...GLOBAL_CONFIG_PROVIDES],
    };
  }
}
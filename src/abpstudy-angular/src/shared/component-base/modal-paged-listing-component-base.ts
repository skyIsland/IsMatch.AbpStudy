import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import { Component, OnInit, Injector } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import {
  PagedResultDto,
  PagedRequestDto,
} from '@shared/component-base/paged-listing-component-base';

export abstract class ModalPagedListingComponentBase<EntityDto>
  extends ModalComponentBase
  implements OnInit {
  /**
   * ?????????????????????
   */
  dataList: EntityDto[] = [];

  //#region ????????????

  /**
   * ????????????
   */
  public pageSize = AppConsts.grid.defaultPageSize;

  /**
   * ?????????
   */ public pageNumber = 1;
  /**
   * ?????????
   */
  public totalPages = 1;
  /**
   * ????????????
   */
  public totalItems: number;

  /**
   * ??????
   */
  public sorting: string = undefined;
  /**
   * ?????????????????????
   */
  filterText = '';

  //#endregion

  //#region ??????????????????
  /**
   * ???????????????
   */
  public isTableLoading = false;
  //#endregion

  //#region Checkbox?????????

  /**
   * ??????????????????
   */
  public allChecked = false;

  /**
   * ?????????????????????
   */
  public allCheckboxDisabled = false;
  /**
   * ?????????????????????????????????????????????????????????
   */
  public checkboxIndeterminate = false;

  /**
   * ????????????????????????
   */
  public selectedDataItems: any[] = [];

  //#endregion

  /**
   * ????????????
   * @param injector ?????????
   * @param nzModalRef (optional) nzModal ???????????????????????????????????????????????????modal?????????????????????????????????modal?????????????????????null??????????????????????????????nzModalRef????????????nzModalComponent????????????
   */
  constructor(injector: Injector) {
    super(injector);
  }

  /**
   * ????????????ngOnInit????????????????????????
   */
  ngOnInit(): void {
    this.refresh();
  }
  /**
   * ???????????????????????????
   */
  refresh(): void {
    this.restCheckStatus(this.dataList);
    this.getDataPage(this.pageNumber);
  }
  /**
   * ??????????????????????????????????????????`pageNumber = 1`???
   */
  refreshGoFirstPage(): void {
    this.pageNumber = 1;
    this.restCheckStatus(this.dataList);
    this.getDataPage(this.pageNumber);
  }

  //#region ????????????????????????

  //#endregion

  //#region ?????????????????????????????????

  /**
   * ????????????
   * @param result ????????????Dto
   *
   */
  public showPaging(result: PagedResultDto): void {
    this.totalItems = result.totalCount;
  }

  /**
   * ?????????????????????
   * @param page ????????????
   */
  public getDataPage(page: number): void {
    const req = new PagedRequestDto();
    req.maxResultCount = this.pageSize;
    req.skipCount = (page - 1) * this.pageSize;
    req.sorting = this.sorting;

    this.isTableLoading = true;
    this.getDataList(req, page, () => {
      this.isTableLoading = false;
      // ???????????????????????????
      this.refreshAllCheckBoxDisabled();
    });
  }
  //#endregion

  //#region Checkbox???????????????????????????

  /**
   * ??????????????????
   * @param value ????????????
   */
  checkAll(value: boolean): void {
    this.dataList.forEach(data => ((<any>data).checked = this.allChecked));
    this.refreshCheckStatus(this.dataList);
  }
  /**
   * ??????????????????
   */
  refreshCheckStatus(entityList: any[]): void {
    // ??????????????????
    const allChecked = entityList.every(value => value.checked === true);
    // ?????????????????????
    const allUnChecked = entityList.every(value => !value.checked);
    // ????????????
    this.allChecked = allChecked;
    // ?????????????????????
    this.checkboxIndeterminate = !allChecked && !allUnChecked;
    // ???????????????
    this.selectedDataItems = entityList.filter(value => value.checked);
  }

  /**
   * ??????????????????
   */
  restCheckStatus(entityList: any[]): void {
    this.allChecked = false;
    this.checkboxIndeterminate = false;
    // ???????????????
    this.selectedDataItems = [];
    // ??????????????????????????????
    entityList.forEach(value => (value.checked = false));
  }
  /**
   * ???????????????????????????
   */
  refreshAllCheckBoxDisabled(): void {
    this.allCheckboxDisabled = this.dataList.length <= 0;
  }

  //#endregion
  /**
   * ???????????????????????????????????????
   * @param request ?????????????????? skipCount: number; maxResultCount: number;
   * @param pageNumber ????????????
   * @param finishedCallback ?????????????????????
   */
  protected abstract getDataList(
    request: PagedRequestDto,
    pageNumber: number,
    finishedCallback: Function,
  ): void;
}

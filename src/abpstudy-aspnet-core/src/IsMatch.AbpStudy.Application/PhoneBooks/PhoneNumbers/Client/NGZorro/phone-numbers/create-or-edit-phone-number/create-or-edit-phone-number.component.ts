
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdatePhoneNumberInput,PhoneNumberEditDto, PhoneNumberServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-phone-number',
  templateUrl: './create-or-edit-phone-number.component.html',
  styleUrls:[
	'create-or-edit-phone-number.component.less'
  ],
})

export class CreateOrEditPhoneNumberComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: PhoneNumberEditDto=new PhoneNumberEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _phoneNumberService: PhoneNumberServiceProxy
	) {
		super(injector);
    }

    ngOnInit() :void{
		this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
		this._phoneNumberService.getForEdit(this.id).subscribe(result => {
			this.entity = result.phoneNumber;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdatePhoneNumberInput();
		input.phoneNumber = this.entity;

		this.saving = true;

		this._phoneNumberService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}


import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateParameterInput,ParameterEditDto, ParameterServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-parameter',
  templateUrl: './create-or-edit-parameter.component.html',
  styleUrls:[
	'create-or-edit-parameter.component.less'
  ],
})

export class CreateOrEditParameterComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: ParameterEditDto=new ParameterEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _parameterService: ParameterServiceProxy
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
		this._parameterService.getForEdit(this.id).subscribe(result => {
			this.entity = result.parameter;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateParameterInput();
		input.parameter = this.entity;

		this.saving = true;

		this._parameterService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}

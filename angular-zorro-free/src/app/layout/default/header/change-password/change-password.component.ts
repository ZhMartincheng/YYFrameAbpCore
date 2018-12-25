import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AppComponentBase, ModalComponentBase } from '@shared/component-base';
import { UserServiceProxy, ChangePasswordInput, CreateRoleDto } from '@shared/service-proxies/service-proxies';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

//import * as _ from "lodash";

@Component({
    selector: 'change-password-modal',
    templateUrl: './change-password.component.html'
})
export class ChangePasswordComponent extends ModalComponentBase implements OnInit {
    validateForm: FormGroup;
    changePassword: ChangePasswordInput = null;
    role: CreateRoleDto = new CreateRoleDto();

    currentPassword: string;
    password: string;
    confirmPassword: string;

    constructor(
        injector: Injector,
        private _userService: UserServiceProxy,
        private fb: FormBuilder
    ) {
        super(injector);
    }
    ngOnInit(): void {
        //  Validators.minLength(3)
        this.validateForm = this.fb.group({
            orgPassword: [null, Validators.required],
            newPassword: [null, [Validators.required]],
            checkPassword: [null, Validators.compose([Validators.required, this.confirmationValidator])]
        });
        //  this.changePassword = new ChangePasswordInput();
    }
    /**
        * 验证旧密码的
        */
    confirorgPassword = (control: FormControl): { [s: string]: boolean } => {
        return { confirm: true, error: false };
    }

    /**
     * 新密码确认验证
     */
    confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
        if (!control.value) {
            return { required: true };
        } else if (control.value !== this.validateForm.controls['newPassword'].value) {
            return { confirm: true, error: true };
        }
    }

    saving = false;
    active = false;



    show(): void {
        this.active = true;
        this.currentPassword = '';
        this.password = '';
        this.confirmPassword = '';

        // this._userService.getPasswordComplexitySetting().subscribe(result => {
        //     this.passwordComplexitySetting = result.setting;
        //     this.modal.show();
        // });
    }

    onShown(): void {
        // $(this.currentPasswordInput.nativeElement).focus();
    }



    save(): void {
        let input = new ChangePasswordInput();
        input.currentPassword = this.currentPassword;
        input.newPassword = this.password;

        this.saving = true;
        if (this.validateForm.valid) {
            this._userService.checkOldPassword(input.currentPassword).subscribe((isValid: boolean) => {
                if (isValid == true) {
                    this._userService.changePassword(input)
                        .finally(() => { })
                        .subscribe(() => {
                            this.notify.info(this.l('修改成功！'), '');
                            this.close();
                            // this.modalSave.emit(null);
                        });
                } else {
                    // this.isConfirmLoading = false;
                    // this.isOldPasswordValid=true;
                    this.saving = false;
                    this.notify.error('原密码错误');

                }
            });
        }
    }

}

import { Component, OnInit, Injector, Input, ViewChild } from '@angular/core';
import { ListResultDtoOfPermissionDto, CreateRoleDto, RoleServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalComponentBase } from '@shared/component-base';
import { PermissionComponent } from '../permission/permission.component';

@Component({
  selector: 'app-create-role',
  templateUrl: './create-role.component.html',
  styles: []
})
export class CreateRoleComponent extends ModalComponentBase implements OnInit {
  // @ViewChild('permission') permissionTree: PermissionComponent;
  @ViewChild(PermissionComponent) child2;
  permissions: ListResultDtoOfPermissionDto = null;
  role: CreateRoleDto = new CreateRoleDto();
  permissionList = [];

  constructor(
    injector: Injector,
    private _roleService: RoleServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {

    this._roleService.getAllPermissions()
      .subscribe((permissions: ListResultDtoOfPermissionDto) => {
        this.permissions = permissions;

        this.permissions.items.forEach((item) => {
          this.permissionList.push({
            label: item.displayName, value: item.name, checked: true
          });
        });

      });

  }

  save(): void {
    const self = this;
    this.saving = true;
    let tmpPermissions = [];
    this.role.permissions = self.child2.getSelectPermissionNames();
    this._roleService.create(this.role)
      .finally(() => {
        this.saving = false;
      })
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.success();
      });
  }

}

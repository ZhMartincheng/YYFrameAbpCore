import { Component, OnInit, AfterViewInit, Input, Injector, ViewChild } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { RoleDto, ListResultDtoOfPermissionDto, RoleServiceProxy, GetRoleForEditOutput } from '@shared/service-proxies/service-proxies';
import { PermissionComponent } from '../permission/permission.component';

@Component({
  selector: 'app-edit-role',
  templateUrl: './edit-role.component.html',
  styles: []
})
export class EditRoleComponent extends ModalComponentBase implements OnInit, AfterViewInit {
  @ViewChild('child1') child1: PermissionComponent;
  // @ViewChild(PermissionComponent) child1;
  @Input() id: number;
  permissions: ListResultDtoOfPermissionDto = null;
  role: RoleDto = null;
  permissionList = [];
  data: GetRoleForEditOutput = new GetRoleForEditOutput();
  selectPermissionNames: any = [];//选择的权限


  constructor(
    injector: Injector,
    private _roleService: RoleServiceProxy
  ) {
    super(injector);
  }



  ngOnInit() {
    this._roleService.getGrantedPermissionNames(this.id)
      .finally(() => {

      })
      .subscribe((result: GetRoleForEditOutput) => {
        this.data = result;
      });

    this._roleService.getAllPermissions()
      .subscribe((permissions: ListResultDtoOfPermissionDto) => {
        this.permissions = permissions;

        this.fetchData();
      });

  }
  ngAfterViewInit() {
    //console.log(11);
    //const self = this;
    //self.permissionTree.editData = "aaa";

  }


  fetchData(): void {
    const self = this;
    self._roleService.get(this.id)
      .finally(() => {

      })
      .subscribe((result: RoleDto) => {
        self.role = result;
      });



  }


  checkPermission(permissionName: string): boolean {
    return this.role.permissions.indexOf(permissionName) != -1;
  }

  save(): void {
    this.saving = true;
    let tmpPermissions = [];


    this.permissionList.forEach((item) => {
      if (item.checked) {
        tmpPermissions.push(item.value);
      }
    });

    this.role.permissions = this.selectPermissionNames.length === 0 ? this.data.grantedPermissionNames : this.selectPermissionNames; //this.child1.getSelectPermissionNames() //tmpPermissions;

    //console.log(this.selectPermissionNames.length);
    this._roleService.update(this.role)
      .finally(() => {
        this.saving = false;
      })
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.success();
      });
  }


  bar(event: any) {
    //console.log(1111111111111111);
    this.selectPermissionNames = event;// event.FlatPermissionWithLevelDto;
    //console.log(event);
  }



}

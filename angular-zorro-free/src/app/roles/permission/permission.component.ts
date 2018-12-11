import { Component, OnInit, AfterViewInit, Injector, Input, Output, EventEmitter } from '@angular/core';
import { NzFormatEmitEvent } from "ng-zorro-antd";
import { PermissionServiceProxy, FlatPermissionWithLevelDto, GetRoleForEditOutput } from '@shared/service-proxies/service-proxies';
import { ModalComponentBase } from '@shared/component-base';

@Component({
    selector: 'nz-permission-tree',
    template: `
    <nz-tree
      [nzData]="nodes"
      nzCheckable="true"
      nzMultiple="true"
      [nzCheckedKeys]="defaultCheckedKeys"
      [nzExpandedKeys]="defaultExpandedKeys"
      [nzSelectedKeys]="defaultSelectedKeys"
      (nzClick)="nzEvent($event)"
      (nzExpandChange)="nzEvent($event)"
      (nzCheckBoxChange)="nzEvent($event)">
    </nz-tree>
  `
})
export class PermissionComponent extends ModalComponentBase implements OnInit, AfterViewInit {
    //定义一个输出的
    @Output() foo = new EventEmitter<string>()


    nodes: any = [];
    // tempNodes: ListResultDtoOfFlatPermissionWithLevelDto = null;
    //permissions: ListResultDtoOfPermissionDto = null;
    defaultCheckedKeys = [];



    constructor(
        injector: Injector,
        private _permissionService: PermissionServiceProxy
    ) {
        super(injector);
    }

    _input: GetRoleForEditOutput = new GetRoleForEditOutput();
    @Input()
    public set input(v: GetRoleForEditOutput) {
        //this._input = v.toUpperCase();//转换大写输出
        this._input = v;
        //console.log(v);
    }
    public get input(): GetRoleForEditOutput {
        return this._input;
    }

    public permissionNames: any = [];

    nzEvent(event: NzFormatEmitEvent): void {
        //console.log(this.defaultCheckedKeys);
        // console.log(this.defaultSelectedKeys);
        //console.log(event.checkedKeys);
        this.permissionNames = [];
        for (const item of event.nodes) {
            // console.log(item.key);
            this.permissionNames.push(item.key);
            if (item.children.length) {
                for (const itemChildren of item.children) {
                    // console.log(itemChildren.key);
                    this.permissionNames.push(itemChildren.key);

                }
            }
        }
        this.foo.emit(this.permissionNames);
    }

    ngOnInit(): void {
        // console.log(this.names);
        this._permissionService.getAllPermissionsTree()
            .subscribe((permissions: FlatPermissionWithLevelDto[]) => {
                this.nodes = permissions;
                this.defaultCheckedKeys = this._input.grantedPermissionNames; //["Pages", "Pages.Users", "Pages.Roles"];//this._input; //["Pages.Roles"];
            })

    }

    getSelectPermissionNames(): string[] {
        //  console.log(11);
        //  console.log(this.permissionNames)
        return this.permissionNames;
    }
    ngAfterViewInit(): void {
        //console.log(this._input);
        // this.defaultCheckedKeys = this._input;
    }


}

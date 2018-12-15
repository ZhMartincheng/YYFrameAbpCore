import { Component, Injector, ViewChild, Input, OnInit } from '@angular/core';
import { AuditLogListDto } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { AppComponentBase, ModalComponentBase } from '@shared/component-base';
import { Variable } from '@angular/compiler/src/render3/r3_ast';

@Component({
    selector: 'auditLogDetailModal',
    templateUrl: './auditlog.detail.component.html'
})
export class AuditLogDetailModalComponent extends ModalComponentBase implements AppComponentBase, OnInit {


    active = false;
    @Input() auditLog: AuditLogListDto;

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    getExecutionTime(): string {
        const self = this;
        return moment(self.auditLog.executionTime).fromNow() + ' (' + moment(self.auditLog.executionTime).format('YYYY-MM-DD HH:mm:ss') + ')';
    }

    getDurationAsMs(): string {
        const self = this;
        return self.l('Xms', self.auditLog.executionDuration);
    }

    getFormattedParameters(): string {
        const self = this;
        try {
            const json = JSON.parse(self.auditLog.parameters);
            return JSON.stringify(json, null, 4);
        } catch (e) {
            return self.auditLog.parameters;
        }
    }

    ngOnInit() {
        this.auditLog;
    }

    close() {
        this.success();
    }

}

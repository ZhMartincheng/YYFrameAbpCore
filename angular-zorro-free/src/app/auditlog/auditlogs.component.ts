import {
    AuditLogListDto, AuditLogServiceProxy, NameValueDto,
    PagedResultDtoOfAuditLogListDto
} from "@shared/service-proxies/service-proxies";
import { PagedListingComponentBase, PagedRequestDto } from "@shared/component-base";
import { Injector, Component, OnInit } from "@angular/core";
// import moment = require("moment");
import * as moment from 'moment';
import { FileDownloadService } from "@shared/utils/file-download.service";
import { addDays } from "date-fns";
import { AuditLogDetailModalComponent } from "./auditlog.detail.component";
@Component({
    selector: 'app-audit',
    templateUrl: './auditlogs.component.html',
    styles: [],
})
export class AuditlogComponent extends PagedListingComponentBase<AuditLogListDto> implements OnInit {

    constructor(injector: Injector
        , private _auditService: AuditLogServiceProxy
        , private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }


    //Filters
    public startDate: moment.Moment = moment().startOf('day');
    public endDate: moment.Moment = moment().endOf('day');
    public usernameAuditLog: string;
    public usernameEntityChange: string;
    public serviceName: string;
    public methodName: string;
    public browserInfo: string;
    public hasException: boolean = undefined;
    public minExecutionDuration: number;
    public maxExecutionDuration: number;
    public entityTypeFullName: string;
    public objectTypes: NameValueDto[];

    exportSLoading = false;

    shedateFormat = 'yyyy-MM-dd';
    public searchAreasDate = [];

    public sortName = null;
    public sortValue = null;

    protected fetchDataList(
        request: PagedRequestDto,
        pageNumber: number,
        finishedCallback: Function,
    ): void {
        this._auditService
            .getAuditLogs(
                this.startDate,
                this.endDate,
                this.usernameAuditLog,
                this.serviceName,
                this.methodName,
                this.browserInfo,
                this.hasException,
                this.minExecutionDuration,
                this.maxExecutionDuration,
                request.sorting,
                request.maxResultCount,
                request.skipCount

            )
            .finally(() => {
                finishedCallback();
            })
            .subscribe((result: PagedResultDtoOfAuditLogListDto) => {
                //console.log(result);
                this.dataList = result.items;
                this.totalItems = result.totalCount;
            });
    }

    sort(sort: { key: string, value: string }): void {
        this.sortName = sort.key;
        //  time,,descend
        //  time,,ascend
        if (sort.value.indexOf("desc") >= 0)
            this.sortValue = "desc";
        else
            this.sortValue = "asc";
        this.sorting = this.sortName + "  " + this.sortValue;
        this.refresh();
    }



    truncateStringWithPostfix(text: string, length: number): string {
        return abp.utils.truncateStringWithPostfix(text, length);
    }

    ngOnInit(): void {
        this.refresh();
        this.getNowDate();
    }
    //导出excel
    exportAudit() {
        this.exportSLoading = true;
        this._auditService.getAuditLogsToExcel(
            this.startDate,
            this.endDate,
            this.usernameAuditLog,
            this.serviceName,
            this.methodName,
            this.browserInfo,
            this.hasException,
            this.minExecutionDuration,
            this.maxExecutionDuration,
            '',
            1,
            0

        ).subscribe(data => {

            this._fileDownloadService.downloadTempFile(data);
            this.exportSLoading = false;
        })
        //this.exportSLoading = false;
    }

    /**
 * 时间段发生改变
 */
    changeTime(times) {
        if (times.length > 0) {

            this.startDate = moment(times[0]);
            this.endDate = moment(times[1]);
        }
    }

    getNowDate() {
        var nowDate = new Date();
        var year = nowDate.getFullYear();
        var moth = nowDate.getMonth();
        var firstDay = new Date(year, moth, 1);
        // this.firstDay = new Date(nowDate.setDate(1));
        var lastDay = addDays(new Date(year, moth + 1, 1), -1);
        this.searchAreasDate = [firstDay, lastDay]
        this.startDate = moment(firstDay);
        this.endDate = moment(lastDay);
    }


    showAuditLogDetails(record: AuditLogListDto): void {
        this.modalHelper
            .open(AuditLogDetailModalComponent, { auditLog: record }, 'md', {
                nzMask: true,
                nzClosable: false,
            })
            .subscribe(isSave => {
                if (isSave) {
                    this.refresh();
                }
            });
    }
}
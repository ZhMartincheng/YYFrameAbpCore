import { NgModule } from "@angular/core";
import { MomentFormatPipe } from "./moment-format.pipe";
import { FileDownloadService } from "./file-download.service";

@NgModule({
    imports: [
        // CommonModule
    ],
    providers: [
        FileDownloadService,

    ],
    declarations: [
        MomentFormatPipe,
    ],
    exports: [
        MomentFormatPipe,

    ]
})
export class UtilsModule { }
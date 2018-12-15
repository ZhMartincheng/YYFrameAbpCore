import { AppRouteGuard } from "@shared/auth/auth-route-guard";
import { AppAuthService } from "@shared/auth/app-auth.service";
import { ModuleWithProviders, NgModule } from "@angular/core";

@NgModule({
    imports: [
    ],
    declarations: [
    ],
    exports: [
    ],
    providers: [
    ]
})
export class AppCommonModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: AppCommonModule,
            providers: [
                AppAuthService,
                AppRouteGuard
            ]
        };
    }
}
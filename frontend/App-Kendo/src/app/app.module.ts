import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CustomMessagesService } from './services/custom-messages.service';

import { ExcelModule, GridModule, PDFModule } from '@progress/kendo-angular-grid';
import { LabelModule } from '@progress/kendo-angular-label';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { SchedulerModule } from '@progress/kendo-angular-scheduler';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { EditorModule } from '@progress/kendo-angular-editor';
import { FileSelectModule } from '@progress/kendo-angular-upload';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { IntlModule } from '@progress/kendo-angular-intl';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { NotificationModule } from '@progress/kendo-angular-notification';
import { MessageService } from '@progress/kendo-angular-l10n';



// Import routing module
import { AppRoutingModule } from './app-routing.module';

// Import containers
import {
    DefaultFooterComponent,
    DefaultHeaderComponent,
    DefaultLayoutComponent,
    StaticLayoutComponent,
    StaticHeaderComponent,
    StaticFooterComponent

  } from './containers';

const APP_CONTAINERS = [
    DefaultFooterComponent,
    DefaultHeaderComponent,
    DefaultLayoutComponent,
    StaticLayoutComponent,
    StaticHeaderComponent,
    StaticFooterComponent
  ];

import {  } from './containers/static-layout/static-layout.component';
import {  } from './containers/static-layout/static-header/static-header.component';
import {  } from './containers/static-layout/static-footer/static-footer.component';

import { NotificationsModule } from './shared/notification';

import 'hammerjs';

import '@progress/kendo-angular-intl/locales/en/all';
import '@progress/kendo-angular-intl/locales/es/all';
import '@progress/kendo-angular-intl/locales/fr/all';
import { StoreModule } from '@ngrx/store';
import { reducers, effects } from './store/index';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment.dev';
import { AuthInterceptor } from './auth-interceptor';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TreeListModule } from '@progress/kendo-angular-treelist';
import { IndicatorsModule } from '@progress/kendo-angular-indicators';



@NgModule({
    declarations: [
        AppComponent,
        ...APP_CONTAINERS,
        StaticHeaderComponent
    ],
    imports: [
        AppRoutingModule,
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        GridModule,
        PDFModule,
        ExcelModule,
        LabelModule,
        LayoutModule,
        SchedulerModule,
        ButtonsModule,
        EditorModule,
        FileSelectModule,
        HttpClientModule,
        ChartsModule,
        IntlModule,
        DateInputsModule,
        IndicatorsModule,
        InputsModule,
        DropDownsModule,
        PerfectScrollbarModule,
        NotificationModule,
        NotificationsModule,
        StoreModule.forRoot(reducers, {
            runtimeChecks: {
              strictActionImmutability: true,
              strictStateImmutability: true,
            }
          }),
          EffectsModule.forRoot(effects),
          HttpClientModule,
          StoreDevtoolsModule.instrument({ maxAge: 50, logOnly: environment.production }),
          FontAwesomeModule,
          TreeListModule
    ],
    providers: [
        { provide: MessageService, useClass: CustomMessagesService },
        { provide: LOCALE_ID, useValue: 'en-US' },
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})
export class AppModule {}

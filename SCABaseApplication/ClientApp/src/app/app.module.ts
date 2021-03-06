import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ScheduleComponent, MessageDialog } from './schedule/schedule.component';
import { ScheduleViewComponent } from './schedule/schedule-view/schedule-view.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { FacilityService } from './services/facility.service';
import { ScheduleService } from './services/schedule.service';




import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginatorModule } from '@angular/material';
import { MatSortModule } from '@angular/material';


@NgModule({
  declarations: [
    AppComponent,
    ScheduleComponent,
    MessageDialog,
    ScheduleViewComponent,
    HeaderComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatTableModule,
    MatDialogModule,
    MatPaginatorModule,
    MatSortModule,
    RouterModule.forRoot([
      { path: '', component: ScheduleComponent, pathMatch: 'full' }
    ])
  ],
  entryComponents: [MessageDialog],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

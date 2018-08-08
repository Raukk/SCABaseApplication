import { Component, OnInit, ViewChild, Input, ChangeDetectorRef  } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ScheduleService } from '../../services/schedule.service';
import { ISchedule } from '../../view_models/schedule.model';

@Component({
  selector: 'app-schedule-view',
  templateUrl: './schedule-view.component.html',
  styleUrls: ['./schedule-view.component.css']
})
export class ScheduleViewComponent implements OnInit {
  public displayedColumns: string[] = ['teammateName', 'teammateType', 'monday', 'tuesday','wednesday','thursday','friday','saturday','sunday'];
  public dataSource: MatTableDataSource<ISchedule>;
  public downloadUrl: string = "#";

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @Input() FacilityId: string;
  @Input() MondayDate: string;

  constructor(private scheduleService: ScheduleService, private changeDetectorRefs: ChangeDetectorRef) {

    let placeholder: ISchedule[];
    this.dataSource = new MatTableDataSource(placeholder);

  }

  public refreshData()
  {
    
    console.log("refresh");
    if (this.FacilityId != null && this.MondayDate != null) {
    
      this.downloadUrl = '/api/Schedule/SchedulesCsv/' + this.FacilityId + '/' + this.MondayDate;
      console.log(this.downloadUrl);

      this.scheduleService.getSchedules(this.FacilityId, this.MondayDate)
        .subscribe(data => {

          // Assign the data to the data source for the table to render
          this.dataSource = new MatTableDataSource(data);
          this.changeDetectorRefs.detectChanges();
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;

        });

    }

  }

  public downloadCsv() {

    console.log(this.downloadUrl);
    window.location.href = this.downloadUrl;

  }

  public applyFilter(filterValue: string) {

    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }

  }

  ngOnInit() {

    this.refreshData();

  }

}

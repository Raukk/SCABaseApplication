import { Component, Inject } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';



@Component({
  selector: 'schedule-view-dialog',
  template: '{{ data }} <br /> <button mat-button mat-dialog-close>Close</button>',
})
export class MessageDialog {

  constructor(
    public dialogRef: MatDialogRef<MessageDialog>,
    @Inject(MAT_DIALOG_DATA) public data: string) { }

}



export interface Facility {
  value: string;
  viewValue: string;
}




@Component({
  selector: 'app-schedule-component',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent {
  public scheduleViewed = false;
  public selectedFacility : Facility = null;
  public selectedDate: Date = null;

  public constructor(private titleService: Title, public dialog: MatDialog)
  {
    this.titleService.setTitle("Daily Schedule");
  }

  openDialog(text : string): void {
    const dialogRef = this.dialog.open(MessageDialog, {
      width: '250px',
      data: text
    });
  }


  public facilities: Facility[] = [
    { value: '0', viewValue: 'Apple' },
    { value: '1', viewValue: 'Bannana' },
    { value: '3', viewValue: 'Orange' },
    { value: '4', viewValue: 'Plum' }
  ];

  public onlyMondays = (d: Date): boolean => {
    const day = d.getDay();
    // Prevent non-Mondays from being selected.
    return day == 1;
  }

  public viewSchedule() {

    // Can only view schedule if a facility has been selected
    if (this.selectedFacility == null)
    {
      // warn user they must select a facility
      this.openDialog("You must select a Facility");
      return;
    }

    // The date must be a Monday
    if (this.selectedDate == null || this.selectedDate.getDay() != 1 ) {
      // warn user they must select a date and the Date must be a Monday
      this.openDialog("You must select a Monday");
      return;
    }
    

    if (this.scheduleViewed)
    {
      // Refresh data





    }

    this.scheduleViewed = true;

  }
}

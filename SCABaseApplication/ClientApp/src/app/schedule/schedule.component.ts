import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

export interface Facility {
  value: string;
  viewValue: string;
}
@Component({
  selector: 'app-schedule-component',
  templateUrl: './schedule.component.html'
})
export class ScheduleComponent {
  public currentCount = 0;

  public constructor(private titleService: Title)
  {
    this.titleService.setTitle("Daily Schedule");
  }

  public facilities: Facility[] = [
    { value: '0', viewValue: 'Apple' },
    { value: '1', viewValue: 'Bannana' },
    { value: '3', viewValue: 'Orange' },
    { value: '4', viewValue: 'Plum' }
  ];

  public onlyMondays = (d: Date): boolean => {
    const day = d.getDay();
    // Prevent Saturday and Sunday from being selected.
    return day == 1;
  }

  public incrementCounter() {
    this.currentCount++;
  }
}

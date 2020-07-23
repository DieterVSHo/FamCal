import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from './../dialog/dialog.component';

@Component({
  selector: 'app-family-calendar',
  templateUrl: './family-calendar.component.html',
  styleUrls: ['./family-calendar.component.scss']
})
export class FamilyCalendarComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    dateClick: this.handleDateClick.bind(this),
    events: [
      { title: 'ev1', date: '2020-07-19'}
    ]
  };

  ngOnInit(): void {
    
  }

  handleDateClick(arg){
    //alert('date click!'+arg.dateStr);
    let dialogref = this.dialog.open(DialogComponent);
    dialogref.afterClosed().subscribe(result => {
      console.log(`ok ${result}`);
    })
  }

}

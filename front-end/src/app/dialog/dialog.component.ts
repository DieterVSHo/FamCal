import { EventDataService } from '../services/event-data.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Event } from '../models/event.model';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
  FormArray,
} from '@angular/forms';


@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})

// DVS: THREEDOUBLE CHECK THIS

export class DialogComponent implements OnInit {
  public errorMessage: string = '';
  public confirmationMessage: string = '';
  public event: FormGroup;

  constructor(
    private fb: FormBuilder,
    private _eventDataService: EventDataService
  ) { }

  ngOnInit(): void {
    this.event = this.fb.group({
      title: ['', [Validators.required]],
      startTime: [],
      endTime: [],
    });
  }

  onSubmit() {
    this._eventDataService
      .addNewEvent(new Event(this.event.value.title, this.event.value.startTime, this.event.value.endTime))
      // .pipe(
      //   catchError((err) => {
      //     this.errorMessage = err;
      //     return EMPTY;
      //   })
      // )
      .subscribe((ev: Event) => {
        this.confirmationMessage = `Event ${ev.title} was successfully added`;
      });

    this.event = this.fb.group({
      title: ['', [Validators.required]],
      startTime: [],
      endTime: [],
    });
  }

  getErrorMessage(errors: any): string {
    if (!errors) {
      return null;
    }
    if (errors.required) {
      return 'is required';
    } else if (errors.time) {
      return 'Start time cannot be before end time'
    }
  }

}

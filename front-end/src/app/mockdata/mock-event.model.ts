import { Event } from './../models/event.model';
import { DialogComponent } from './../dialog/dialog.component';

const JsonEvents = [
  {
    name: 'Taart bij tante Rita',
    owner: 'test',
    startDate: '2020-02-07T18:30:43.511Z',
    endDate: '2020-02-07T19:30:43.511Z'
  },
];
export const EVENTS: Event[] = JsonEvents.map(Event.fromJSON);
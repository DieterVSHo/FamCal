import { User } from './user.model';

export class Event {
    constructor(
        private _title: string,
        private _owner: User,
        private _startDate = new Date(),
        private _endDate = new Date()
    ) {}
  
    get title(): string {
      return this._title;
    }

    addEvent(title: string, startDate: Date, endDate: Date, owner: User) {
        this._title = title;
        this._startDate = startDate;
        this._endDate = endDate;
        this._owner = owner;
    }

    // static fromJSON(json: EventJson): Event {
    //     const event = new Event(json.title, json.owner, new Date(json.date));
    //     return event;
    // }
  }
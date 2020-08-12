import { User } from './user.model';

interface EventJson {
    id: number;
    title: string;
    owner: OwnerJson[];
    startDate: string;
    endDate: string;
  }

export class Event {
    private _id: number;
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

    static fromJSON(json: EventJson): Event {
        const rec = new Event(
          json.title,
          json.owner,
          new Date(json.startDate),
          new Date(json.endDate),
        );
        rec._id = json.id;
        return rec;
      }
    
      toJSON(): EventJson {
        return <EventJson>{
            title: this.title,
            owner: "owner",
            startDate: this.startDate.toString(),
            endDate: this.endDate.toString(),
        };
      }
  }
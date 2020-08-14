interface EventJson {
    id: number;
    title: string;
    owner: string;
    startDate: string;
    endDate: string;
  }

export class Event {
    private _id: number;
    constructor(
        private _title: string,
        private _owner: string,
        private _startDate = new Date(),
        private _endDate = new Date()
    ) {}
  
    get title(): string {
      return this._title;
    }

    addEvent(title: string, startDate: Date, endDate: Date, owner: string) {
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
            startDate: this._startDate.toString(),
            endDate: this._endDate.toString(),
        };
      }
  }
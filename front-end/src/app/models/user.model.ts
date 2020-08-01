export class User {
    constructor(
        private _name: string,
        private _email: string
    ) {}
  
    get name(): string {
      return this._name;
    }
  }
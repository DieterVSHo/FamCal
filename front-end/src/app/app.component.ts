import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FamCal';

  constructor(private route: Router) {}

  btnLogout() {
    this.route.navigateByUrl('/login');
  }

}

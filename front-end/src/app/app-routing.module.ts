import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FamilyCalendarComponent } from './family-calendar/family-calendar.component';


const routes: Routes = [
  { path: 'familycalendar', component: FamilyCalendarComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

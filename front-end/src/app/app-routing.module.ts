import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FamilyCalendarComponent } from './family-calendar/family-calendar.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { AuthGuard } from './user/auth.guard';


const routes: Routes = [
  { path: '',
    redirectTo: '/login',
    pathMatch: 'full',
    canActivate: [ AuthGuard ],
  },
  { path: 'familycalendar', component: FamilyCalendarComponent },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { MaterialModule } from '../material.module';
import { AppRoutingModule } from '../app-routing.module';


@NgModule({
  declarations: [LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    MaterialModule,
    AppRoutingModule,
  ],
  exports: [
    LoginComponent,
    RegisterComponent
  ]
})
export class UserModule { }

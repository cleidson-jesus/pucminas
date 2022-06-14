
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { ComponentsModule } from 'src/app/components/components.module';

import { LoginComponent } from './login.component';
import { LoginService } from './login.service';


const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    ReactiveFormsModule,
    ComponentsModule
  ],
  exports: [RouterModule],
  declarations: [LoginComponent],
  providers: [LoginService]
})
export class LoginModule { }
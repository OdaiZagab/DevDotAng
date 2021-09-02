import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { HotelListComponent } from './Hotel/hotel-list/hotel-list.component';
import { HotelDetailsComponent } from './Hotel/hotel-details/hotel-details.component';
import { NavComponent } from './nav/nav.component';
import { HotelPreviewCardComponent } from './Hotel/hotel-preview-card/hotel-preview-card.component';
import { LoginComponent } from './user/login/login.component';
import { SignupComponent } from './user/signup/signup.component'
import {MatMenuModule} from '@angular/material/menu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 import { HotelCreateComponent } from './Hotel/hotel-create/hotel-create.component'; 

export function tokenGetter() {
  return localStorage.getItem("token");
}


@NgModule({
  declarations: [
    AppComponent,
    HotelListComponent,
    HotelDetailsComponent,
    NavComponent,
    HotelPreviewCardComponent,
    LoginComponent,
    SignupComponent,
    HotelCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatMenuModule,
    BrowserAnimationsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

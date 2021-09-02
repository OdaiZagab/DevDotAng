import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HotelCreateComponent } from './Hotel/hotel-create/hotel-create.component';
import { HotelDetailsComponent } from './Hotel/hotel-details/hotel-details.component';
import { HotelListComponent } from './Hotel/hotel-list/hotel-list.component';
import { LoginComponent } from './user/login/login.component';

const routes: Routes = [    
  { path: 'Home', component: AppComponent },
  { path: 'Login', component: LoginComponent },

  {path:'Hotels',children:[
    {path:'Create',component:HotelCreateComponent},
    {path:'',component:HotelListComponent},
    {path:':id',component:HotelDetailsComponent}
  ]}
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

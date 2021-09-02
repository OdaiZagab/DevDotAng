import { Component, OnInit } from '@angular/core';
import { empty } from 'rxjs';
import { User } from './Models/User';
import { AuthService } from './Services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public model:any={}
  public  user:User | undefined;
  public loginMode=false;
  public loggedIn=false;
   constructor(public authService:AuthService){}

  ngOnInit(): void {
    if(this.loginMode){
      this.login();
    }
    
  }

  login(){
    this.authService.login(this.model).subscribe(
      next=>{
        this.user=this.authService.user;
        this.loggedIn=true;
       
      },
      error=>{
        this.authService.logout();
        this.loggedIn==false;
    
      }
    );
  }
  title = 'Project001-SPA';

  
}

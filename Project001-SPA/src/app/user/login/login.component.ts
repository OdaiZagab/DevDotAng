import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { User } from 'src/app/Models/User';
import { AuthService } from 'src/app/Services/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public model:any={};
  @Input() user:any | undefined;
  @Input() loginMode:boolean | undefined;
  constructor(public authService:AuthService) { }

  ngOnInit(): void {
    if(this.user!==null){
      this.authService.loggedIn=true;
    }
    else{
      this.authService.loggedIn=false;
    }
  }

  login(){
    this.loginMode=true;
    this.user.name=this.model.name;
    this.user.password=this.model.password;
  }
  logout(){
    this.authService.logout();
  }

}

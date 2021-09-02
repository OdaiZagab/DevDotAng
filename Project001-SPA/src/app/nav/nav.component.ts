import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../Models/User';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  @Input() loggedIn:boolean=false;
  @Input() logMode=false;
  constructor(public routee:Router,public authService:AuthService) { }
 
  ngOnInit(): void {
  }

  login(){
    this.authService.logMode=true;
    

  }

  logout(){
    this.authService.logout();
  }
  changeLogMode(){
    this.logMode=!this.logMode;
  }
  addHotel(){
    this.routee.navigate(['/Hotels/Create']);
  }
}

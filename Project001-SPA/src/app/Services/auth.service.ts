import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../Models/User';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseURL=environment.baseURL+"api/auth/";
  loggedIn=false;
  public token:any;
  public user:User | undefined;
  public logMode=false;

  constructor(private http:HttpClient) { }

  login(user:any={}){
    return this.http.post(this.baseURL+"login",user).pipe(
      map(tokenFromApi=>{

        if(tokenFromApi!=null){
          this.token=tokenFromApi;
          localStorage.setItem("token",this.token+"");
          this.loggedIn=true;
          this.getUser(1).subscribe(
            next=>{
              this.user=next;
            },
            error=>{
              this.loggedIn=false;
              this.token=null;
              this.user==null;            }
          );
        }
        else{
          this.loggedIn=false;
          this.token=null;
          this.user==null;
        }
      })
    )
  }

  logout(){
    this.loggedIn=false;
    localStorage.removeItem("token");
  }

  signup(){}

  getUser(id:number) : Observable<User>{
    return this.http.get<User>(this.baseURL + "getUser/" + id);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Hotel } from '../Models/Hotel';

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  url=environment.baseURL+"Hotel/"
  constructor(private http:HttpClient) { }
  
  getHotels():Observable<Hotel[]>{
    return this.http.get<Hotel[]>(this.url+"getHotels");
  }
  getHotel(id:number){
    return this.http.get<Hotel>(this.url+"getHotel/"+id);
  }

  addHotel(hotel:Hotel){
    return this.http.post<Hotel>(this.url+"addHotel",hotel);
  }

}

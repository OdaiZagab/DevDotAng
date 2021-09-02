import { Component, OnInit } from '@angular/core';
import { Hotel } from 'src/app/Models/Hotel';
import { HotelService } from 'src/app/Services/hotel.service';

@Component({
  selector: 'app-hotel-list',
  templateUrl: './hotel-list.component.html',
  styleUrls: ['./hotel-list.component.css']
})
export class HotelListComponent implements OnInit {

  constructor(private hotelService:HotelService) { }
 public hotels!: any[];
   ngOnInit(): void {
    this.getHotels();
  }

  getHotels(){
    this.hotelService.getHotels().subscribe(
      next=>{
        this.hotels=next;
      },
      error=>{
        console.log("error");
      }
    );
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Hotel } from 'src/app/Models/Hotel';
import { HotelService } from 'src/app/Services/hotel.service';

@Component({
  selector: 'app-hotel-details',
  templateUrl: './hotel-details.component.html',
  styleUrls: ['./hotel-details.component.css']
})
export class HotelDetailsComponent implements OnInit {

  public id:any  ;
  public hotel:Hotel | undefined;
  constructor(private router:ActivatedRoute,private hotelService:HotelService) { }

  ngOnInit() {
    console.log("Working...");

    this.id=this.router.snapshot.paramMap.get("id");
    this.getHotel(this.id);
  }


  getHotel(id:any){
    this.hotelService.getHotel(this.id).subscribe(
      next=>{
        this.hotel=next;
      },
      error=>{
        console.log(error);
      }
    )
  }



}

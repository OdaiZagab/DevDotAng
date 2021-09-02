import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Hotel } from 'src/app/Models/Hotel';
import { HotelService } from 'src/app/Services/hotel.service';

@Component({
  selector: 'app-hotel-create',
  templateUrl: './hotel-create.component.html',
  styleUrls: ['./hotel-create.component.css']
})
export class HotelCreateComponent implements OnInit {

  public hotel:Hotel | undefined;
  public model:any={};
  constructor(private hotelService:HotelService,private route:Router) { }

  ngOnInit(): void {
  }


  addHotel(){
   this.hotelService.addHotel(this.model).subscribe(
     next=>{
       console.log("Created");
       this.hotel=next;
       this.route.navigate(['/Hotels/'+this.hotel.id]);
     }
   );
  }

}

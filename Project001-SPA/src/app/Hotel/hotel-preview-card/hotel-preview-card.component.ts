import { Component, Input, OnInit } from '@angular/core';
import { Hotel } from 'src/app/Models/Hotel';

@Component({
  selector: 'app-hotel-preview-card',
  templateUrl: './hotel-preview-card.component.html',
  styleUrls: ['./hotel-preview-card.component.css']
})
export class HotelPreviewCardComponent implements OnInit {

  @Input() hotel:any | undefined;
  hotelToGet:Hotel | undefined;
  constructor() { }

  ngOnInit(): void {
    this.hotelToGet=this.hotel;
  }

}

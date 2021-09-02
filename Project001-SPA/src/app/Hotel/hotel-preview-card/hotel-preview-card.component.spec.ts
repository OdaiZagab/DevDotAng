import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelPreviewCardComponent } from './hotel-preview-card.component';

describe('HotelPreviewCardComponent', () => {
  let component: HotelPreviewCardComponent;
  let fixture: ComponentFixture<HotelPreviewCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HotelPreviewCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelPreviewCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

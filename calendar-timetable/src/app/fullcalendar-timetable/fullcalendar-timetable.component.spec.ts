import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FullcalendarTimetableComponent } from './fullcalendar-timetable.component';

describe('FullcalendarTimetableComponent', () => {
  let component: FullcalendarTimetableComponent;
  let fixture: ComponentFixture<FullcalendarTimetableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FullcalendarTimetableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FullcalendarTimetableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

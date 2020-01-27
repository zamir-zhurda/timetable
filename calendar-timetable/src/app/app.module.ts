import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { AppComponent } from "./app.component";
import { FullcalendarTimetableComponent } from "./fullcalendar-timetable/fullcalendar-timetable.component";

@NgModule({
  declarations: [AppComponent, FullcalendarTimetableComponent],
  imports: [BrowserModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}

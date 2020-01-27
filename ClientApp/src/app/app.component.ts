import { Component } from "@angular/core";
import dayGridPlugin from "@fullcalendar/daygrid";
import { EventInput } from "@fullcalendar/core";
import timeGrigPlugin from "@fullcalendar/timegrid";
import interactionPlugin from "@fullcalendar/interaction";
@Component({
  selector: "app-root",
  templateUrl: "./app.component.html"
})
export class AppComponent {
  title = "app";
  calendarPlugins = [dayGridPlugin, timeGrigPlugin, interactionPlugin];
  calendarEvents: EventInput[] = [
    {
      title: "event1",
      start: new Date("2019-01-24")
    },
    {
      title: "event2",
      start: new Date("2019-01-27"),
      end: new Date("2019-01-28")
    },
    {
      title: "event3",
      start: new Date("2019-01-29T12:30:00"),
      allDay: false // will make the time show
    }
    // { title: "first event", date: new Date("2019-01-24") },
    // { title: "second event", date: new Date("2019-01-27") },
    // { title: "third event", date: new Date("2019-01-28") },
    // { title: "fourth event", date: new Date("2019-01-29") }
  ];
  addEvent() {
    this.calendarEvents = this.calendarEvents.concat([
      // creates a new array!
      { title: "event 2", start: new Date("2019-01-27") }
    ]);
  }

  modifyTitle(eventIndex, newTitle) {
    let calendarEvents = this.calendarEvents.slice(); // a clone
    let singleEvent = Object.assign({}, calendarEvents[eventIndex]); // a clone
    singleEvent.title = newTitle;
    calendarEvents[eventIndex] = singleEvent;
    this.calendarEvents = calendarEvents; // reassign the array
  }
  handleDateClick(event: any) {}
}

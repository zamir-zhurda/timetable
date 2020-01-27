import { Component, OnInit, Input } from "@angular/core";
import { HttpClient } from "@angular/common/http";
// import { EventInput } from "@fullcalendar/core";
import { map } from "rxjs/operators";
import * as $ from "jquery";
import * as moment from "moment";
import "fullcalendar";

import { EventsService } from "./events.services";

@Component({
  selector: "app-fullcalendar-timetable",
  templateUrl: "./fullcalendar-timetable.component.html",
  styleUrls: ["./fullcalendar-timetable.component.css"]
})
export class FullcalendarTimetableComponent implements OnInit {
  @Input()
  set configurations(config: any) {
    if (config) {
      this.defaultConfigurations = config;
    }
  }
  calendarEvents: any = [];
  loadedEvents: any = [];

  isFetching = false;

  @Input() eventData: any;

  defaultConfigurations: any;

  constructor(private http: HttpClient, private eventsService: EventsService) {
    console.log(
      "\n\n1)---------------------- Starting [ contructor ] ----------------------"
    );
    // this.eventData = [
    //   {
    //     title: "event1",
    //     start: moment()
    //   },
    //   {
    //     title: "event2",
    //     start: moment(),
    //     end: moment().add(2, "days")
    //   }
    // ];
    ////Working!!
    // (this.loadedEvents = [
    //   {
    //     id: "3",
    //     title: "event 3",
    //     start: moment("2020-01-25T17:20:30"),
    //     end: moment("2020-01-25T17:40:30"),
    //     allDay: true
    //   },
    //   {
    //     id: "2",
    //     title: "event 2",
    //     start: moment("2020-01-28T17:00:30"),
    //     end: moment("2020-01-28T17:20:30"),
    //     allDay: false
    //   },
    //   {
    //     id: "1",
    //     title: "event 1",
    //     start: moment("2020-01-27T17:00:30"),
    //     end: moment("2020-01-27T17:20:30"),
    //     allDay: false
    //   }
    // ]),
    //testing!
    (this.loadedEvents = [
      {
        id: 1,
        title: "event 1",
        description: "test description 1",
        start: moment("2020-01-25T16:20:30"),
        end: moment("2020-01-25T16:40:30"),
        allDay: false
      },
      {
        id: 2,
        title: "event 2",
        description: "test description 2",
        start: moment("2020-01-27T16:00:30"),
        end: moment("2020-01-27T16:20:30"),
        allDay: false
      },
      {
        id: 3,
        title: "event 3",
        description: "test description 3",
        start: moment("2020-01-28T15:00:30"),
        end: moment("2020-01-28T15:20:30"),
        allDay: false
      },
      {
        id: 4,
        title: "event 4",
        description: "test description 4",
        start: moment("2020-01-29T14:00:30"),
        end: moment("2020-01-29T14:20:30"),
        allDay: false
      },
      {
        id: 5,
        title: "event 5",
        description: "test description 5",
        start: moment("2020-01-30T13:00:30"),
        end: moment("2020-01-30T13:20:30"),
        allDay: false
      }
    ]),
      (this.loadedEvents = this.getEvents()),
      (this.defaultConfigurations = {
        minTime: "08:00",
        maxTime: "20:00",
        weekends: false,
        editable: true,
        eventLimit: true,
        titleFormat: "MMM D YYYY",
        defaultView: "agendaWeek",
        header: {
          left: "prev,next today",
          center: "title",
          right: "month,agendaWeek,agendaDay"
        },
        buttonText: {
          today: "Sot",
          month: "Muaji",
          week: "Java",
          day: "Dita"
        },
        views: {
          agenda: {
            eventLimit: 2
          }
        },
        allDaySlot: false,
        slotDuration: moment.duration("00:15:00"),
        slotLabelInterval: moment.duration("01:00:00"),
        firstDay: 1,
        selectable: true,
        selectHelper: true,
        events: this.loadedEvents,
        // eventSources: this.eventsService.fetchEvents().subscribe(events => {
        //   this.isFetching = false;
        //   console.log("\n [ constructor ] events: ", events);
        //   this.loadedEvents = events;

        //   console.log("\n [ constructor ] loadedEvents: ", this.loadedEvents);
        //   //return this.loadedEvents;
        // }),
        monthNames: [
          "Janar",
          "Shkurt",
          "Mars",
          "Prill",
          "Maj",
          "Qershor",
          "Korrik",
          "Gusht",
          "Shtator",
          "Tetor",
          "Nentor",
          "Dhjetor"
        ],
        monthNamesShort: [
          "Janar",
          "Shkurt",
          "Mars",
          "Prill",
          "Maj",
          "Qershor",
          "Korrik",
          "Gusht",
          "Shtator",
          "Tetor",
          "Nentor",
          "Dhjetor"
        ],
        dayNames: [
          "E Diell",
          "E Hene",
          "E Marte",
          "E Merkure",
          "E Enjte",
          "E Premte",
          "E Shtune"
        ],
        dayNamesShort: [
          "E Diell",
          "E Hene",
          "E Marte",
          "E Merkure",
          "E Enjte",
          "E Premte",
          "E Shtune"
        ],

        dayClick: (date, jsEvent, activeView) => {
          this.dayClick(date, jsEvent, activeView);
        },

        eventDragStart: (timeSheetEntry, jsEvent, ui, activeView) => {
          this.eventDragStart(timeSheetEntry, jsEvent, ui, activeView);
        },

        eventDragStop: (timeSheetEntry, jsEvent, ui, activeView) => {
          this.eventDragStop(timeSheetEntry, jsEvent, ui, activeView);
        }
      });
    console.log(
      "----------------------- Ending [ contructor ] ------------------------"
    );
  }

  onCreateEvents(eventData: { title: string; start: Date; end: Date }) {
    ///send HTTP posts
  }

  onFetchEvents() {
    this.getEvents();
    console.log("\n onFetchEvents this.loadedEvents: ", this.loadedEvents);
  }

  private getEvents() {
    console.log(
      "\n\n3)------------ Starting [ getEvents() ] function-------------------"
    );

    this.isFetching = true;
    this.eventsService.fetchEvents().subscribe(events => {
      this.isFetching = false;
      console.log("\n [ getEvents() ] events: ", events);
      this.loadedEvents = events;

      console.log("\n [ getEvents() ] loadedEvents: ", this.loadedEvents);
      console.log(
        "-------------------------Ending [ getEvents() ]----------------------"
      );
      return this.loadedEvents;
    });
  }

  ngOnInit() {
    console.log(
      "\n\n2) -----------------Starting [ ngOninit ]--------------------------"
    );
    this.getEvents();
    console.log(
      "\n [ngOnInit] this.defaultConfigurations: ",
      this.defaultConfigurations
    );
    console.log("\n [ngOnInit] this.loadedEvents: ", this.loadedEvents);
    ///this.defaultConfigurations.events = this.getEvents();
    $("#full-calendar").fullCalendar(this.defaultConfigurations);
    console.log(
      "-------------------------Ending [ ngOninit ]----------------------------"
    );
  }

  ngAfterViewInit() {
    console.log(
      "\n\n4)-----------------Starting [ ngAfterViewInit ]---------------------"
    );
    console.log(
      "\n [ ngAfterViewInit ] this.defaultConfigurations: ",
      this.defaultConfigurations
    );
    console.log(
      "\n [ ngAfterViewInit ] this.loadedEvents: ",
      this.loadedEvents
    );

    // $("#full-calendar").fullCalendar(this.defaultConfigurations);
    console.log(
      "-----------------------Ending [ ngAfterViewInit ]-----------------------"
    );
  }

  dayClick(date, jsEvent, activeView) {
    console.log("\n day click: ", date);
  }
  eventDragStart(timeSheetEntry, jsEvent, ui, activeView) {
    console.log("\n event drag start: ", timeSheetEntry);
  }
  eventDragStop(timeSheetEntry, jsEvent, ui, activeView) {
    console.log("\n event drag end: ", timeSheetEntry);
  }
}

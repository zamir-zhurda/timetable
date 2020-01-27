using System;
using System.Globalization;
namespace timetable.Resources
{
    public class EventResource
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
        public bool allDay { get; set; }

    }
}
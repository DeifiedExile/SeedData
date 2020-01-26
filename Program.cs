using System;
using System.Collections.Generic;
using System.Text;

namespace SeedData
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            // first create Locations list
            List<Location> Locations = new List<Location>()
            {
                new Location {LocationId = 1, Name = "Front Door"},
                new Location {LocationId = 2, Name = "Back Door"},
                new Location {LocationId = 3, Name = "Garage"},
                new Location {LocationId = 4, Name = "Bedroom"},                
                
            };
            // create date object containing current date/time
            DateTime localDate = DateTime.Now;
            // subtract 6 months from date
            DateTime eventDate = localDate.AddMonths(-6);

            // instantiate Random class
            Random rnd = new Random();
            // TODO: create list to store events (Events)
            List<Event> Events = new List<Event>();
            // loop for each day in the range from 6 months ago to today
            while (eventDate < localDate)
            {
                // TODO: random between 0 and 5 determines the number of events to occur on a given day
                int eventQuantity = rnd.Next(0, 6);
                for(int i = 0; i < eventQuantity; i++)
                {
                    int hours = rnd.Next(0, 24);
                    int minutes = rnd.Next(0, 60);
                    int seconds = rnd.Next(0, 60);
                    int locid = rnd.Next(1, 5);                    
                    Location location = Locations.Find(x => x.LocationId == locid);
                    
                    DateTime entryDate = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, hours, minutes, seconds);

                    Event eventEntry = new Event();
                    eventEntry.TimeStamp = entryDate;
                    eventEntry.Location = location;
                    eventEntry.LocationId = eventEntry.Location.LocationId;

                    Events.Add(eventEntry);
                    Events.Sort(CompareEventsByDate);
                    
                    
                    
                }
                eventDate = eventDate.AddDays(1);
                
                
                
                // add daily event to Events
                // TODO: add 1 day to eventDate
            }
            foreach (Event e in Events)
            {

                sb.AppendFormat("{0} - {1}\n", e.TimeStamp.ToString(), e.Location.Name);
            }
            Console.WriteLine(sb.ToString());
            

        }
        public static int CompareEventsByDate(Event e1, Event e2)
        {
            return e1.TimeStamp.CompareTo(e2.TimeStamp);

        }
    }
}

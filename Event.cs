using System;
using System.Collections.Generic;
using System.Text;

namespace SeedData
{
    class Event
    {
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Flagged { get; set; }
        // foreign key for location 
        public int LocationId { get; set; }
        // navigation property
        public Location Location { get; set; }

        
        
    }
}

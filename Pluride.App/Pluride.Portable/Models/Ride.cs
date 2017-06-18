using Pluride.App.Models;
using System;

namespace Pluride.App.Portable.Models
{
    public class Ride : TableData
    {
        public string DeparturePlace { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public string Information { get; set; }

        public string UserId { get; set; }
        
        public virtual User User { get; set; }

        public string EventId { get; set; }
        
        public virtual Event Event { get; set; }

        public Ride() { }

        public Ride(string idUser, string idEvent, string departurePlace, DateTime departureDateTime, string information)
        {
            UserId = idUser;
            EventId = idEvent;
            DeparturePlace = departurePlace;
            DepartureDateTime = departureDateTime;
            Information = information;
        }
    }
}

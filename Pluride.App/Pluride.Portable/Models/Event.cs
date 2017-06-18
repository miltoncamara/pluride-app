using Pluride.App.Models;
using System;

namespace Pluride.App.Portable.Models
{
    public class Event : TableData
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Link { get; set; }
        public string Picture { get; set; }
        public decimal? TicketCost { get; set; }
        public string Organizer { get; set; }
    }
}

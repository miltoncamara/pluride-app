using Pluride.App.Portable.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pluride.App.Portable.Models.Extensions
{
    public static class RideExtensions
    {
        public static IEnumerable<Grouping<string, Ride>> GroupByName(this IEnumerable<Ride> rides)
        {
            return from e in rides
                   orderby e.Event.Start
                   group e by e.Event.Name
                into eventGroup
                   select new Grouping<string, Ride>(eventGroup.Key, eventGroup);
        }
    }
}

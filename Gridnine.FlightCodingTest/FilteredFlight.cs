using System;
using System.Collections.Generic;
using System.Text;

namespace Gridnine.FlightCodingTest
{
    public class FilteredFlight
    {
        private IList<Flight> flights;
        public FilteredFlight(IList<Flight> _flights)
        {
            flights = _flights;
        }
        public IList<Flight> GetFilterFlights(IFilter filter)
        {
            return filter.GetFilteredFlight(flights);
        }
    }
}

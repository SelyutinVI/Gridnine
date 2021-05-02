using System;
using System.Collections.Generic;
using System.Text;

namespace Gridnine.FlightCodingTest
{
    public interface IFilter
    {
        IList<Flight> GetFilteredFlight(IList<Flight> flights);
    }
}

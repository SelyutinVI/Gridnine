using System;
using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    //вылет до текущего момента времени
    public class FilterAfterNow : IFilter
    {
        public IList<Flight> GetFilteredFlight(IList<Flight> flights)
        {
            IList<Flight> tmp = new List<Flight>();
            foreach (var flight in flights)
            {
                foreach (var segment in flight.Segments)
                {
                    if (segment.DepartureDate > DateTime.Now)
                    {
                        tmp.Add(flight);
                        break;
                    }
                }
            }
            return tmp;
        }
    }

    //имеются сегменты с датой прилёта раньше даты вылета
    public class FilterArrivalAfterDeparture : IFilter
    {
        public IList<Flight> GetFilteredFlight(IList<Flight> flights)
        {
            IList<Flight> tmp = new List<Flight>();
            foreach (var flight in flights)
            {
                foreach (var segment in flight.Segments)
                {
                    if (segment.DepartureDate < segment.ArrivalDate)
                    {
                        tmp.Add(flight);
                        break;
                    }
                }
            }
            return tmp;
        }
    }

    //общее время, проведённое на земле превышает два часа (время на земле — это интервал между прилётом одного сегмента и вылетом следующего за ним)
    public class FilterGroundTime : IFilter
    {
        public IList<Flight> GetFilteredFlight(IList<Flight> flights)
        {
            IList<Flight> tmp = new List<Flight>();
            foreach (var flight in flights)
            {
                TimeSpan time = new TimeSpan();
                for(int i = 0; i < flight.Segments.Count-1; i++)
                {
                    time += flight.Segments[i + 1].DepartureDate - flight.Segments[i].ArrivalDate;
                }
                if(time < new TimeSpan(2,0,0))
                {
                    tmp.Add(flight);
                }
            }
            return tmp;
        }
    }
}

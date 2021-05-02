using System;
using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            var newFlight = flightBuilder.GetFlights();
            PrintFlight(newFlight);

            FilteredFlight ff = new FilteredFlight(newFlight);
            Console.WriteLine();
            Console.WriteLine("Дата вылета после текущей");
            PrintFlight(ff.GetFilterFlights(new FilterAfterNow()));
            Console.WriteLine();
            Console.WriteLine("Дата вылета после прилёта");
            PrintFlight(ff.GetFilterFlights(new FilterArrivalAfterDeparture()));
            Console.WriteLine();
            Console.WriteLine("Время на земле меньше 2 часов");
            PrintFlight(ff.GetFilterFlights(new FilterGroundTime()));
        }
        static void PrintFlight(IList<Flight> flights)
        {
            int n = 1;
            foreach (var flight in flights)
            {
                Console.WriteLine("Перелёт №" + n);
                foreach (var segment in flight.Segments)
                {
                    Console.WriteLine("Время вылета:" + segment.DepartureDate + " Время посадки:" + segment.ArrivalDate);
                }
                n++;
            }
        }

    }
}

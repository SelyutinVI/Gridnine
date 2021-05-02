using NUnit.Framework;
using System.Collections.Generic;

namespace Gridnine.FlightCodingTest.Tests
{
    public class Tests
    {
        [Test]
        public void FilterAfterNowTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            var expected = flightBuilder.GetFlights();
            expected.RemoveAt(2);

            FilteredFlight ff = new FilteredFlight(flightBuilder.GetFlights());
            var actual = ff.GetFilterFlights(new FilterAfterNow());
            FlightsEquals(expected, actual);
        }

        [Test]
        public void FilterArrivalAfterDepartureTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            var expected = flightBuilder.GetFlights();
            expected.RemoveAt(3);

            FilteredFlight ff = new FilteredFlight(flightBuilder.GetFlights());
            var actual = ff.GetFilterFlights(new FilterArrivalAfterDeparture());
            FlightsEquals(expected, actual);
        }
        [Test]
        public void FilterGroundTimeTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            var expected = flightBuilder.GetFlights();
            expected.RemoveAt(5);
            expected.RemoveAt(4);

            FilteredFlight ff = new FilteredFlight(flightBuilder.GetFlights());
            var actual = ff.GetFilterFlights(new FilterGroundTime());
            FlightsEquals(expected,actual);
        }

        private void FlightsEquals(IList<Flight> expected, IList<Flight> actual)
        {
            try
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    for (int j = 0; j < expected[i].Segments.Count; j++)
                    {
                        if (expected[i].Segments[j].ArrivalDate != actual[i].Segments[j].ArrivalDate && expected[i].Segments[j].DepartureDate != actual[i].Segments[j].DepartureDate)
                            Assert.Fail();
                    }
                }
            }
            catch
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}
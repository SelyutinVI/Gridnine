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
            try { 
                for(int i =0; i<expected.Count;i++)
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

        [Test]
        public void FilterArrivalAfterDepartureTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            var expected = flightBuilder.GetFlights();
            expected.RemoveAt(3);

            FilteredFlight ff = new FilteredFlight(flightBuilder.GetFlights());
            var actual = ff.GetFilterFlights(new FilterArrivalAfterDeparture());
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
        [Test]
        public void FilterGroundTimeTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            var expected = flightBuilder.GetFlights();
            expected.RemoveAt(5);
            expected.RemoveAt(4);

            FilteredFlight ff = new FilteredFlight(flightBuilder.GetFlights());
            var actual = ff.GetFilterFlights(new FilterGroundTime());
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
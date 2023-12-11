using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    internal class FlightSearch
    {

        private string FlightNumber;
        private string Airline;
        private string Destination;
        private DateTime DepartureTime;
        private DateTime ArrivalTime;
        private FlightStatus Status;
        private TimeSpan Duration;
        private string AircraftType;
        private string Terminal;

  
        public FlightSearch(string Airline) { this.Airline = Airline; }
  
        public FlightSearch(FlightStatus Status) { this.Status = Status; }

        public FlightSearch(DateTime DepartureTime) { this.DepartureTime = DepartureTime;  }

        public FlightSearch(DateTime DepartureTime, DateTime ArrivalTime, string Destination) { this.DepartureTime = DepartureTime; this.ArrivalTime = ArrivalTime; this.Destination = Destination; }

        public FlightSearch(DateTime StartTime, DateTime EndTime) 
        {
            
            TimeSpan Duration = EndTime - StartTime; this.Duration = Duration; 
        }
        public FlightSearch() 
        {
            DateTime start, end;
            end = DateTime.Now; 
            start = DateTime.Now.AddHours(-1); 
            TimeSpan  Duration = end - start; this.Duration = Duration;
        }

        public bool FindAirline(Flight f)
        { 
            return f.Airline.Equals(Airline);
        }
        public bool FindStatus(Flight f)
        {
            return f.Status.Equals(Status);
        }
        public bool FindDeparture(Flight f)
        {
            return f.DepartureTime.Equals(DepartureTime);
        }
        public bool FindTimeDestiantion(Flight f)
        {
            return f.DepartureTime.Equals(DepartureTime) && f.ArrivalTime.Equals(ArrivalTime) && f.Destination.Equals(Destination);
        }
        public bool FindTime(Flight f)
        {
            return f.Duration.Equals(Duration);
        }



    }
}

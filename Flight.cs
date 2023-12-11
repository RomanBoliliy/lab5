using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum FlightStatus
{

    OnTime,
    Delayed,
    Cancelled,
    Boarding,
    InFlight

}


namespace lab_5
{
    internal class Flight
    {
        private string flightNumber;
        private string airline;
        private string destination;
        private DateTime departureTime;
        private DateTime arrivalTime;
        private string gate;
        private FlightStatus status;
        private TimeSpan duration;
        private string aircraftType;
        private string terminal;

        public string FlightNumber { get { if (flightNumber == null) { return "0"; } else { return flightNumber; } } set { flightNumber = value; } }
        public string Airline { get { if (airline == null) { return "0"; } else { return airline; } } set { airline = value; } }
        public string Destination { get { if (destination == null) { return "0"; } else { return destination; } } set { destination = value; } }
        public DateTime DepartureTime { get { if (departureTime == null) { return new DateTime(); } else { return departureTime; } } set { departureTime = value; } }
        public DateTime ArrivalTime { get { if (arrivalTime == null) { return new DateTime(); } else { return arrivalTime; } } set { arrivalTime = value; } }
        public string Gate{ get { if (gate == null) { return "0"; } else { return gate; } } set { gate = value; } }
        public FlightStatus Status { get { if (status == null) { return FlightStatus.OnTime; } else { return status; } } set { status = value; } }
        public TimeSpan Duration { get { if (duration == null) { return new TimeSpan(); } else { return duration; } } set { duration = value; } }
        public string AircraftType { get { if (aircraftType == null) { return "0"; } else { return aircraftType; } } set { aircraftType = value; } }
        public string Terminal { get { if (terminal == null) { return "0"; } else { return terminal; } } set { terminal = value; } }





        public void Print() {
            Console.WriteLine("FlightNumber: " + flightNumber + "\nAirline: " + airline + "\nDestination: " + destination + "\nDepartureTime: " + departureTime + "\nArrivalTime: " + arrivalTime + "\nStatus: " + status + "\nDuration: " + duration + "\nAircraftType: " + aircraftType + "\nTerminal: " + terminal+ "\n\n");
        }
        public Flight() {
            this.airline = null;
            this.destination = null;
            this.departureTime = new DateTime();
            this.arrivalTime = new DateTime();
            this.gate = null;
            this.status = FlightStatus.OnTime;
            this.duration = departureTime - arrivalTime;
            this.aircraftType = null;
            this.terminal = null;

        }
        public Flight(string FlightNumber, string Airline, string Destination, DateTime DepartureTime, DateTime ArrivalTime, string Gate, FlightStatus Status, TimeSpan Duration, string AircraftType, string Terminal) 
        {
        this.flightNumber = FlightNumber;
            this.airline = Airline;
            this.destination = Destination;
            this.departureTime = DepartureTime;
            this.arrivalTime = ArrivalTime;
            this.gate = Gate;
            this.status = Status;
            this.duration = DepartureTime - ArrivalTime;
            this.aircraftType = AircraftType;
            this.terminal = Terminal; 
        }
        public static bool operator ==(Flight one, Flight two) {
            if (((object)one) == null || ((object)two) == null)
                return Object.Equals(one, two);

            return one.Equals(two);
        }
        public static bool operator !=(Flight one, Flight two) {
            if (((object)one) == null || ((object)two) == null)
                return ! Object.Equals(one, two);

            return ! one.Equals(two);
        }
        public bool Equals(Flight other) {
            if (this.flightNumber == other.flightNumber && this.airline == other.airline && this.destination == other.destination && this.departureTime == other.departureTime
                   && this.arrivalTime == other.arrivalTime && this.gate == other.gate && this.status == other.status && this.duration == other.duration && this.aircraftType == other.aircraftType && this.terminal == other.terminal) 
            {
                return true;
            } 
            else 
            {
                return false;
            }
            
          }
        public override bool Equals(Object obj) {
            if (obj == null)
                return false;

            Flight flightObj = obj as Flight;
            if (flightObj == null)
                return false;
            else
                return Equals(flightObj);

        }

        public int CompareTo(Flight comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;
            else
                return this.departureTime.CompareTo(comparePart.departureTime);
        }
    }
}

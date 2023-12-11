using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace lab_5
{
    internal class Flight
    {
        //Поля, в яких зберігаються дані про польотм
        private string FlightNumber;
        private string Airline;
        private string Destination;
        private DateTime DepartureTime;
        private DateTime ArrivalTime;
        private string Gate;
        private FlightStatus Status;
        private TimeSpan Duration;
        private string AircraftType;
        private string Terminal;
        
        //гет сет для приватних полів
        public string flightNumber { get {  return FlightNumber; } set { FlightNumber = value; } }
        public string airline { get { return Airline;  } set { Airline = value; } }
        public string destination { get { return Destination; }  set { Destination = value; } }
        public DateTime departureTime { get { return DepartureTime; }  set { DepartureTime = value; } }
        public DateTime arrivalTime { get { return ArrivalTime; }  set { ArrivalTime = value; } }
        public string gate { get {return Gate;  } set { Gate = value; } }
        public FlightStatus status { get { return Status; }  set { Status = value; } }
        public TimeSpan duration { get { return Duration; }  set { Duration = value; } }
        public string aircraftType { get {return AircraftType; }  set { AircraftType = value; } }
        public string terminal { get { return Terminal;  } set { Terminal = value; } }





        public void Print() //метод для виводу вмісту одного польоту
        {
            Console.WriteLine("FlightNumber: " + FlightNumber + "\nAirline: " + Airline + "\nDestination: " + Destination + "\nDepartureTime: " + DepartureTime + "\nArrivalTime: " + ArrivalTime + "\nStatus: " + Status + "\nDuration: " + Duration + "\nAircraftType: " + AircraftType + "\nTerminal: " + Terminal+ "\n\n");
        }

        //Конструктор
        public Flight(string FlightNumber, string Airline, string Destination, DateTime DepartureTime, DateTime ArrivalTime, string Gate, FlightStatus Status, TimeSpan Duration, string AircraftType, string Terminal) 
        {
        this.FlightNumber = FlightNumber;
            this.airline = Airline;
            this.destination = Destination;
            this.departureTime = DepartureTime;
            this.arrivalTime = ArrivalTime;
            this.gate = Gate;
            this.status = Status;     
            this.duration = ArrivalTime - DepartureTime;
            this.aircraftType = AircraftType;
            this.terminal = Terminal; 
        }
        public static bool operator ==(Flight one, Flight two) {
            if (((object)one) == null || ((object)two) == null)
                return Object.Equals(one, two);

            return one.Equals(two);
        }

        // Перевантажені методи == != та Equal для реалізації сортування та пошуку
        public static bool operator !=(Flight one, Flight two) {
            if (((object)one) == null || ((object)two) == null)
                return ! Object.Equals(one, two);

            return ! one.Equals(two);
        }
        public bool Equals(Flight other) {
            if (this.FlightNumber == other.FlightNumber && this.Airline == other.Airline && this.Destination == other.Destination && this.DepartureTime == other.DepartureTime
                   && this.ArrivalTime == other.ArrivalTime && this.Gate == other.Gate && this.Status == other.Status && this.Duration == other.Duration && this.AircraftType == other.AircraftType && this.Terminal == other.Terminal) 
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
            if (comparePart == null)
                return 1;
            else
                return this.DepartureTime.CompareTo(comparePart.DepartureTime);
        }
    }
}

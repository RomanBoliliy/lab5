using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab_5
{
   
    internal class FlightInformationSystem
    {
        List<Flight> Fly = new List<Flight>();
        string path = @"C:\Users\Роман\Desktop\lab5\lab_5\bin\Debug\net7.0\flights_data.json";

        //public void open() { Process.Start(new ProcessStartInfo(path) { UseShellExecute = true }); }\


        public  void deserialize() {

            using (FileStream f = new FileStream(path, FileMode.OpenOrCreate))
            {

                
                var flights = JsonSerializer.DeserializeAsync<List<Flight>>(f);
               // Console.WriteLine($"Airline: {flights.Result.Last().Airline} Time: {flights.Result.Last().DepartureTime}");
               // Fly.Add(flights.Result.Last());
                Fly = flights.Result;
                
            };
           

        }

        public async void serialize()
        {
            using (FileStream f = new FileStream(path, FileMode.Create ))
            {


                //List<Flight> NewFly = new List<Flight>(FlightNumber, Airline, Destination, DepartureTime, ArrivalTime, Gate, Status, Duration, AircraftType, Terminal);
                //Fly.Add(NewFly);
                await JsonSerializer.SerializeAsync<List<Flight>>(f, Fly);
            }
            //return Fly;
        }

        public int Add()
        {
            Console.WriteLine("Add()");
            Flight NewFly = new Flight();
            Fly.Add(NewFly);
     
            return Fly.Count();
        }
        public int Add(string FlightNumber, string Airline, string Destination, DateTime DepartureTime, DateTime ArrivalTime, string Gate, FlightStatus Status, TimeSpan Duration, string AircraftType, string Terminal)
        {
            Console.WriteLine("Add(...)");
            Flight NewFly = new Flight(FlightNumber, Airline, Destination, DepartureTime, ArrivalTime, Gate, Status, Duration, AircraftType, Terminal);
            Fly.Add(NewFly);
   
            return Fly.Count();
        }

        public int Delete()
        {
            Console.WriteLine("Delete()");
            Flight NewFly = new Flight();
            Fly.Remove(NewFly);
            NewFly.Print();
            return Fly.Count(); 
        }
        public int Delete(string FlightNumber, string Airline, string Destination, DateTime DepartureTime, DateTime ArrivalTime, string Gate, FlightStatus Status, TimeSpan Duration, string AircraftType, string Terminal)
        {
            Console.WriteLine("Delete(...)");
            Flight NewFly = new Flight(FlightNumber, Airline, Destination, DepartureTime, ArrivalTime, Gate, Status, Duration, AircraftType, Terminal);
            Fly.Remove(NewFly);
            NewFly.Print();
            return Fly.Count(); 
        }

        public List<Flight> Search()
        {
            List<Flight> FlySearch = new List<Flight>();

            var fl = new FlightSearch();
            
            FlySearch = Fly.FindAll(fl.FindTime);

            Print(FlySearch);

            Fly.Sort(delegate (Flight x, Flight y)
            {
                if (x.ArrivalTime == null && y.ArrivalTime == null) return 0;
                else if (x.ArrivalTime == null) return -1;
                else if (y.ArrivalTime == null) return 1;
                else return x.ArrivalTime.CompareTo(y.ArrivalTime);
            });

            return FlySearch;

        }
        public List<Flight> Search(string Airline) 
        {
            List<Flight> FlySearch = new List<Flight>();

            var fl = new FlightSearch(Airline);

            FlySearch = Fly.FindAll(fl.FindAirline);

            Fly.Sort(delegate (Flight x, Flight y)
            {
                if (x.DepartureTime == null && y.DepartureTime == null) return 0;
                else if (x.DepartureTime == null) return -1;
                else if (y.DepartureTime == null) return 1;
                else return x.DepartureTime.CompareTo(y.DepartureTime);
            });

            return FlySearch;

        }

        public List<Flight> Search(FlightStatus Status)
        {
            List<Flight> FlySearch = new List<Flight>();

            var fl = new FlightSearch(Status);

            FlySearch = Fly.FindAll(fl.FindStatus);

            Fly.Sort(delegate (Flight x, Flight y)
            {
                if (x.ArrivalTime == null && y.ArrivalTime == null) return 0;
                else if (x.ArrivalTime == null) return -1;
                else if (y.ArrivalTime == null) return 1;
                else return x.ArrivalTime.CompareTo(y.ArrivalTime);
            });

            return FlySearch;

        }

        public List<Flight> Search(DateTime DepartureTime)
        {
            List<Flight> FlySearch = new List<Flight>();

            var fl = new FlightSearch(DepartureTime);

            FlySearch = Fly.FindAll(fl.FindDeparture);

            Fly.Sort(delegate (Flight x, Flight y)
            {
                if (x.DepartureTime == null && y.DepartureTime == null) return 0;
                else if (x.DepartureTime == null) return -1;
                else if (y.DepartureTime == null) return 1;
                else return x.DepartureTime.CompareTo(y.DepartureTime);
            });

            return FlySearch;

        }

        public List<Flight> Search(DateTime DepartureTime, DateTime ArrivalTime, string Destination)
        {
            List<Flight> FlySearch = new List<Flight>();

            var fl = new FlightSearch(DepartureTime,ArrivalTime,Destination);

            FlySearch = Fly.FindAll(fl.FindTimeDestiantion);

            Fly.Sort(delegate (Flight x, Flight y)
            {
                if (x.DepartureTime == null && y.DepartureTime == null) return 0;
                else if (x.DepartureTime == null) return -1;
                else if (y.DepartureTime == null) return 1;
                else return x.DepartureTime.CompareTo(y.DepartureTime);
            });

            return FlySearch;

        }

        public List<Flight> Search(DateTime StartTime, DateTime EndTime)
        {
            List<Flight> FlySearch = new List<Flight>();

            var fl = new FlightSearch(StartTime,EndTime);

            FlySearch = Fly.FindAll(fl.FindTime);

            Fly.Sort(delegate (Flight x, Flight y)
            {
                if (x.ArrivalTime == null && y.ArrivalTime == null) return 0;
                else if (x.ArrivalTime == null) return -1;
                else if (y.ArrivalTime == null) return 1;
                else return x.ArrivalTime.CompareTo(y.ArrivalTime);
            });

            return FlySearch;
        }

        public List<Flight> Sort() 
        {
            Console.WriteLine("Before");
            Print(Fly);
         
            Console.WriteLine("After");

            Fly.Sort(delegate (Flight x, Flight y)
            {
                if (x.DepartureTime == null && y.DepartureTime == null) return 0;
                else if (x.DepartureTime == null) return -1;
                else if (y.DepartureTime == null) return 1;
                else return x.DepartureTime.CompareTo(y.DepartureTime);
            });

            Print(Fly);
            return Fly;
        }
        public int GetCount() { return Fly.Count(); }
        public void Print(List<Flight> Fly ) { 
        foreach (var fl in Fly) { fl.Print(); }
        }
        public void Print()
        {
            foreach (var fl in Fly) { fl.Print(); }
        }

    }
}

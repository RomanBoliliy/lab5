using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace lab_5
{

    internal class FlightInformationSystem
    {
        List<Flight> flights = new List<Flight>();

        string path = @"C:\Users\Роман\Desktop\lab5\lab_5\bin\Debug\net7.0\flights_data.json"; //Шлях до файлу

        public class FlightData //гет сет для списку
        {
            public List<Flight> Flights { get; set; }
        }

        public void Deserialize() // Метод для десереалізації
        {
            try
            {
                string jsonData = File.ReadAllText(path);
                var flightsData = JsonConvert.DeserializeObject<FlightData>(jsonData);
                flights = flightsData.Flights;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while dowloading Data: {ex.Message}");
            }

        }

        public void Serialize()// Метод для сереалізації
        {

            var flightsData = new FlightData { Flights = flights };
            JsonConvert.SerializeObject(flightsData, Formatting.Indented);
            File.WriteAllText(path, JsonConvert.SerializeObject(flightsData, Formatting.Indented));
        }
        //Метод для додавання
        public int Add(string FlightNumber, string Airline, string Destination, DateTime DepartureTime, DateTime ArrivalTime, string Gate, FlightStatus Status, TimeSpan Duration, string AircraftType, string Terminal)
        {
            Console.WriteLine("Add(...)");
            Flight NewFly = new Flight(FlightNumber, Airline, Destination, DepartureTime, ArrivalTime, Gate, Status, Duration, AircraftType, Terminal);
            flights.Add(NewFly);

            return flights.Count();
        }
        //Метод для видалення
        public int Delete(string FlightNumber, string Airline, string Destination, DateTime DepartureTime, DateTime ArrivalTime, string Gate, FlightStatus Status, TimeSpan Duration, string AircraftType, string Terminal)
        {
            Console.WriteLine("Delete(...)");
            Flight NewFly = new Flight(FlightNumber, Airline, Destination, DepartureTime, ArrivalTime, Gate, Status, Duration, AircraftType, Terminal);
            flights.Remove(NewFly);
            NewFly.Print();
            return flights.Count();
        }
        //Методи для пошуку за різними полями, які вказані в шапці функції
        public List<Flight> Search() 
        {

            var fl = new FlightSearch();

            flights = flights.FindAll(fl.FindTime);

            flights.Sort(delegate (Flight x, Flight y)
            {
                if (x.arrivalTime == null && y.arrivalTime == null) return 0;
                else if (x.arrivalTime == null) return -1;
                else if (y.arrivalTime == null) return 1;
                else return x.arrivalTime.CompareTo(y.arrivalTime);
            });
        
            return flights;

        } 
        public List<Flight> Search(string Airline)
        {
       
            var fl = new FlightSearch(Airline);

            flights = flights.FindAll(fl.FindAirline);

            flights.Sort(delegate (Flight x, Flight y)
            {
                if (x.departureTime == null && y.departureTime == null) return 0;
                else if (x.departureTime == null) return -1;
                else if (y.departureTime == null) return 1;
                else return x.departureTime.CompareTo(y.departureTime);
            });

            return flights;

        }

        public List<Flight> Search(FlightStatus Status)
        {

            var fl = new FlightSearch(Status);

            flights = flights.FindAll(fl.FindStatus);

            flights.Sort(delegate (Flight x, Flight y)
            {
                if (x.arrivalTime == null && y.arrivalTime == null) return 0;
                else if (x.arrivalTime == null) return -1;
                else if (y.arrivalTime == null) return 1;
                else return x.arrivalTime.CompareTo(y.arrivalTime);
            });

            return flights;

        }

        public List<Flight> Search(DateTime DepartureTime)
        {

            var fl = new FlightSearch(DepartureTime);

            flights = flights.FindAll(fl.FindDeparture);

            flights.Sort(delegate (Flight x, Flight y)
            {
                if (x.departureTime == null && y.departureTime == null) return 0;
                else if (x.departureTime == null) return -1;
                else if (y.departureTime == null) return 1;
                else return x.departureTime.CompareTo(y.departureTime);
            });

            return flights;
        }

        public List<Flight> Search(DateTime DepartureTime, DateTime ArrivalTime, string Destination)
        {

            var fl = new FlightSearch(DepartureTime, ArrivalTime, Destination);

            flights = flights.FindAll(fl.FindTimeDestiantion);

            flights.Sort(delegate (Flight x, Flight y)
            {
                if (x.departureTime == null && y.departureTime == null) return 0;
                else if (x.departureTime == null) return -1;
                else if (y.departureTime == null) return 1;
                else return x.departureTime.CompareTo(y.departureTime);
            });

            return flights;

        }

        public List<Flight> Search(DateTime StartTime, DateTime EndTime)
        {
            var fl = new FlightSearch(StartTime, EndTime);

            flights = flights.FindAll(fl.FindTime);

            flights.Sort(delegate (Flight x, Flight y)
            {
                if (x.arrivalTime == null && y.arrivalTime == null) return 0;
                else if (x.arrivalTime == null) return -1;
                else if (y.arrivalTime == null) return 1;
                else return x.arrivalTime.CompareTo(y.arrivalTime);
            });

            return flights;
        }

        public List<Flight> Sort() // Сортування
        {
            Console.WriteLine("Before");
            Print(flights);

            Console.WriteLine("After");

            flights.Sort(delegate (Flight x, Flight y)
            {
                if (x.departureTime == null && y.departureTime == null) return 0;
                else if (x.departureTime == null) return -1;
                else if (y.departureTime == null) return 1;
                else return x.departureTime.CompareTo(y.departureTime);
            });

            Print(flights);
            return flights;
        } 
        public int GetCount() { return flights.Count(); } //Кількість рядків
        public void Print(List<Flight> Fly)//Вивід результатів
        {
            foreach (var fl in Fly) { fl.Print(); }
        }
        public void Print() //Вивід результатів
        {
            foreach (var fl in flights) { fl.Print(); }
        } 
    }
}

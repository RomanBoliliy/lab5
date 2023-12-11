
using lab_5;
using System;

FlightInformationSystem flightInformationSystem = new FlightInformationSystem();
DateTime d = new DateTime();
DateTime t = new DateTime();
TimeSpan span = d - t;
//flightInformationSystem.Add();
flightInformationSystem.Add("1", "2", "1", d.AddYears(1), t, "1", FlightStatus.InFlight, span, "1", "1");
flightInformationSystem.Add("1", "1", "1", d, t.AddYears(1), "1", FlightStatus.Cancelled, span, "1", "1");
//flightInformationSystem.Add("1", "1", "1", d.AddYears(2), t, "1",FlightStatus.Cancelled, span, "1", "1");
//flightInformationSystem.Add("1", "1", "1", d.AddYears(5), t, FlightStatus.Cancelled, span, "1", "1");
//Console.WriteLine("Start search\n");

//Console.WriteLine(flightInformationSystem.Search(d,t));
//flightInformationSystem.Search("1");
//flightInformationSystem.Print();

//flightInformationSystem.serialize("1", "2", "1", d.AddYears(1), t, FlightStatus.Cancelled, span, "1", "1");

//flightInformationSystem.open();
//flightInformationSystem.deserialize();
//flightInformationSystem.serialize("1", "1", "1", d.AddYears(1), t, FlightStatus.Cancelled, span, "1", "1");
//flightInformationSystem.serialize("2", "2", "2", d.AddYears(2), t, "2", FlightStatus.Cancelled, span, "1", "1");
flightInformationSystem.serialize();
//flightInformationSystem.deserialize();
flightInformationSystem.Print();

//[
//  {
//    "FlightNumber": "1",
//    "Airline": "1",
//    "Destination": "1",
//    "DepartureTime": "0003-01-01T00:00:00",
//    "ArrivalTime": "0001-01-01T00:00:00",
//    "Gate": "1",
//    "Status": 2,
//    "Duration": "730.00:00:00",
//    "AircraftType": "1",
//    "Terminal": "1"
//  }
//]




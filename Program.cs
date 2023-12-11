using lab_5;
using System;



FlightInformationSystem flightInformationSystem = new FlightInformationSystem();
int Before = flightInformationSystem.GetCount();

flightInformationSystem.Deserialize();

int InProcess= flightInformationSystem.GetCount();

flightInformationSystem.Search(FlightStatus.Cancelled);

flightInformationSystem.Serialize();

int After= flightInformationSystem.GetCount();

flightInformationSystem.Print();

Console.WriteLine("Before: " + Before + ", In Process: " + InProcess + ", After: " + After);




enum FlightStatus
{

    OnTime,
    Delayed,
    Cancelled,
    Boarding,
    InFlight

}



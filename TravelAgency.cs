using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Midterm
{
    internal class TravelAgency
    {
        static void Main(string[] args)
        {
            
           
            List<Itinerary> itineraries = new List<Itinerary>();

            Console.WriteLine("Welcome to Algonquin College Student Travel Agency!");

            Console.Write("\nEnter V to view all itineraries, A to add a new itinerary. \n" +
                            "      C to change an existing itinerary, and E to exit: ");
            string action = Console.ReadLine();
            Console.WriteLine();


            //Write your code here to implement the functionality as required


            while (true) 
            {
                switch (action.ToUpper())
                {
                    case "A":
                        Console.WriteLine("Please enter passenger name: ");
                        string passengerName = Console.ReadLine();

                        if (string.IsNullOrEmpty(passengerName))
                        {
                            Console.WriteLine("Passenger name cannot be empty.");
                            continue;
                        }

                        Console.WriteLine("Please enter departure city: ");
                        string departureCity = Console.ReadLine();

                        Console.WriteLine("Please enter arriving city: ");
                        string arrivingCity = Console.ReadLine();

                        Itinerary itinerary = new Itinerary(passengerName, departureCity, arrivingCity);
                        itineraries.Add(itinerary);
                        break;

                    case "V":
                        if (itineraries.Count == 0)
                        {
                            Console.WriteLine("No itineraries available.");
                            continue;
                        }

                        Console.WriteLine("Itineraries:");

                        for (int i = 0; i < itineraries.Count; i++)
                        {
                            Itinerary currentItinerary = itineraries[i];
                            Console.WriteLine($"[{i}] - Passenger: {currentItinerary.PassengerName}, Departure: {currentItinerary.DepartureCity}, Arriving: {currentItinerary.ArrivingCity}, Cost: {currentItinerary.Cost}");
                        }
                        break;

                    case "C":
                        if (itineraries.Count == 0)
                        {
                            Console.WriteLine("No itineraries available to change.");
                            continue;
                        }

                        Console.WriteLine("Enter the itinerary number to change: ");
                        if (int.TryParse(Console.ReadLine(), out int itineraryNumber))
                        {
                            int index = itineraryNumber ;

                            if (index >= 0 && index < itineraries.Count)
                            {
                                Itinerary selectedItinerary = itineraries[index];
                                Console.WriteLine("Enter new departure city: ");
                                string newDepartureCity = Console.ReadLine();

                                Console.WriteLine("Enter new arriving city: ");
                                string newArrivingCity = Console.ReadLine();

                                try
                                {
                                    selectedItinerary.ChangeItinerary(newDepartureCity, newArrivingCity);
                                    Console.WriteLine("Itinerary information is changed .");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"Failed to change : {e.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid itinerary number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid itinerary number.");
                        }
                        break;

                    case "E":
                        Console.WriteLine("\nThank you for using Algonquin College Student Travel Agency!");
                        Console.WriteLine("Press the Enter key to exit.");
                        Console.ReadLine();
                        return;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
                Console.Write("\nEnter V to view all itineraries, A to add a new itinerary. \n" +
                            "      C to change an existing itinerary, and E to exit: ");
                action = Console.ReadLine();
                Console.WriteLine();

            }

        }
    }
}

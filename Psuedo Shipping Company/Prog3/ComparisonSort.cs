// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018
// By: D7090

//This class creates numerous address and parcel objects, stores the parcel objects in a list and then sorts and outputs the parcel objects in multiple different ways. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UPVApp
{
    class ComparisonSort
    {
        //Precondition: ComparisonSort.cs is ran as entry point
        //Postcondition: List of parcel objects in initialized and numerous parcel objects are created and added to the parcel list to be sorted and output in numerous manners 
        public static void Main()
        {
            List<Parcel> parcelList = new List<Parcel>(); //List of parcels to hold parcel objects

            //Creates numerous Address objects
            Address a1 = new Address("ron", "19291 Ramsey dr", "Lexington", "KY", 20194);
            Address a2 = new Address("sam", "19291 ree dr", "Louisville", "KY", 20184);
            Address a3 = new Address("lee", "0912 Brubeck dr", "Smithtown", "KY", 20111);
            Address a4 = new Address("sam", "19291 ree dr", "Louisville", "KY", 20364);
            Address a5 = new Address("Bill", "5932 Kline st", "Louisville", "KY", 40012);
            Address a6 = new Address("tess", "19230 Yanny Blvd", "Louisville", "KY", 91901);
            Address a7 = new Address("Jill", "84102 Lee st", "Louisville", "KY", 41122);
            Address a8 = new Address("Ookla", "4812 Tree way", "Louisville", "KY", 40223);

            //Creates numerous parcel objects
            GroundPackage gp1 = new GroundPackage(a1,a2,2.3,12,11,9);
            GroundPackage gp2 = new GroundPackage(a3, a4, 3, 1, 12, 19);
            GroundPackage gp3 = new GroundPackage(a5, a6, 1, 7, 13, 11);
            NextDayAirPackage nd1 = new NextDayAirPackage(a5, a6, 1.2, 2.5, 12, 8.5, 20);
            NextDayAirPackage nd2 = new NextDayAirPackage(a7, a8, 7, 11, 22, 13, 91);
            NextDayAirPackage nd3 = new NextDayAirPackage(a1, a2, 8.3, 2.5, 63,11,5);
            TwoDayAirPackage td1 = new TwoDayAirPackage(a1, a8, 12, 5, 1, 31, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage td2 = new TwoDayAirPackage(a2, a7, 19, 32, 11, 14, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage td3 = new TwoDayAirPackage(a4, a3, 4, 6, 8, 12, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage td4 = new TwoDayAirPackage(a7, a1, 6.4, 3.7, 12.1, 8.87, TwoDayAirPackage.Delivery.Saver);

            //Adds test data to list of parcels
            parcelList.Add(gp1);
            parcelList.Add(gp2);
            parcelList.Add(gp3);
            parcelList.Add(nd1);
            parcelList.Add(nd2);
            parcelList.Add(nd3);
            parcelList.Add(td1);
            parcelList.Add(td2);
            parcelList.Add(td3);
            parcelList.Add(td4);

            WriteLine("Original List Cost: "); // Output Title 
            WriteLine();
            WriteLine();
            foreach (Parcel p in parcelList) //Writes original list of parcel objects to console
            {
                WriteLine($"{p.CalcCost():C}"); // prints Parcel cost to console
            }
            WriteLine();
            WriteLine();

            parcelList.Sort(); // Sort - uses natural order
            WriteLine("Sorted list Cost (natural order): "); // Output Title 
            WriteLine();
            WriteLine();
            foreach (Parcel p in parcelList) //Writes sorted (natural order) list
            {
                WriteLine($"{p.CalcCost():C}"); // Prints parcel cost to console
            }
            WriteLine();
            WriteLine();

            parcelList.Sort(new ParcelDescending()); //Sort - user specified Parcel Descending class

            WriteLine("Sorted list Destination Zip Code Descending: "); // Output Title 
            WriteLine();
            WriteLine();
            foreach (Parcel p in parcelList)
            {
                WriteLine($"{p.DestinationAddress.Zip}"); //Prints parcel destination Zip Code to console
            }
            WriteLine();
            WriteLine();

            parcelList.Sort(new TypeAndCost()); //Sort - user specified Type And Cost sort class

            WriteLine("Sorted list (Parcel type (ascending), Cost (descending): "); // Output Title 
            WriteLine();
            WriteLine();
            foreach (Parcel p in parcelList)
            {
                WriteLine($"{p.GetType().ToString()}, {p.CalcCost():C}"); // Prints Parcel type and cost to console
            }
            WriteLine();
            WriteLine();


            ReadLine(); // prompts user input before ending program
        }
    }
}

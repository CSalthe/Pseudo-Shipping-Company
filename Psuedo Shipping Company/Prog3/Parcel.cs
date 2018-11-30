// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018
// By: D7090

// File: Parcel.cs
// Parcel serves as the abstract base class of the Parcel hierachy.

// Now Serializable

// Now implements IComparable interface to allow CompareTo method between parcel objects, CompareTo in this class allows for sorting by Parcel cost in ascending order
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[Serializable]
public abstract class Parcel : IComparable<Parcel>
{
    // Precondition:  None
    // Postcondition: The parcel is created with the specified values for
    //                origin address and destination address
    public Parcel(Address originAddress, Address destAddress)
    {
        OriginAddress = originAddress;
        DestinationAddress = destAddress;
    }

    public Address OriginAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's origin address has been returned
        get;

        // Precondition:  None
        // Postcondition: The parcel's origin address has been set to the
        //                specified value
        set;
    }

    public Address DestinationAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's destination address has been returned
        get;

        // Precondition:  None
        // Postcondition: The parcel's destination address has been set to the
        //                specified value
        set;
    }

    // Precondition:  None
    // Postcondition: The parcel's cost has been returned
    public abstract decimal CalcCost();

    // Precondition:  None
    // Postcondition: A String with the parcel's data has been returned
    public override String ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut

        return $"Origin Address:{NL}{OriginAddress}{NL}{NL}Destination Address:{NL}" +
            $"{DestinationAddress}{NL}Cost: {CalcCost():C}";
    }
    // Precondition:  Parcel object calls CompareTo method and sends a Parcel object as an argument to the CompareTo method
    // Postcondition: Parcel object that calls method is compared to Parcel object sent to method to determine natural order of Parcel objects via Cost 
    //               When this.CalcCost() > p.CalcCost() returns  1 
    //               When this.GetType() == p.CalcCost() returns 0 
    //               When this.CalcCost() < p.CalcCost() returns -1 
    public int CompareTo(Parcel p) 
    {
        int equal = 0; // hold int value to be returned when this.CalcCost() == p.CalcCost()
        int greater = 1; // hold int value to be returned when this.CalcCost() > p.CalcCost()
        int less = -1; // hold int value to be returned when this.CalcCost() < p.CalcCost()

        if (p == null) // Is the Parcel object null?
        {
            return greater; //Any actual value is greater than null
        }
        else if(this == null) // Is the object referencing this method null?
        {
            return less; //If so it is inherently less than an object with data
        }
        if (this.CalcCost() > p.CalcCost()) // Is the object calling this method is > the object sent to this method?
            return greater;  // YES 
        else if (this.CalcCost() == p.CalcCost()) // Is the object calling this method is == the object sent to this method?
            return equal; //YES
        else
            return less; //The object calling this method must be less than the object sent to this method
    }
}

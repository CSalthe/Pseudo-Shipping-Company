// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018
// By: D7090

// This clase inherents the Comparer class and overrides the Compare method to allow for sorting by Parcel Type (ascending) then by Parcel cost (descending)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVApp
{
    class TypeAndCost : Comparer<Parcel>
    {
        //Precondition: None
        //Postcondition: Sorts by Parcel type (ascending), then by Parcel cost (descending)
        //               When x.GetType() > y.GetType() returns  1 (For primary sorting)
        //               When x.GetType() == y.GetType() returns 0 (For primary sorting)
        //               When x.GetType() < y.GetType() returns -1 (For primary sorting)
        //               When x.CalcCost() > y.CalcCost() returns -1 (For secondary sorting)
        //               When x.CalcCost() == y.CalcCost() returns 0 (For secondary sorting)
        //               When x.CalcCost() < y.CalcCost() returns 1 (For secondary sorting)
        public override int Compare(Parcel x, Parcel y)
        {
            string typeX = x.GetType().ToString(); //Value holds string value of Parcel X type 
            string typeY = y.GetType().ToString(); //Value holds string value of parcel Y type
            int equal = 0; // stores value to be returned if parcel objects are equivilant
            int yNull = -1; // value returned if y == Null
            int xNull = 1; // value returned if x == Null
            int inverse = -1; // inverses natural order of Cost sorted list in Parcel class
            

            if (x == null ) //Any value is greater than null, Y must be greater than null
            {
                return xNull; //returns value stored in xNull
            }
            if(y == null) //Any value is greater than null, X must be greater than null
            {
                return yNull;  // returns value stored in yNull
            }

            if(String.Compare(typeX,typeY) != 0) // if the Parcel type of the two parcel objects sent to the Compare method are not equal, the Compare method returns the integer value sent from the String.Compare() method
            {
                return String.Compare(typeX, typeY); //returns value from String.Compare()
            }
            else if(x.CompareTo(y) != 0) // if the Type of the two objects are equivilant we test to see if the Cost of the two objects are equivilant, if not the inverse of the natural order is returned 
            {
                return (x.CompareTo(y) * inverse); //returns inverse of natural Cost order for parcel objects
            }
            else
            {
                return equal; // if there is no difference in the Type and Cost of the parcel objects they are functionaly equivilant and the values stored in equal is returned 
            }

        }
    }
}

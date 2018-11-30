// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018
// By: D7090

// This clase inherents the Comparer class and overrides the Compare method to allow for sorting by Destination Zip Code in descending order
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVApp
{
    public class ParcelDescending : Comparer<Parcel>
    {
        // Precondition:  None
        // Postcondition: Reverses natural Parcel cost oreder (descending)
        //                When x > y, method returns -1
        //                When x == y, method returns 0
        //                When x < y, method returns 1
        public override int Compare(Parcel x, Parcel y) 
        {

            int equal = 0; // This is the integar value returned from the method when the DestinationAddress zipcode of the two objects are equal
            int greater = -1; // This is the integar value returned from the method when the DestinationAddress zipcode of x > y
            int less = 1; // This is the integar value returned from the method when the DestinationAddress zipcode of x < y

            if (x == null && y ==null) //Ensure correct handling of null values (NULL IS less than any value)
            {
                return equal; // Both null means they are equal
            }
            else if(x == null) //only x is null
            {
                return less; //null is less than any actual value
            }
            else if (y == null) //only y is null
            {
                return greater; // null is less than any actual value
            }

            if(x.DestinationAddress.Zip > y.DestinationAddress.Zip) // If Parcel X's destination zip is greater than Y's des. zip, value stored in greater var is returned
            {
                return greater;
            }
            else if(x.DestinationAddress.Zip == y.DestinationAddress.Zip) // If Parcel X's destination zip quals Y's des. zip, value stored in equal var is returned
            {
                return equal;
            }
            else // If X isnt greater than or equal to Y's dest. zip, X must be less than Y's dest. zip. Therefore, value held in less var is returned
            {
                return less;
            }
        }
    }
}

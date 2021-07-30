using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        public static Dictionary<string, Ride[]> Account = new Dictionary<string, Ride[]>();
        public static void AddRides(string userId, Ride[] inputRides)
        {
            try
            {
                // checking if user id is null
                if (userId == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_USER, "Invalid User");
                }

                // checking if inputRides is null
                if (inputRides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "No rides found");
                }

                // checking if user already exits in account list
                // if not : adding user to account and his rides
                if (Account.ContainsKey(userId))
                {
                    // adding new rides at the end of user ride list
                    //Account.Add(userId, inputRides);
                    foreach (Ride ride in inputRides)
                    {
                        //Account[userId].Add(ride);
                        Account[userId].Append(ride);
                    }
                }
                else
                {
                    Account.Add(userId, inputRides);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

    }
}

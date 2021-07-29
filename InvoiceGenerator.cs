using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        //Constants.......
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_MINUTE;
        private readonly double MINIMUM_FARE;

        public InvoiceGenerator()
        {
            this.MINIMUM_COST_PER_KM = 10;
            this.COST_PER_MINUTE = 1;
            this.MINIMUM_FARE = 5;
        }

        /// <summary>
        /// Calculating the total fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_MINUTE;
            }
            catch (CabInvoiceException)
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
    }
}

    


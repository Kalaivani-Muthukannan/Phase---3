using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFairDetails
    {
        private static int s_ticketID = 3000;
        public string TicketID { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int TicketPrice { get; set; }


        public TicketFairDetails(string fromLocation, string toLocation,int ticketPrice)
        {
            s_ticketID++;
            TicketID = "MR" +s_ticketID;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            TicketPrice = ticketPrice;
        }

        public TicketFairDetails(string ticket1)
        {
            string [] values = ticket1.Split(",");
            s_ticketID = int.Parse(values[0].Remove(0,2));
            TicketID = values[1];
            FromLocation = values[2];
            ToLocation = values[3];
            TicketPrice = int.Parse(values[4]);
        }
    
        
        
    }
}
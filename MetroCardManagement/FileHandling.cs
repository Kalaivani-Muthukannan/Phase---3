using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("MetroCardManagement"))
            {
                Console.WriteLine("Creating folder");
                Directory.CreateDirectory("MetroCardManagement");
            }
            if (!File.Exists("MetroCardManagement/UserDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("MetroCardManagement/UserDetails.csv").Close();
            }
            if (!File.Exists("MetroCardManagement/TravelDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("MetroCardManagement/TravelDetails.csv").Close();
            }
            if (!File.Exists("MetroCardManagement/TicketFairDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("MetroCardManagement/TicketFairDetails.csv").Close();
            }   
        }

        public static void WriteToCSV()
        {
            string[] user = new string[Operations.userDetailsList.Count];
            for(int i =0;i<Operations.userDetailsList.Count;i++)
            {
                user[i] = Operations.userDetailsList[i].CardNumber+","+Operations.userDetailsList[i].Name+","+Operations.userDetailsList[i].Phone+","+Operations.userDetailsList[i].Balance;
            }
            File.WriteAllLines("MetroCardManagement/UserDetails.csv",user);

            string[] travel = new string[Operations.travelDetailsList.Count];
            for(int i =0;i<Operations.travelDetailsList.Count;i++)
            {
                travel[i] = Operations.travelDetailsList[i].CardNumber+","+Operations.travelDetailsList[i].FromLocation+","+Operations.travelDetailsList[i].ToLocation+","+Operations.travelDetailsList[i].Date.ToString("dd/MM/yyyy")+","+Operations.travelDetailsList[i].TravelCost;
            }
            File.WriteAllLines("MetroCardManagement/TravelDetails.csv",travel);

            string[] ticket = new string[Operations.ticketFairDetailsList.Count];
            for(int i = 0;i < Operations.ticketFairDetailsList.Count;i++)
            {
                ticket[i] = Operations.ticketFairDetailsList[i].TicketID+","+Operations.ticketFairDetailsList[i].FromLocation+","+Operations.ticketFairDetailsList[i].ToLocation+","+Operations.ticketFairDetailsList[i].TicketPrice;
            }
            File.WriteAllLines("MetroCardManagement/TicketFairDetails.csv",ticket);
        }

        public static void ReadFromCSV()
        {
            string[] user = File.ReadAllLines("MetroCardManagement/UserDetails.csv");
            foreach(string user1 in user)
            {
                UserDetails user2 = new UserDetails(user1);
                Operations.userDetailsList.Add(user2);
            }

            string[] travel = File.ReadAllLines("MetroCardManagement/TravelDetails.csv");
            foreach(string travel1 in travel)
            {
                TravelDetails travel2 = new TravelDetails(travel1);
                Operations.travelDetailsList.Add(travel2);
            }

            string[] ticket = File.ReadAllLines("MetroCardManagement/TicketFairDetails.csv");
            foreach(string ticket1 in ticket)
            {
                TicketFairDetails ticket2 = new TicketFairDetails(ticket1);
                Operations.ticketFairDetailsList.Add(ticket2);
            }
        }
    }
}
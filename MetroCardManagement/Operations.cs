using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class Operations
    {
        public static CustomList<UserDetails> userDetailsList = new CustomList<UserDetails>();
        public static CustomList<TravelDetails> travelDetailsList = new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketFairDetailsList = new CustomList<TicketFairDetails>();
        static UserDetails currentUser;

        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravi", 8765432, 1000);
            userDetailsList.Add(user1);
            UserDetails user2 = new UserDetails("Baskaran", 87654323456, 1000);
            userDetailsList.Add(user2);

            foreach (UserDetails user in userDetailsList)
            {
                Console.WriteLine($"{user.CardNumber,-10}  {user.Name,-10}  {user.Phone,-10}  {user.Balance,-10}");
            }

            TravelDetails travel1 = new TravelDetails("CMRL1001", "Airport", "Egmore", new DateTime(2023, 10, 10), 55);
            travelDetailsList.Add(travel1);
            TravelDetails travel2 = new TravelDetails("CMRL1001", "Egmore", "Koyembedu", new DateTime(2023, 10, 10), 35);
            travelDetailsList.Add(travel2);
            TravelDetails travel3 = new TravelDetails("CMRL1002", "Alandur", "Koyembedu", new DateTime(2023, 11, 10), 20);
            travelDetailsList.Add(travel3);
            TravelDetails travel4 = new TravelDetails("CMRL1002", "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 25);
            travelDetailsList.Add(travel4);

            foreach (TravelDetails travel in travelDetailsList)
            {
                Console.WriteLine($"{travel.TravelID,-10}  {travel.CardNumber,-10}  {travel.FromLocation,-15}  {travel.ToLocation,-15}  {travel.Date.ToString("dd/MM/yyyy"),-15}  {travel.TravelCost,-10}");
            }

            TicketFairDetails ticket1 = new TicketFairDetails("Airport", "Egmore", 55);
            ticketFairDetailsList.Add(ticket1);
            TicketFairDetails ticket2 = new TicketFairDetails("Airport", "Koyembedu", 25);
            ticketFairDetailsList.Add(ticket2);
            TicketFairDetails ticket3 = new TicketFairDetails("Alandhur", "Koyembedu", 25);
            ticketFairDetailsList.Add(ticket3);
            TicketFairDetails ticket4 = new TicketFairDetails("Koyembedu", "Egmore", 32);
            ticketFairDetailsList.Add(ticket4);
            TicketFairDetails ticket5 = new TicketFairDetails("Vadapalani", "Egmore", 45);
            ticketFairDetailsList.Add(ticket5);
            TicketFairDetails ticket6 = new TicketFairDetails("Arumbakkam", "Egmore", 25);
            ticketFairDetailsList.Add(ticket6);
            TicketFairDetails ticket7 = new TicketFairDetails("Vadapalani", "Koyembedu", 25);
            ticketFairDetailsList.Add(ticket7);
            TicketFairDetails ticket8 = new TicketFairDetails("Arumbakkam", "Koyembedu", 15);
            ticketFairDetailsList.Add(ticket8);

            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                Console.WriteLine($"{ticket.TicketID,-10}  {ticket.FromLocation,-15}  {ticket.ToLocation,-15}   {ticket.TicketPrice,-15}");
            }

        }

        public static void MainMenu()
        {
            Console.WriteLine("\t\t\tMetro Card MAnagement\t\t\t");
            int choice;
            bool flag = true;

            do
            {
                Console.WriteLine("\n1.Registration  2.Login  3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Exit();
                            flag = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            } while (flag);
        }

        public static void Registration()
        {
            Console.WriteLine("Enter the user Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Phone number: ");
            long phone = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the balance: ");
            int balance = int.Parse(Console.ReadLine());
            UserDetails user1 = new UserDetails(name, phone, balance);
            userDetailsList.Add(user1);
            Console.WriteLine("User Registration successful and your card nuber is " + user1.CardNumber);
        }

        public static void Login()
        {
            Console.WriteLine("Enter the Login ID:");
            string cardNum = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (UserDetails user in userDetailsList)
            {
                //int result = BinarySearch.BinaryLogin(userDetailsList, loginID);
                if (cardNum == user.CardNumber)
                {
                    flag = false;
                    Console.WriteLine("Login Successful");
                    currentUser = user;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Login unsuccessfull");
            }
        }

        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                //Console.WriteLine("Submenu");
                Console.WriteLine("1.Balance check  2.Recharge  3.View Travel History  4.Travel  5.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            BalanceCheck();
                            break;
                        }
                    case 2:
                        {
                            Recharge();
                            break;
                        }
                    case 3:
                        {
                            ViewTravelHistory();
                            break;
                        }
                    case 4:
                        {
                            Travel();
                            break;
                        }
                    case 5:
                        {
                            flag = false;
                            Exit();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (flag);
        }

        public static void BalanceCheck()
        {
            //Display the balance amount of the user object which is related to the card number.

            Console.WriteLine("Your current wallet balance is " + currentUser.Balance);
                
        }
        public static void Recharge()
        {
            //Get the amount to be recharged and add the recharged amount to the balance amount of the user object which is related to the card number.
            Console.WriteLine("Are you wish to recharge: ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                Console.WriteLine("Enter the amount to recharge: ");
                int rechargeAmount = int.Parse(Console.ReadLine());

                if (rechargeAmount > 0)
                {
                    currentUser.Balance += rechargeAmount;
                    Console.WriteLine("Your Current wallet balance is : " + currentUser.Balance);
                }
                else
                {
                    Console.WriteLine("enter the valid amount to recharge");
                    Recharge();
                }
            }
        }
        public static void ViewTravelHistory()
        {
            //Display list of the travel history objects which is related to the card number.
            foreach (TravelDetails travel in travelDetailsList)
            {
                if (currentUser.CardNumber == travel.CardNumber)
                {
                    Console.WriteLine($"{travel.TravelID,-10}  {travel.CardNumber,-10}  {travel.FromLocation,-15}  {travel.ToLocation,-15}  {travel.Date,-15}  {travel.TravelCost,-10}");
                }
            }
        }

        public static void Travel()
        {
            //1.Show the Ticket fair details where the user wishes to travel by getting TicketID.
            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                Console.WriteLine($"{ticket.TicketID}  {ticket.FromLocation}  {ticket.ToLocation}   {ticket.TicketPrice}");
            }
            bool flag =true;
            Console.WriteLine("Enter the ticketId that you wish to travel:  ");
            string ticketID = Console.ReadLine();
            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                //2.Check the ticketID is valid.
                if (ticketID == ticket.TicketID)
                {
                    flag = false;
                    //Check the balance from the user object whether it has sufficient balance to travel.
                    if (currentUser.Balance >= ticket.TicketPrice)
                    {
                        //4.If “Yes” deduct the respective amount from the balance and add the travel details like Card number, From and ToLocation, Travel Date, Travel cost, Travel ID (auto generation) in his travel history.
                        currentUser.Balance -= ticket.TicketPrice;
                        TravelDetails travel = new TravelDetails(currentUser.CardNumber, ticket.FromLocation, ticket.ToLocation, DateTime.Now, ticket.TicketPrice);
                        travelDetailsList.Add(travel);
                        Console.WriteLine("Ticket Booked successfully!");
                    }
                    else
                    {
                        //5.If “No” ask him to recharge and go to the “Existing User Service” menu.
                        Console.WriteLine("There is no sufficent balance. Are you wish to recharge: ");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "yes")
                        {
                            Console.WriteLine("Enter the amount to recharge: ");
                            int rechargeAmount = int.Parse(Console.ReadLine());

                            if (rechargeAmount > 0)
                            {
                                currentUser.Balance += rechargeAmount;
                            }
                            else
                            {
                                Console.WriteLine("enter the valid amount to recharge");
                            }
                        }
                    }
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid Ticket ID");
            }
        }

        public static void Exit()
        {
            Console.WriteLine("Exiting");
        }
    }
}
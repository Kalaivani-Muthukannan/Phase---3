using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class Operation
    {
        public static CustomList<UserRegistration> userRegistrationsList = new CustomList<UserRegistration>();
        public static CustomList<RoomDetail> roomDetailsList = new CustomList<RoomDetail>();
        public static CustomList<RoomSelection> roomSelectionsList = new CustomList<RoomSelection>();
        public static CustomList<BookingDetail> bookingDetailsList = new CustomList<BookingDetail>();
        static UserRegistration currentUser;

        public static void AddDefaultData()
        {
            UserRegistration user1 = new UserRegistration("Ravi", 76543987, 9876543234, "Chennai", FoodType.Veg, Gender.Male, 5000);
            userRegistrationsList.Add(user1);
            UserRegistration user2 = new UserRegistration("Baskaran", 8765439999, 2345678909876, "Chennai", FoodType.NonVeg, Gender.Male, 6000);
            userRegistrationsList.Add(user2);

            foreach (UserRegistration user in userRegistrationsList)
            {
                Console.WriteLine($"|  {user.UserID}  |  {user.Name,-15}  |  {user.Phone,-10}  |  {user.AadharNo,-10}  |  {user.Address}  |  {user.FoodType,-15}  |  {user.Gender,-15}  |  {user._balance,-10}");
            }

            RoomDetail room1 = new RoomDetail(RoomType.Standard, 2, 500);
            roomDetailsList.Add(room1);
            RoomDetail room2 = new RoomDetail(RoomType.Standard, 4, 700);
            roomDetailsList.Add(room2);
            RoomDetail room3 = new RoomDetail(RoomType.Standard, 2, 500);
            roomDetailsList.Add(room3);
            RoomDetail room4 = new RoomDetail(RoomType.Standard, 2, 500);
            roomDetailsList.Add(room4);
            RoomDetail room5 = new RoomDetail(RoomType.Standard, 2, 500);
            roomDetailsList.Add(room5);
            RoomDetail room6 = new RoomDetail(RoomType.Delux, 2, 500);
            roomDetailsList.Add(room6);
            RoomDetail room7 = new RoomDetail(RoomType.Delux, 2, 1000);
            roomDetailsList.Add(room7);
            RoomDetail room8 = new RoomDetail(RoomType.Delux, 4, 1000);
            roomDetailsList.Add(room8);
            RoomDetail room9 = new RoomDetail(RoomType.Delux, 4, 1400);
            roomDetailsList.Add(room1);
            RoomDetail room10 = new RoomDetail(RoomType.Suit, 2, 1400);
            roomDetailsList.Add(room10);
            RoomDetail room11 = new RoomDetail(RoomType.Suit, 2, 2000);
            roomDetailsList.Add(room11);
            RoomDetail room12 = new RoomDetail(RoomType.Suit, 2, 2000);
            roomDetailsList.Add(room12);
            RoomDetail room13 = new RoomDetail(RoomType.Suit, 4, 2500);
            roomDetailsList.Add(room13);

            foreach (RoomDetail room in roomDetailsList)
            {
                Console.WriteLine($"|{room.RoomID,-10}  |  {room.RoomType,-15}  |  {room.NumberOFBeds,-10}  {room.PricePerDay,-10}");
            }

            RoomSelection selection1 = new RoomSelection("BID101", "RID101", new DateTime(2022, 11, 11, 06, 00, 00), new DateTime(2022, 11, 12, 02, 00, 00), 750, 1.5, BookingStatus.Booked);
            roomSelectionsList.Add(selection1);
            RoomSelection selection2 = new RoomSelection("BID101", "RID102", new DateTime(2022, 11, 11, 10, 00, 00), new DateTime(2022, 11, 12, 09, 00, 00), 700, 1, BookingStatus.Booked);
            roomSelectionsList.Add(selection2);
            RoomSelection selection3 = new RoomSelection("BID102", "RID103", new DateTime(2022, 11, 12, 09, 00, 00), new DateTime(2022, 11, 13, 09, 00, 00), 500, 1, BookingStatus.Cancelled);
            roomSelectionsList.Add(selection3);
            RoomSelection selection4 = new RoomSelection("BID102", "RID106", new DateTime(2022, 11, 12, 06, 00, 00), new DateTime(2022, 11, 13, 12, 30, 00), 1500, 1.5, BookingStatus.Cancelled);
            roomSelectionsList.Add(selection4);

            foreach (RoomSelection selection in roomSelectionsList)
            {
                System.Console.WriteLine($"|{selection.SelectionID,-10}  |  {selection.BookingID,-10}  |  {selection.RoomID}  |  {selection.StayingDateFrom,-10}  |  {selection.StayingDateTo,-10}  |  {selection.Price,-10}  |  {selection.NumberOfDays,-10}  |  {selection.BookingStatus,-15}");
            }

            BookingDetail booking1 = new BookingDetail("SF1001", 1450, new DateTime(2022, 11, 10), BookingStatus.Booked);
            bookingDetailsList.Add(booking1);
            BookingDetail booking2 = new BookingDetail("SF1002", 2000, new DateTime(2022, 11, 10), BookingStatus.Cancelled);
            bookingDetailsList.Add(booking2);

            foreach (BookingDetail booking in bookingDetailsList)
            {
                Console.WriteLine($"{booking.BookingID,-10}  |  {booking.UserID,-10}  |  {booking.TotalPrice,-10}  |  {booking.DateOfBooking,-15}  |  {booking.BookingStatus,-15}");
            }
        }

        public static void MainMenu()
        {

            System.Console.WriteLine("Welcome Hotel Mangement");
            bool flag = true;
            do
            {
                Console.WriteLine("1.User Registration   2.User Login   3.Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            Exit();
                            break;
                        }
                }
            } while (flag);
        }

        public static void UserRegistration()
        {
            Console.WriteLine("Enter the UserName : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Phone Number : ");
            long phone = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Aadhar Number : ");
            long aadharNo = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Address : ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the Food Type : ");
            FoodType foodType = Enum.Parse<FoodType>(Console.ReadLine());
            Console.WriteLine("Enter the Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine());
            Console.WriteLine("Enter your WalletBalance : ");
            int balance = int.Parse(Console.ReadLine());

            UserRegistration user = new UserRegistration(name, phone, aadharNo, address, foodType, gender, balance);
            userRegistrationsList.Add(user);

            Console.WriteLine($"Registration Successfull. And Your Registration ID is {user.UserID}");


        }

        public static void UserLogin()
        {
            Console.WriteLine("Enter the userId to Login: ");
            string userID = Console.ReadLine();

            bool flag = true;
            foreach (UserRegistration user in userRegistrationsList)
            {
                if (user.UserID == userID)
                {
                    flag = false;
                    currentUser = user;
                    Console.WriteLine("Login Success  !");
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid User ID. Please enter a valid one");
            }

        }

        public static void SubMenu()
        {
            System.Console.WriteLine("Welcome to Login Page");
            bool flag = true;
            do
            {
                Console.WriteLine("1.View Customer Profile   2.Book Room   3.Modify Booking  4.CancelBooking  5.Booking History  6.Wallet Recharge  7.Show WalletBalance 8.Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            ViewCustomerProfile();
                            break;
                        }
                    case 2:
                        {
                            BookRoom();
                            break;
                        }
                    case 3:
                        {
                            ModifyBooking();
                            break;
                        }
                    case 4:
                        {
                            CancelBooking();
                            break;
                        }
                    case 5:
                        {
                            BookingHistory();
                            break;
                        }
                    case 6:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            flag = false;
                            Exit();
                            break;
                        }
                }
            } while (flag);

        }

        public static void ViewCustomerProfile()
        {
            foreach (UserRegistration user in userRegistrationsList)
            {
                if (user.UserID == currentUser.UserID)
                {
                    Console.WriteLine($"|  {user.UserID}  |  {user.Name,-15}  |  {user.Phone,-10}  |  {user.AadharNo,-10}  |  {user.Address}  |  {user.FoodType,-15}  |  {user.Gender,-15}  |  {user._balance,-10}");
                }
            }

        }
        public static void BookRoom()
        {

            //1.Create temporary booking object whose UserID is currentUserID, TotalAmount 0, Bookingdate Now, Status as initiated.
            CustomList<BookingDetail> tempBookingList = new CustomList<BookingDetail>();
            BookingDetail booking = new BookingDetail(currentUser.UserID, 0, DateTime.Now, BookingStatus.Initiated);

            //2.Create temporary local room selection list to hold the room selection objects up to booking completion.
            List<RoomSelection> temprooms = new List<RoomSelection>();
            int totalPrice = 0;
            int price;
            string wish = "";

            do
            {
                //3.Need to show the list of available room types by traversing the Room Details list.
                foreach (RoomDetail room in roomDetailsList)
                {
                    Console.WriteLine($"|{room.RoomID,-10}  |  {room.RoomType,-15}  |  {room.NumberOFBeds,-10}  {room.PricePerDay,-10}");
                }

                //4.Need to ask the user to enter DateFrom (Date and Time) and DateTo (Date and Time), RoomID & no. Of Days of booking
                Console.WriteLine("Enter the Date From:");
                DateTime dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh,mm tt", null);

                Console.WriteLine("Enter the Date To:");
                DateTime dateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh,mm tt", null);

                Console.WriteLine("Enter the bookID : ");
                string roomID = Console.ReadLine();

                Console.WriteLine("Enter the number of days of Booking : ");
                double numberOfDays = double.Parse(Console.ReadLine());

                bool flag = true;
                foreach (RoomSelection roomSelection in roomSelectionsList)
                {
                    foreach (RoomDetail room in roomDetailsList)
                    {
                        flag = false;
                        if (roomID == room.RoomID)
                        {
                            //based on data check booking status is booked or not
                            if (roomSelection.BookingStatus != BookingStatus.Booked && roomID == room.RoomID)
                            {
                                if (room.PricePerDay <= currentUser.WalletBalance)
                                {
                                    price = (int)(numberOfDays * room.PricePerDay);
                                    totalPrice += price;
                                    //not booked means create object and add to temp room selection
                                    RoomSelection temp1 = new RoomSelection(roomID, roomSelection.BookingID, dateFrom, dateTo, price, numberOfDays, BookingStatus.Booked);
                                    temprooms.Add(temp1);
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient Balance");
                                }
                            }
                        }
                    }
                }

                if (flag)
                {
                    Console.WriteLine("Invalid Booking ID");
                }
                //If “yes” means repeat step 3 to 5 to create new selection object and add it to local list.
            } while (wish == "yes");

            //7.If user says “No” means calculate the total rent amount of that modify the selected room booking object details and status as booked.

            Console.WriteLine("whether you confirm the selected room to book? Yes / No");
            string wish1 = Console.ReadLine().ToLower();
            if (wish == "yes")
            {
                bool flag = false;
                do
                {
                    {
                        //8.Check the user has enough balance.
                        if (totalPrice <= currentUser.WalletBalance)
                        {
                            flag = true;
                            //If he has enough balance Add the local temp room selection to global list.
                            bookingDetailsList.AddRange(tempBookingList);
                            booking.BookingStatus = BookingStatus.Booked;
                            booking.TotalPrice = totalPrice;
                            currentUser.DeductBalance(totalPrice);
                            // Add the booking object to booking list.
                            bookingDetailsList.Add(booking);
                            //And show rooms successfully booked Your booking ID – BID101.
                            Console.WriteLine($"Room Booked successfully, and Booking ID is {booking.BookingID}");
                        }
                        else
                        {
                            //9.If user don’t have enough balance, ask the user whether he want to proceed booking after recharge.
                            Console.WriteLine("Insufficient Balance");
                            Console.WriteLine("Are you Wish to recharge: ");
                            string option = Console.ReadLine().ToLower();
                            if (option == "yes")
                            {
                                //10.If he says yes means show the amount to be recharged for continue booking (Total Booking Amount).
                                Console.WriteLine("Enter the amount to recharge: ");
                                int rechargeAmount = int.Parse(Console.ReadLine());

                                if (rechargeAmount > 0)
                                {
                                    currentUser._balance += rechargeAmount;
                                    Console.WriteLine($"Recharge Successfull and your current wallet balance is {currentUser.WalletBalance}");
                                }
                                else
                                {
                                    // If he says no then Show Exiting without booking rooms.
                                    Console.WriteLine("Enter the valid amount to recharge");
                                }
                            }
                            else
                            {
                                flag = false;
                                foreach (BookingDetail detail in bookingDetailsList)
                                {
                                    foreach (RoomSelection room in roomSelectionsList)
                                    {
                                        if (room.BookingID == detail.BookingID)
                                        {
                                            room.BookingStatus = BookingStatus.Booked;
                                            break;
                                        }
                                    }
                                }
                            }

                        }
                    }
                } while (flag);
            }
            else
            {
                foreach (BookingDetail detail in bookingDetailsList)
                {
                    foreach (RoomSelection room in roomSelectionsList)
                    {
                        if (room.BookingID == detail.BookingID)
                        {
                            room.BookingStatus = BookingStatus.Cancelled;
                            break;
                        }
                    }
                }
            }

        }
        public static void ModifyBooking()
        {

            //Need to show the current user’s booking history whose booking status is Booked by traversing the booking details list and need to ask the user to pick a bookingID. 
            //Check whether the booking ID present in booking details and its status is Booked.
            //Traverse the selection list and check the Booking ID present in selection list and the selection status is Booked.

            bool flag = true;
            foreach (BookingDetail booking in bookingDetailsList)
            {
                if (currentUser.UserID == booking.UserID && booking.BookingStatus == BookingStatus.Booked)
                {
                    flag = false;
                    Console.WriteLine($"{booking.BookingID,-10}  |  {booking.UserID,-10}  |  {booking.TotalPrice,-10}  |  {booking.DateOfBooking,-15}  |  {booking.BookingStatus,-15}");

                }
            }
            if (flag)
            {
                Console.WriteLine("No order currently you have");
            }
            else
            {
                Console.WriteLine("Enter the booking ID that you need to modify: ");
                string bookingID = Console.ReadLine();

                bool flag1 = true;
                foreach (BookingDetail book in bookingDetailsList)
                {
                    if (book.BookingID == bookingID && book.BookingStatus == BookingStatus.Booked)
                    {
                        foreach (RoomSelection selection in roomSelectionsList)
                        {
                            flag1 = false;
                            System.Console.WriteLine($"|{selection.SelectionID,-10}  |  {selection.BookingID,-10}  |  {selection.RoomID}  |  {selection.StayingDateFrom,-10}  |  {selection.StayingDateTo,-10}  |  {selection.Price,-10}  |  {selection.NumberOfDays,-10}  |  {selection.BookingStatus,-15}");
                        }
                    }
                }
                if (flag1)
                {
                    System.Console.WriteLine("Invalid booking ID");
                }
                else
                {
                    Console.WriteLine("Enter the Room Id that you need to modify: ");
                    string selectionId = Console.ReadLine();
                    bool itemflag = true;
                    foreach (BookingDetail booking in bookingDetailsList)
                    {
                        if (currentUser.UserID == booking.UserID && booking.BookingID == selectionId && booking.BookingStatus == BookingStatus.Booked)
                        {
                            foreach (RoomSelection room in roomSelectionsList)
                            {
                                if (booking.BookingID == room.BookingID && room.SelectionID == selectionId)
                                {
                                    itemflag = false;
                                    Console.WriteLine("Enter the Option as per your need: 1.Cancel Selected Room 2.Add new Room ");
                                    int option = int.Parse(Console.ReadLine());

                                    switch (option)
                                    {
                                        case 1:
                                            {

                                                currentUser.DeductBalance(booking.TotalPrice);
                                                booking.BookingStatus = BookingStatus.Cancelled;
                                                Console.WriteLine("Room cancelled successfully");
                                                break;
                                            }
                                        case 2:
                                            {
                                                foreach (RoomDetail room1 in roomDetailsList)
                                                {
                                                    Console.WriteLine($"|{room1.RoomID,-10}  |  {room1.RoomType,-15}  |  {room1.NumberOFBeds,-10}  {room1.PricePerDay,-10}");
                                                }
                                                Console.WriteLine("Enter the RoomID you want to add: ");
                                                string roomID = Console.ReadLine();
                                                Console.WriteLine("Enter the Check In date: ");
                                                DateTime inDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM,yyyy,hh,mm,ss tt", null);
                                                Console.WriteLine("Enter the Check In date: ");
                                                DateTime outDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM,yyyy,hh,mm,ss tt", null);
                                                Console.WriteLine("Enter the number of rooms that you need: ");
                                                int rooms = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                    }
                                }
                            }
                        }
                    }
                    if (itemflag)
                    {
                        Console.WriteLine("Invalid Booking ID");
                    }
                }
            }
        }

        public static void CancelBooking()
        {
            //Need to show the current user’s booking history whose booking status is Booked by traversing the booking details list
            foreach (BookingDetail booking in bookingDetailsList)
            {
                if (currentUser.UserID == booking.UserID && booking.BookingStatus == BookingStatus.Booked)
                {
                    Console.WriteLine($"{booking.BookingID,-10}  |  {booking.UserID,-10}  |  {booking.TotalPrice,-10}  |  {booking.DateOfBooking,-15}  |  {booking.BookingStatus,-15}");
                }
            }
            //need to ask the user to pick a bookingID. 
            Console.WriteLine("Enter the Booking ID to cancel");
            string bookingID = Console.ReadLine();
            bool temp = true;
            foreach (BookingDetail book in bookingDetailsList)
            {
                //Need to validate the id is present
                if (currentUser.UserID == book.UserID && book.BookingStatus == BookingStatus.Booked)
                {
                    if (book.BookingID == bookingID)
                    {
                        temp = false;
                        // and return the booking amount to current user’s wallet.
                        currentUser.WalletRecharge(book.TotalPrice);
                        foreach (RoomSelection room in roomSelectionsList)
                        {
                            if (room.BookingID == book.BookingID)
                            {
                                foreach (RoomDetail detail in roomDetailsList)
                                {
                                    if (room.RoomID == detail.RoomID)
                                    {
                                        room.BookingStatus = BookingStatus.Cancelled;
                                    }
                                }
                            }
                        }
                    }
                    //Change the booking status of selection list details of that corresponding bookingID from Booked to cancelled.
                    book.BookingStatus = BookingStatus.Cancelled;
                    Console.WriteLine("Room Booking Cancelled Successfully ");
                }
            }
            if (temp)
            {
                System.Console.WriteLine("Invalid OrderID");
            }

        }
        public static void BookingHistory()
        {
            bool flag = true;
            foreach (BookingDetail booking in bookingDetailsList)
            {
                if (currentUser.UserID == booking.UserID)
                {
                    flag = false;
                    Console.WriteLine($"{booking.BookingID,-10}  |  {booking.UserID,-10}  |  {booking.TotalPrice,-10}  |  {booking.DateOfBooking,-15}  |  {booking.BookingStatus,-15}");
                }
            }
            if (flag)
            {
                Console.WriteLine("You don't have any booking history");
            }

        }
        public static void WalletRecharge()
        {
            Console.WriteLine("Are you wish to Recharge: ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                Console.WriteLine("Enter the amount to recharge: ");
                int rechargeAmount = int.Parse(Console.ReadLine());

                if (rechargeAmount > 0)
                {
                    currentUser._balance += rechargeAmount;
                    Console.WriteLine($"Recharge Successfull and your current wallet balance is {currentUser.WalletBalance}");
                }
                else
                {
                    Console.WriteLine("Enter the valid amount to reacharge");
                }
            }

        }
        public static void ShowWalletBalance()
        {
            foreach (UserRegistration user in userRegistrationsList)
            {
                if (currentUser.UserID == user.UserID)
                {
                    System.Console.WriteLine($"Your Current Wallet Balance is {user.WalletBalance}");
                }
            }
        }
        public static void Exit()
        {
            Console.WriteLine("Exciting..!");
        }


    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("HotelManagement"))
            {
                Console.WriteLine("Creating Folder..");
                Directory.CreateDirectory("HotelManagement");
            }
            else
            {
                Console.WriteLine("Folder already Exists!");
            }
            //UserRegistration
            if (!File.Exists("HotelManagement/UserRegistration.csv"))
            {
                Console.WriteLine("Creating File..");
                File.Create("HotelManagement/UserRegistration.csv").Close();
            }
            else
            {
                Console.WriteLine("File already Exists");
            }
            //Room Selection
            if (!File.Exists("HotelManagement/RoomSelection.csv"))
            {
                Console.WriteLine("Creating File..");
                File.Create("HotelManagement/RoomSelection.csv").Close();
            }
            else
            {
                Console.WriteLine("File already Exists");
            }
            //RoomDetail
            if (!File.Exists("HotelManagement/RoomDetail.csv"))
            {
                Console.WriteLine("Creating File..");
                File.Create("HotelManagement/RoomDetail.csv").Close();
            }
            else
            {
                Console.WriteLine("File already Exists");
            }
            //Booking Detail
            if (!File.Exists("HotelManagement/BookingDetail.csv"))
            {
                Console.WriteLine("Creating File..");
                File.Create("HotelManagement/BookingDetail.csv").Close();
            }
            else
            {
                Console.WriteLine("File already Exists");
            }

        }

        public static void WriteToCSV()
        {

            // User Registration
            string[] user = new string[Operation.userRegistrationsList.Count];
            for (int i = 0; i < Operation.userRegistrationsList.Count; i++)
            {
                user[i] = Operation.userRegistrationsList[i].Name + "," + Operation.userRegistrationsList[i].Phone + "," + Operation.userRegistrationsList[i].AadharNo + "," + Operation.userRegistrationsList[i].Address + "," + Operation.userRegistrationsList[i].FoodType + "," + Operation.userRegistrationsList[i].Gender + "," + Operation.userRegistrationsList[i].WalletBalance;
            }
            File.WriteAllLines("HotelManagement/UserRegistration.csv", user);

            //Room Selection
            string[] selection = new string[Operation.roomSelectionsList.Count];
            for (int i = 0; i < Operation.roomSelectionsList.Count; i++)
            {
                selection[i] = Operation.roomSelectionsList[i].BookingID + "," + Operation.roomSelectionsList[i].RoomID + "," + Operation.roomSelectionsList[i].StayingDateFrom + "," + Operation.roomSelectionsList[i].StayingDateTo + "," + Operation.roomSelectionsList[i].Price + "," + Operation.roomSelectionsList[i].NumberOfDays + "," + Operation.roomSelectionsList[i].BookingStatus;
            }
            File.WriteAllLines("HotelManagement/RoomSelection.csv", selection);

            //Room Details
            string[] room = new string[Operation.roomDetailsList.Count];
            for (int i = 0; i < Operation.roomDetailsList.Count; i++)
            {
                room[i] = Operation.roomDetailsList[i].RoomID + "," + Operation.roomDetailsList[i].RoomType + "," + Operation.roomDetailsList[i].NumberOFBeds + "," + Operation.roomDetailsList[i].PricePerDay;
            }
            File.WriteAllLines("HotelManagement/RoomDetail.csv", room);

            //Booking Details
            string[] booking = new string[Operation.bookingDetailsList.Count];
            for (int i = 0; i < Operation.bookingDetailsList.Count; i++)
            {
                booking[i] = Operation.bookingDetailsList[i].BookingID + "," + Operation.bookingDetailsList[i].UserID + "," + Operation.bookingDetailsList[i].TotalPrice + "," + Operation.bookingDetailsList[i].DateOfBooking + "," + Operation.bookingDetailsList[i].BookingStatus;
            }
            File.WriteAllLines("HotelManagement/BookingDetail.csv", booking);
        }

        public static void ReadToCSV()
        {
            //User Registration
            string[] user = File.ReadAllLines("HotelManagement/UserRegistration.csv");
            foreach(string user1 in user)
            {
                UserRegistration user2 = new UserRegistration(user1);
                Operation.userRegistrationsList.Add(user2);
            }
            //Room Selection
            string[] selection = File.ReadAllLines("HotelManagement/RoomSelection.csv");
            foreach(string selection1 in selection)
            {
                RoomSelection selection2 = new RoomSelection(selection1);
                Operation.roomSelectionsList.Add(selection2);
            }

            //RoomDetail
            string[] room = File.ReadAllLines("HotelManagement/RoomSelection.csv");
            foreach(string room1 in room)
            {
                RoomDetail room2 = new RoomDetail(room1);
                Operation.roomDetailsList.Add(room2);
            }
            //BookingDetail
            string[] book = File.ReadAllLines("HotelManagement/BookingDetail.csv");
            foreach(string book1 in selection)
            {
                BookingDetail book2 = new BookingDetail(book1);
                Operation.bookingDetailsList.Add(book2);
            }


        }


    }
}
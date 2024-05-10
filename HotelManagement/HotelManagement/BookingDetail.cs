using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum BookingStatus
    {
        Default, Initiated, Booked, Cancelled
    }
    public class BookingDetail
    {
        private static int s_bookingID = 100;
        public string BookingID { get; set; }
        public string UserID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateOfBooking { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public BookingDetail(string userID, int totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus)
        {
            s_bookingID ++;
            BookingID = "BID" + s_bookingID;
            UserID = userID;
            TotalPrice = totalPrice;
            DateOfBooking = dateOfBooking;
            BookingStatus = bookingStatus;
        }

        public BookingDetail(string book1)
        {
            string[] value = book1.Split(",");
            s_bookingID = int.Parse(value[0].Remove(0,3));
            BookingID = value[0];
            UserID = value[1];
            TotalPrice = int.Parse(value[2]);
            DateOfBooking = DateTime.ParseExact(value[3],("dd/MM/yyyy"),null);
            BookingStatus = Enum.Parse<BookingStatus>(value[4]);
        }
    }
}
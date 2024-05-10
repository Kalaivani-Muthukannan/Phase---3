using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class RoomSelection
    {
        private static int s_selectionID = 1000;
        public string SelectionID { get; set; }
        public string RoomID { get; set; }
        public string BookingID { get; set; }
        public DateTime StayingDateFrom { get; set; }
        public DateTime StayingDateTo { get; set; }
        public int Price { get; set; }
        public double NumberOfDays { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public RoomSelection( string bookingID,string roomID, DateTime stayingDateFrom, DateTime stayingDateTo, int price, double numberOfDays, BookingStatus bookingStatus)
        {
            s_selectionID ++;
            SelectionID = "SID" + s_selectionID;
            RoomID = roomID;
            BookingID = bookingID;
            StayingDateFrom = stayingDateFrom;
            StayingDateTo = stayingDateTo;
            Price = price;
            NumberOfDays = numberOfDays;
            BookingStatus = bookingStatus;
        }

        public RoomSelection( string selection1)
        {
            string[] value = selection1.Split(",");
            s_selectionID = int.Parse(value[0].Remove(0,3));
            SelectionID = value[0];
            RoomID = value[1];
            BookingID = value[2];
            StayingDateFrom = DateTime.ParseExact(value[3],("dd/MM/yyyy"),null);
            StayingDateTo = DateTime.ParseExact(value[4],("dd/MM/yyyy"),null);
            Price = int.Parse(value[5]);
            NumberOfDays = double.Parse(value[6]);
            BookingStatus =Enum.Parse<BookingStatus>(value[7]);
        }
    }
}
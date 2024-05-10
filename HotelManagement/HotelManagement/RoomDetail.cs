using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum RoomType
    {
        Standard, Delux, Suit
    }
    public class RoomDetail
    {
        private static int s_roomID = 100;
        public string  RoomID { get; set; }
        public RoomType RoomType { get; set; }
        public int NumberOFBeds { get; set; }
        public double PricePerDay { get; set; }

        public RoomDetail(RoomType roomType, int numberOFBeds, double pricePerDay)
        {
            s_roomID ++;
            RoomID = "RID" +s_roomID;
            RoomType = roomType;
            NumberOFBeds = numberOFBeds;
            PricePerDay = pricePerDay;
        }

        public RoomDetail(string room1)
        {
            string[] value = room1.Split(",");
            s_roomID = int.Parse(value[0].Remove(0,3));
            RoomID = value[0];
            RoomType = Enum.Parse<RoomType>(value[1]);
            NumberOFBeds = int.Parse(value[2]);
            PricePerDay = int.Parse(value[3]);
        }
    }
}
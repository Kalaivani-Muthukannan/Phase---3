using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CafeteriaCardManagement
{
    public enum OrderStatus
    {
        Default, Initiated, Ordered, Cancelled
    }
    public class OrderDetails
    {
        private static int s_orderID = 1000;
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        
        public OrderDetails(string userID,DateTime orderDate,double totalPrice, OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            OrderStatus = orderStatus;
        }

        public OrderDetails(string order1)
        {
            string[] values = order1.Split(",");
            s_orderID = int.Parse(values[0].Remove(0,3));
            OrderID = values[0];
            UserID = values[1];
            OrderDate = DateTime.ParseExact(values[2],("dd/MM/yyyy"),null);
            TotalPrice = int.Parse(values[3]);
            //OrderStatus = values[4];
        }
        
        
        
        
        
        
        

    }
}
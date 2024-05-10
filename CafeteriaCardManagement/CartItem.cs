using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class CartItem
    {
            private static int s_ItemID = 100;
            public string ItemID { get; set; }
            public string OrderID { get; set; }
            public string FoodID { get; set; }
            public double OrderPrice { get; set; }
            public int OrderQuantity { get; set; }
            
            public CartItem(string orderID, string foodID,double orderPrice, int orderQuantity)
            {
                s_ItemID ++;
                ItemID = "ITID"+ s_ItemID;
                OrderID = orderID;
                FoodID = foodID;
                OrderPrice = orderPrice;
                OrderQuantity = orderQuantity;
            }

            public CartItem(string cart1)
            {
                string[] values = cart1.Split();
                s_ItemID = int.Parse(values[0]);
                ItemID = values[0];
                OrderID = values[1];
                FoodID = values[2];
                OrderPrice = double.Parse(values[3]);
                OrderQuantity = int.Parse(values[4]);
            }
            
            
            
            
            
            
            
            

    }
}
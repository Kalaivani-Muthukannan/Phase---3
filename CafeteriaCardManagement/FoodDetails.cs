using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class FoodDetails
    {
        private static int s_foodId = 100;
        public string FoodID { get; set; }
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public int AvailableQuantity { get; set; }

        public FoodDetails(string foodName, int foodPrice, int availableQuantity )
        {
            s_foodId ++;
            FoodID = "FID" + s_foodId;
            FoodName = foodName;
            FoodPrice = foodPrice;
            AvailableQuantity = availableQuantity;
        }

        public FoodDetails(string food1)
        {
            string [] values = food1.Split(",");
            s_foodId = int.Parse(values[0]);
            FoodID = values[0];
            FoodName = values[1];
            FoodPrice = int.Parse(values[2]);
            AvailableQuantity = int.Parse(values[3]);
        }
    }
}
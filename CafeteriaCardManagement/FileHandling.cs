using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("CafeteriaCardManagement"))
            {
                Console.WriteLine("Creating folder");
                Directory.CreateDirectory("CafeteriaCardManagement");
            }
            if (!File.Exists("CafeteriaCardManagement/UserDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("CafeteriaCardManagement/UserDetails.csv").Close();
            }
            if (!File.Exists("CafeteriaCardManagement/FoodDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("CafeteriaCardManagement/FoodDetails.csv").Close();
            }
            if (!File.Exists("CafeteriaCardManagement/CartITem.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("CafeteriaCardManagement/CartITem.csv").Close();
            }
            if (!File.Exists("CafeteriaCardManagement/OrderDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("CafeteriaCardManagement/OrderDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            string[] user = new string [Operations.userDetailsList.Count];
            for(int i =0;i<Operations.userDetailsList.Count ;i++)
            {
                user[i] = Operations.userDetailsList[i].UserID+","+Operations.userDetailsList[i].Name+","+Operations.userDetailsList[i].FatherName+","+Operations.userDetailsList[i].Gender+","+Operations.userDetailsList[i].Phone+","+Operations.userDetailsList[i].MailID+","+Operations.userDetailsList[i].WorkStationNumber+","+Operations.userDetailsList[i].WalletBalance;
            }
            File.WriteAllLines("CafeteriaCardManagement/UserDetails.csv",user);

            string[] food = new string [Operations.foodDetailsList.Count];
            for(int i =0;i<Operations.foodDetailsList.Count ;i++)
            {
                food[i] = Operations.foodDetailsList[i].FoodID+","+Operations.foodDetailsList[i].FoodName+","+Operations.foodDetailsList[i].FoodPrice+","+Operations.foodDetailsList[i].AvailableQuantity;
            }
            File.WriteAllLines("CafeteriaCardManagement/FoodDetails.csv",food);

            string[] cart = new string [Operations.cartItemsList.Count];
            for(int i =0;i<Operations.cartItemsList.Count ;i++)
            {
                cart[i] = Operations.cartItemsList[i].ItemID+","+Operations.cartItemsList[i].OrderID+","+Operations.cartItemsList[i].FoodID+","+Operations.cartItemsList[i].OrderPrice+","+Operations.cartItemsList[i].OrderQuantity;
            }
            File.WriteAllLines("CafeteriaCardManagement/CartItem.csv",cart);

            string[] order = new string [Operations.orderDetailsList.Count];
            for(int i =0;i<Operations.orderDetailsList.Count ;i++)
            {
                order[i] = Operations.orderDetailsList[i].OrderID+","+Operations.orderDetailsList[i].UserID+","+Operations.orderDetailsList[i].OrderDate+","+Operations.orderDetailsList[i].TotalPrice+","+Operations.orderDetailsList[i].OrderStatus;
            }
            File.WriteAllLines("CafeteriaCardManagement/OrderDetails.csv",cart);
        }


        public static void ReadFromCSV()
        {
            string[] user = File.ReadAllLines("CafeteriaCardManagement/UserDetails.csv");
            foreach(string user1 in user)
            {
                UserDetails user2 = new UserDetails(user1);
                Operations.userDetailsList.Add(user2);
            }

            string[] food = File.ReadAllLines("CafeteriaCardManagement/FoodDetails.csv");
            foreach(string food1 in food)
            {
                FoodDetails food2 = new FoodDetails(food1);
                Operations.foodDetailsList.Add(food2);
            }

            string[] cart = File.ReadAllLines("CafeteriaCardManagement/CartItem.csv");
            foreach(string cart1 in cart)
            {
                CartItem cart2 = new CartItem(cart1);
                Operations.cartItemsList.Add(cart2);
            }

            string[] order = File.ReadAllLines("CafeteriaCardManagement/OrderDetails.csv");
            foreach(string order1 in order)
            {
                OrderDetails order2 = new OrderDetails(order1);
                Operations.orderDetailsList.Add(order2);
            }


        }
    }
}
      
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class Operations
    {
        public static CustomList<UserDetails> userDetailsList = new CustomList<UserDetails>();
        public static CustomList<OrderDetails> orderDetailsList = new CustomList<OrderDetails>();
        public static CustomList<FoodDetails> foodDetailsList = new CustomList<FoodDetails>();
        public static CustomList<CartItem> cartItemsList = new CustomList<CartItem>();
        static UserDetails currentUser;



        public static void AddDefaultDatas()
        {
            UserDetails user1 = new UserDetails("WS101", 400.0, "RAvi", "Ettapparajan", Gender.Male, 234567456, "ravi@gmail.com");
            userDetailsList.Add(user1);
            UserDetails user2 = new UserDetails("WS105", 500, "Baskarn", "Sethurajan", Gender.Male, 987654398, "baskaran@gmail.com");
            userDetailsList.Add(user2);

            foreach (UserDetails user in userDetailsList)
            {
                Console.WriteLine($"|  {user.UserID,-10}   |  {user.Name,-10}  |  {user.FatherName,-10}  |  {user.Phone,-10}  |  {user.MailID,-15}  |  {user.Gender,-15}  |  {user.WorkStationNumber,-10}  |  {user.WalletBalance,-10}");
            }

            OrderDetails order1 = new OrderDetails("SF1001", new DateTime(2020, 06, 15), 70, OrderStatus.Ordered);
            orderDetailsList.Add(order1);
            OrderDetails order2 = new OrderDetails("SF1002", new DateTime(2020, 06, 15), 100, OrderStatus.Ordered);
            orderDetailsList.Add(order2);

            foreach (OrderDetails order in orderDetailsList)
            {
                Console.WriteLine($"|  {order.OrderID}  |  {order.UserID}  |  {order.OrderDate}  |  {order.TotalPrice}  |  {order.OrderStatus}");
            }

            CartItem cart1 = new CartItem("OID1001", "FID101", 20, 1);
            cartItemsList.Add(cart1);
            CartItem cart2 = new CartItem("OID1001", "FID103", 10, 1);
            cartItemsList.Add(cart2);
            CartItem cart3 = new CartItem("OID1001", "FID105", 40, 1);
            cartItemsList.Add(cart3);
            CartItem cart4 = new CartItem("OID1002", "FID103", 10, 1);
            cartItemsList.Add(cart4);
            CartItem cart5 = new CartItem("OID1002", "FID104", 50, 1);
            cartItemsList.Add(cart5);
            CartItem cart6 = new CartItem("OID1002", "FID105", 40, 1);
            cartItemsList.Add(cart6);

            foreach (CartItem cart in cartItemsList)
            {
                Console.WriteLine($"|  {cart.ItemID,-10}  |  {cart.OrderID,-10}  |  {cart.FoodID,-10}  |  {cart.OrderPrice,-10}  |  {cart.OrderQuantity,-10}");
            }

            FoodDetails food1 = new FoodDetails("Coffee", 20, 100);
            foodDetailsList.Add(food1);
            FoodDetails food2 = new FoodDetails("Tea", 15, 100);
            foodDetailsList.Add(food2);
            FoodDetails food3 = new FoodDetails("Biscuit", 10, 100);
            foodDetailsList.Add(food3);
            FoodDetails food4 = new FoodDetails("Juice", 50, 100);
            foodDetailsList.Add(food1);
            FoodDetails food5 = new FoodDetails("Puff", 40, 100);
            foodDetailsList.Add(food5);
            FoodDetails food6 = new FoodDetails("Milk", 10, 100);
            foodDetailsList.Add(food6);
            FoodDetails food7 = new FoodDetails("PopCorn", 20, 20);
            foodDetailsList.Add(food7);

            foreach (FoodDetails food in foodDetailsList)
            {
                Console.WriteLine($"|  {food.FoodID,-10}  |  {food.FoodName,-15}  |  {food.FoodPrice,-10}  |  {food.AvailableQuantity,-10}");
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("\t\t\tApplication For Cafeteria Card Management\t\t\t");
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

        public static void Exit()
        {
            Console.WriteLine("Exiting..!");
        }

        public static void Login()
        {
            Console.WriteLine("Enter the Login ID:");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (UserDetails user in userDetailsList)
            {
                //int result = BinarySearch.BinaryLogin(userDetailsList, loginID);
                if (user.UserID == loginID)
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
                Console.WriteLine("1.Show My Profile  2.Food Order  3.Modify Order  4.Cancel order  5.Order History  6.Wallet recharge  7.Show Wallet Balance  8.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            FoodOrder();
                            break;
                        }
                    case 3:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 4:
                        {
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
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
                    default:
                        {
                            break;
                        }
                }
            } while (flag);
        }

        public static void ShowMyProfile()
        {
            foreach (UserDetails details in userDetailsList)
            {
                if (currentUser.UserID == details.UserID)
                {
                    Console.WriteLine($"| {currentUser.UserID}  |  {currentUser.Name}  |  {currentUser.FatherName,-10}  |  {currentUser.Phone,-10}  |  {currentUser.MailID}  |  {currentUser.Gender}  |  {currentUser.WorkStationNumber}");
                }
            }
        }

        public static void FoodOrder()
        {

            //1.Create a temporary local carItemtList.
            //2.Create an Order object with current UserID, Order date as current DateTime, total price as 0, Order status as “Initiated”.
            //3.Ask the user to pick a product using FoodID, quantity required and calculate price of food.
            //4.If the food and quantity available, reduce the quantity from the food object’s “AvailableQuantity” then create CartItems object using the available data.
            //5.Add that object it to local CartItemsList to add it to cart wish list.
            //6.Ask the user whether he want to pick another product. 
            //7.If “Yes” then show the updated Food Details and repeat from step “3”.
            //8.Repeat the process until the user enters “No”.
            //9.If He says No then, 
            //10.Ask the user whether he confirm the wish list to purchase. 
            //If he says “No” then traverse the local CartItemList and get the Items one by one and reverse the quantity to the FoodItem’s objects in the foodList.
            //11.If he says “Yes” then, Calculate the total price of the food items selected using the local CartItemList information and check the balance from the user details whether it has sufficient balance to purchase.
            //12.If he has enough balance, then deduct the respective amount from the user’s balance. 

            CustomList<CartItem> localCartList = new CustomList<CartItem>();
            OrderDetails order = new OrderDetails(currentUser.UserID, DateTime.Now, 0, OrderStatus.Initiated);
            double totalPrice = 0;
            string choice = "";
            do
            {
                foreach (FoodDetails food in foodDetailsList)
                {
                    Console.WriteLine($"|  {food.FoodID,-10}  |  {food.FoodName,-15}  |  {food.FoodPrice,-10}  |  {food.AvailableQuantity,-10}");
                }
                Console.WriteLine("Enter foodID: ");
                string foodID = Console.ReadLine();
                Console.WriteLine("Enter food Quantity :");
                int quantity = int.Parse(Console.ReadLine());
                bool flag = true;
                double price;
                foreach (FoodDetails food in foodDetailsList)
                {
                    if (food.FoodID == foodID)
                    {
                        if (food.AvailableQuantity >= quantity)
                        {
                            flag = false;
                            price = quantity * food.FoodPrice;
                            food.AvailableQuantity = food.AvailableQuantity - quantity;
                            totalPrice = totalPrice + price;
                            CartItem newCart = new CartItem(order.OrderID, foodID, price, quantity);
                            localCartList.Add(newCart);
                        }
                        else
                        {
                            Console.WriteLine("quantity not available");
                        }
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Invalid foodID");
                }

                Console.WriteLine("Do you want to pick another product : yes/no ");
                choice = Console.ReadLine();

            } while (choice == "yes");

            Console.WriteLine("Do you wish to purchase the wish list to purchase: ");
            string option = Console.ReadLine().ToLower();
            if (option == "yes")
            {

                bool temp = false;
                do
                {
                    if (totalPrice <= currentUser.WalletBalance)
                    {
                        temp = false;
                        cartItemsList.AddRange(localCartList);
                        order.OrderStatus = OrderStatus.Ordered;
                        order.TotalPrice = totalPrice;
                        currentUser.DeductAmount(totalPrice);
                        orderDetailsList.Add(order);
                        Console.WriteLine($"Order placed successfully and ypur order ID id {order.OrderID}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficent balance to purchase.\n Are you willing to recharge: ");
                        string choice1 = Console.ReadLine().ToLower();
                        if (choice1 == "yes")
                        {
                            temp = true;
                            Console.WriteLine("Enter the amount to recharge: ");
                            double amount = double.Parse(Console.ReadLine());
                            currentUser.WalletRecharge(amount);
                            Console.WriteLine("Your current balance is " + currentUser.WalletBalance);
                        }
                        else
                        {
                            temp = false;
                            foreach (CartItem cart in cartItemsList)
                            {
                                foreach (FoodDetails food in foodDetailsList)
                                {
                                    if (cart.FoodID == food.FoodID)
                                    {
                                        food.AvailableQuantity = food.AvailableQuantity - cart.OrderQuantity;
                                    }
                                }
                            }
                        }

                    }
                } while (temp);

            }

            else
            {
                foreach (CartItem cart in cartItemsList)
                {
                    foreach (FoodDetails food in foodDetailsList)
                    {
                        if (cart.FoodID == food.FoodID)
                        {
                            food.AvailableQuantity = food.AvailableQuantity - cart.OrderQuantity;
                        }
                    }
                }
            }



        }

        public static void ModifyOrder()
        {

            //1.Show the Order details of current logged in user to pick an Order detail by using OrderID  whose status is “Ordered”. 
            bool flag = true;
            foreach (OrderDetails order in orderDetailsList)
            {
                //Check whether the order details is present. If yes then,
                if (currentUser.UserID == order.UserID && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag = true;
                    Console.WriteLine($"{order.OrderID}  {order.UserID}  {order.OrderDate}  {order.TotalPrice}  {order.OrderStatus}");
                    //2.Show list of Cart Item details and ask the user to pick an Item id.
                }
            }
            if (flag)
            {
                Console.WriteLine("No order to cancel");
            }
            if (!flag)
            {
                bool Isflag = true;
                foreach (CartItem cart in cartItemsList)
                {
                    Console.WriteLine($"{cart.ItemID}  {cart.OrderID}  {cart.FoodID}  {cart.OrderPrice}  {cart.OrderQuantity}");
                }


                Console.WriteLine("Enter the Order ID that you want to modify: ");
                string orderID = Console.ReadLine();

                foreach (OrderDetails order in orderDetailsList)
                {
                    if (order.OrderID == orderID && order.OrderStatus == OrderStatus.Ordered)
                    {

                        foreach (CartItem cart in cartItemsList)
                        {
                            //3.Ensure the ItemID is available
                            
                            if (cart.OrderID == orderID)
                            {
                                //ask the user to enter the new quantity of the food. 
                                Isflag = false;
                                Console.WriteLine("Enter item ID: ");
                                string itemID = Console.ReadLine();
                                bool flag1 = true;
                                foreach (CartItem cart1 in cartItemsList)
                                {
                                    if (cart.ItemID == itemID)
                                    {
                                        Isflag = false;
                                        Console.WriteLine("Enter new quantity of food: ");
                                        int quantity = int.Parse(Console.ReadLine());

                                        foreach (FoodDetails food in foodDetailsList)
                                        {
                                            if (food.FoodID == cart.FoodID)
                                            {
                                                // Calculate the Item price and update in the OrderPrice.
                                                if (food.AvailableQuantity <= quantity)
                                                {
                                                    //flag1 = true;
                                                    int finalquantityCheck = quantity - cart.OrderQuantity;
                                                    if (finalquantityCheck == 0)
                                                    {
                                                        Console.WriteLine("Same Quantity entered");
                                                    }
                                                    else if (finalquantityCheck < 0)
                                                    {
                                                        cart.OrderQuantity += finalquantityCheck;
                                                        double returnAmount = -finalquantityCheck * food.FoodPrice;
                                                        currentUser.WalletRecharge(returnAmount);
                                                        food.AvailableQuantity += -finalquantityCheck;
                                                        Console.WriteLine("Ordered modified successfully");
                                                    }
                                                    else
                                                    {
                                                        double returnAmount = finalquantityCheck * food.FoodPrice;
                                                        if (currentUser.WalletBalance > returnAmount)
                                                        {
                                                            cart.OrderQuantity += finalquantityCheck;
                                                            currentUser.DeductAmount(returnAmount);
                                                            food.AvailableQuantity -= finalquantityCheck;
                                                            Console.WriteLine("Ordered modified successfully");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Insufficient balance to modify order. Recharge and proceed again");
                                                        }

                                                    }
                                                }
                                            }
                                        }
                                        if (flag1)
                                        {
                                            Console.WriteLine("Quantity not availble");
                                        }
                                    }
                                }
                            }
                            if(Isflag)
                            {
                                Console.WriteLine("Invalid order ID");
                            }
                        }
                    }
                }
            }
        }
                    
                    public static void CancelOrder()
                    {
                        bool flag = false;
                        // 1.Show the Order details of the current user who’s Order status is “Ordered”.
                        foreach (OrderDetails order in orderDetailsList)
                        {
                            if (currentUser.UserID == order.UserID)
                            {
                                flag = true;
                                Console.WriteLine($"|  {order.OrderID,-10}  |  {order.UserID,-10}  |  {order.OrderDate,-15}  |  {order.TotalPrice,-10}  |  {order.OrderStatus,-15}");
                            }
                        }
                        if (flag)
                        {
                            Console.WriteLine("No order placed");
                        }
                        if (!flag)
                        {
                            //2.Ask the user to pick an OrderID to cancel.
                            Console.WriteLine("Enter the OrderID to cancel the order: ");
                            string orderID = Console.ReadLine().ToLower();

                            // 3.	Check the OrderID is valid. If not, then show “Invalid OrderID”.
                            foreach (OrderDetails order in orderDetailsList)
                            {
                                if (order.OrderID == currentUser.UserID && order.OrderStatus == OrderStatus.Ordered)
                                {
                                    //4.	If valid, then Return the Order total amount to current user. 
                                    currentUser.WalletRecharge(order.TotalPrice);
                                    //5.	Return product orderQuantity to Foodtem list’s FoodQuantity. 
                                    foreach (CartItem cart in cartItemsList)
                                    {
                                        if (cart.OrderID == order.OrderID)
                                        {
                                            foreach (FoodDetails food in foodDetailsList)
                                            {
                                                if (cart.FoodID == food.FoodID)
                                                {
                                                    food.AvailableQuantity += cart.OrderQuantity;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    //6.Change the OrderStatus as Cancelled.
                                    order.OrderStatus = OrderStatus.Cancelled;
                                    //7.Show “Order cancelled successfully” and product returned to cart.
                                    Console.WriteLine("Order cancelled successfully and product returned to cart");
                                }
                            }
                        }

                    }

                    public static void OrderHistory()
                    {
                        foreach (OrderDetails order in orderDetailsList)
                        {
                            if (currentUser.UserID == order.UserID)
                            {
                                Console.WriteLine($"|  {order.OrderID}  |  {order.UserID}  |  {order.OrderDate}  |  {order.TotalPrice}  |  {order.OrderStatus}");
                            }
                        }

                    }
                    public static void WalletRecharge()
                    {
                        Console.WriteLine("Are you sure that you want to recharge: ");
                        string option = Console.ReadLine().ToUpper();
                        if (option == "Yes")
                        {
                            Console.WriteLine("Enter the amount to recharge: ");
                            double rechargeAmount = double.Parse(Console.ReadLine());
                            if (rechargeAmount > 0)
                            {
                                currentUser.WalletRecharge(rechargeAmount);
                            }
                            else
                            {
                                Console.WriteLine("Please enter valid amount to recharge");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enter valid update");
                        }
                    }

                    public static void ShowWalletBalance()
                    {
                        Console.WriteLine("your Current Wallet Balance: " + currentUser.WalletBalance);
                    }

                    public static void Registration()
                    {
                        Console.WriteLine("Enter Your Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Your Father Name: ");
                        string fatherName = Console.ReadLine();
                        Console.WriteLine("Enter Mobile Number: ");
                        long phone = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Your MailID: ");
                        string mailID = Console.ReadLine();
                        Console.WriteLine("Enter Gender: ");
                        Gender gender = Enum.Parse<Gender>(Console.ReadLine());
                        Console.WriteLine("Enter Your WorkStationNumber: ");
                        string workStationNumber = Console.ReadLine();
                        Console.WriteLine("Enter your balance: ");
                        double balance = double.Parse(Console.ReadLine());

                        UserDetails user = new UserDetails(workStationNumber, balance, name, fatherName, gender, phone, mailID);
                        userDetailsList.Add(user);

                        Console.WriteLine("Ypur registration ID is" + user.UserID);

                    }
                }
            }
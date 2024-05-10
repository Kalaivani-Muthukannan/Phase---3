using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class BinarySearch
    {
        public string UserID { get; set; }
        public static UserDetails BinaryLogin(string searchElement)
        {
            CustomList<UserDetails> userDetailsList=Operations.userDetailsList;
            int left = 0;
            int right = userDetailsList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                int number = string.Compare(userDetailsList[middle].UserID,searchElement);
                if (number == 0)
                {
                    return userDetailsList[middle];
                }
                else if (number < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }

            }
            return null;
        }

        public static int BinaryCancel(CustomList<OrderDetails> orderDetailList, string searchElement)
        {
            int left = 0;
            int right = orderDetailList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                int number = string.Compare(orderDetailList[middle].OrderID,searchElement);
                if (number == 0)
                {
                    return middle;
                }
                else if (number < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }

            }
            return -1;
        }

        public static int BinaryModify(CustomList<OrderDetails> orderDetailList, string searchElement)
        {
            int left = 0;
            int right = orderDetailList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                int number = string.Compare(orderDetailList[middle].OrderID,searchElement);
                if (number == 0)
                {
                    return middle;
                }
                else if (number < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }

            }
            return -1;
        }



    }
}
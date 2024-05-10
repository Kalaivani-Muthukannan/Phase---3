using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {
        private static int s_cardNumber = 1000;
        public string CardNumber { get; }
        public double Balance { get; set; }

        public UserDetails(string name, long phone,double balance)
        :base(name,phone)
        {
            s_cardNumber++;
            CardNumber = "CMRL" + s_cardNumber;
            Balance=balance;
        }

        public UserDetails(string user1)
        {
            string[] values = user1.Split(",");
            s_cardNumber = int.Parse(values[0].Remove(0,4));
            CardNumber = values[0];
            Name = values[1];
            Phone = long.Parse(values[2]);
            Balance=double.Parse(values[3]);
        }

        public void WalletBalance(double amount)
        {
            Balance+=amount;
        }
        public void DeductBalance(double amount)
        {
            Balance-=amount;
        }
        



        
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class UserRegistration: PersonalDetail,IWalletManager
    {
        private static int s_userID = 1000;
        public string  UserID { get; set; }
        public int _balance { get; set; }
        public int WalletBalance { get{return _balance;} }



        public UserRegistration(string name, long phone, long aadharNo, string address, FoodType foodType, Gender gender,int walletBalance)
        :base(name, phone, aadharNo,address, foodType, gender)
        {
            s_userID ++;
            UserID = "UID" +s_userID;
            _balance = walletBalance;
        }

        public UserRegistration(string user1)
        {
            string[] values = user1.Split(",");
            s_userID = int.Parse(values[0].Remove(0,3));
            UserID = values[0];
            Name = values[1];
            Phone = long.Parse(values[2]);
            AadharNo = long.Parse(values[3]);
            Address = values[4];
            FoodType = Enum.Parse<FoodType>(values[5]);
            Gender = Enum.Parse<Gender>(values[6]);
            _balance = int.Parse(values[7]);
        }

        public void WalletRecharge(int rechargeAmount)
        {
            _balance += rechargeAmount;
        }
        public void DeductBalance(int deductAmount)
        {
            _balance -= deductAmount;
        }


    }
}
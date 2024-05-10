using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class UserDetails: PersonalDetails, IBalance
    {
        // UserID (Auto – SF1001)
        // WorkStationNumber
        // Field: _balance
        // Read only property: WalletBalance.

        private static int s_UserID = 1000;
        public string UserID { get; set; }
        public string WorkStationNumber { get; set; }
        public double _balance { get; set; }
        public double WalletBalance { get{return _balance;} }

        public UserDetails(string workStationNumber, double walletBalance,string name, string fatherName, Gender gender, long phone, string mailID)
        :base(name, fatherName, gender, phone, mailID)
        {
            s_UserID++;
            UserID = "SF" + s_UserID;
            WorkStationNumber = workStationNumber;
            _balance = walletBalance;
        }
        public UserDetails(string data)
        {
            string [] datalist = data.Split(",");
            s_UserID = int.Parse(datalist[0].Remove(0,2));
            UserID = datalist[0];
            WorkStationNumber = datalist[1];
            _balance = double.Parse(datalist[2]);

        }

        public void WalletRecharge(double rechargeAmount)
        {
            _balance = _balance + rechargeAmount;
        }

        public void DeductAmount(double deductingAmount)
        {
            _balance = _balance - deductingAmount;
        }







    }
}
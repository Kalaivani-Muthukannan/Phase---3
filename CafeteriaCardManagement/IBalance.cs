using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public interface IBalance
    {
        //Properties: WalletBalance
         double WalletBalance { get; }


       void WalletRecharge(double rechargeAmount);
       void DeductAmount(double deductingAmount);      
    }
}
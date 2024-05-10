using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public interface IWalletManager
    {
         int WalletBalance { get;  }

         void WalletRecharge(int rechargeAmount);

         void DeductBalance(int deductAmount);

    }
}
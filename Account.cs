using System;
using SplashKitSDK;

public class Account
{

    private decimal _balance;

    private string _name;
                
        public Account(string name, decimal startingBalance)
        {
            _name = name;
            _balance = startingBalance;

        }

        public bool Deposit (decimal amountToDeposit)
        {
            if (amountToDeposit > 0)
            {
                _balance += amountToDeposit;

                return true;
            }
            return false;
        }

        public bool Withdraw (decimal amountToWithdraw)
        {
            if (amountToWithdraw > 0)
            {
                _balance -= amountToWithdraw;
                return true;
            }
            return false;
        }

        public string Name
        {
            get{return _name;}
            
        }   

        public decimal Balance
        {
            get{return _balance;}
            
        }
        
}
        


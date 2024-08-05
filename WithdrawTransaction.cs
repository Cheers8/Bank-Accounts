using System;
using SplashKitSDK;

    public class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed = false;
        private bool _success = false;
        private bool _reversed = false;

        public bool Success
        {
            get
            {
                return _success;
            }
        }

        public bool Executed
        {
            get
            {
                return _executed;
            }
        }

        public bool Reversed
        {
            get
            {
                return _reversed;
            }
        }

        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute()
        {
            if ( _executed )
            {
                throw new Exception("Cannot execute this transaction as it has already been executed.");
            }
            _executed = true;
            _success = _account.Withdraw(_amount);
        }

        public void Rollback()
        {
            if (!_executed )
            {
                throw new Exception("Cannot rollback this transaction as it has not been executed.");
            }
            if ( _reversed )
            {
                throw new Exception("Cannot reverse this transaction as it has been reversed.");
            }
            _reversed = true;
            _account.Deposit(_amount);
            

        }
        public void Print()
        {
            if (_success)
            {
                Console.WriteLine("Withraw successful.");
            }
        }
    }

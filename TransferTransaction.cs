using System;
using SplashKitSDK;

    public class TransferTransaction
    {
        private Account _toAccount;
        private Account _fromAccount;
        private decimal _amount;
        private DepositTransaction _theDeposit;
        private WithdrawTransaction _theWithdraw;
        private bool _executed = false;
        private bool _success = false;
        private bool _reversed = false;

        public bool Success
        {
            get
            {
                if(_theWithdraw.Success && _theDeposit.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
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

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;

            DepositTransaction _theDeposit = new DepositTransaction(_toAccount, amount);

            WithdrawTransaction _theWithdraw = new WithdrawTransaction(_fromAccount, amount);
        }

        public void Execute()
        {
            if ( _executed)
            {
                throw new Exception("Cannot execute this transaction as it has already been executed.");
            }
            _executed = true;
            _success = _fromAccount.Withdraw(_amount);
            if (_success)
            {
                _success = _toAccount.Deposit(_amount);
            }
            
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
            if(_theWithdraw.Success)
            {
                _theWithdraw.Rollback();
            }
                
            if(_theDeposit.Success)
            {
                _theDeposit.Rollback();
            }
                
            _reversed = true;

        }
        public void Print()
        {
            if (_success)
            {
                Console.WriteLine("Transfer successful.");
            }
        }
    }
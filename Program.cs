using System;
using SplashKitSDK;

public enum MenuOption
{
    Withdraw,
    Deposit,
    Transfer,
    Print,
    Quit

}   

public class Bank
{
    
    private static MenuOption ReadUserOption()
    {
        int Option;

        Console.WriteLine("-1 Withdrawal-, -2 Deposit-, -3 Transfer, -4 Print- and -5 Quit-");

        try
        {
                Console.WriteLine("Choose an option: ");
                
                Option = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            throw new Exception("Please enter a valid option");
        } 
        
        return (MenuOption)(Option -1);
        
    }
                
    public static void Main()
    {
        Account account = new Account("Jackie", 100000); 
        Account fromAccount = new Account("Jakes", 20000);
        Account toAccount = new Account("Jackie", 100000);
        decimal amount = 0.0m;   
        
        MenuOption UserSelection;
        
        do
        {
            UserSelection = ReadUserOption();

            switch(UserSelection)
            {
                
                case MenuOption.Withdraw:
                    DoWithdraw(account);
                    break;

                case MenuOption.Deposit:
                    DoDeposit(account);
                    break;

                case MenuOption.Transfer:
                    DoTransfer(fromAccount, toAccount, amount);
                    break;

                case MenuOption.Print:
                    DoPrint(account);
                    break;

                case MenuOption.Quit:
                    Console.WriteLine("Quit");
                    break;
            }

        }while (UserSelection != MenuOption.Quit);

        Console.WriteLine(UserSelection);
    }

    private static void DoWithdraw(Account account)
    {
        Console.WriteLine();
        Console.WriteLine("Please enter your withdrawal amount: $");

        decimal withdrawalAmount;
        try
        {
            withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
            account.Withdraw(withdrawalAmount);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "Please enter a valid number");
            Console.WriteLine();
        }

        Console.WriteLine("Withdraw successful");
    }

    private static void DoDeposit(Account account)
    {
        decimal amount;
        Console.WriteLine("How much do you want to deposit: ");
        try
        {
            amount = Convert.ToDecimal(Console.ReadLine());

            bool result = account.Deposit(amount);
            if (result)
            {
                Console.WriteLine("This deposit was successful.");

            }
            else
            {
                Console.WriteLine("This deposit was not successful.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

    }

    private static void DoTransfer(Account fromAccount, Account toAccount, decimal amount)
    {
        decimal transferAmount;

        Console.WriteLine("How much would you like to transfer?");

        transferAmount = Convert.ToDecimal(Console.ReadLine());

        TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, transferAmount);

        transfer.Execute();

        Console.WriteLine("Transfer successful.");
    }
    
    private static void DoPrint(Account account)
    {
        Account bankAccount = new Account ("Jackie Account", 100000);

        Console.WriteLine(bankAccount.Name + "" + bankAccount.Balance);

        Console.WriteLine("Printing account.");
    }
}

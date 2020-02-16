using System;

namespace mySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Kendra", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");

            account.MakeWithdrawal(200, DateTime.Now, "Jackpot");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.AccountHistory());
            //account.MakeDeposit(-300, DateTime.Now, "Yes this is work");
        }
    }
}

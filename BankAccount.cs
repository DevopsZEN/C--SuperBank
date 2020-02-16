using System;
using System.Collections.Generic;
using System.Text;

namespace mySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        { 
            get 
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note) 
        {
            if(amount <= 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount must be above 0");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount must be a positive");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("You can't draw you balance don't have money to draw");
            }
            var withdraw = new Transaction(-amount, date, note);
            allTransactions.Add(withdraw);
        }

        public string AccountHistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\t\tNote");
            foreach(var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}

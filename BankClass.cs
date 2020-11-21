using System;
using System.Collections.Generic;
using System.Linq;

namespace E_ATM
{
    public class BankClass : IBank
    {
        public int amountOfWithdrawnsLeft { get; set; }
        public int maxAmount { get; set; }
        public double amountOfExistingMoney = 10000;
        private List<double> transaction = new List<double>();
        private List<double> deposit = new List<double>();
        private List<DateTime> time = new List<DateTime>();

        public BankClass()
        {
        }

        public bool Withdrawn(double amount)
        {
            maxAmount = 5000;
            var date = DateTime.Now;

            if (amount <= amountOfExistingMoney && amount <= maxAmount)
            {
                amountOfExistingMoney -= amount;
                transaction.Add(amount);
                time.Add(date);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AllTransaction()
        {
            string output = "";
            var timeAndMoney = time.Zip(transaction, (n, w) => new { time = n, money = w });
            foreach (var nw in timeAndMoney)
            {
                output += ($"{nw.time}:-{nw.money}kr\n");
            }
            var timeAndMoney1 = time.Zip(deposit, (n, w) => new { time = n, money = w });
            foreach (var nw in timeAndMoney1)
            {
                output += ($"{nw.time}:+{nw.money}kr\n");
            }
            return output + $"Tillgängligt belopp: {amountOfExistingMoney} kr";
        }

        public double Deposit(double amount)
        {
            amountOfExistingMoney += amount;
            deposit.Add(amount);
            return amountOfExistingMoney;
        }

        public string CheckAmountOfWithdraw(double money, bool withdraw)
        {
            amountOfWithdrawnsLeft = 5;
            string output = "";
            if (withdraw && amountOfWithdrawnsLeft > 0)
            {
                amountOfWithdrawnsLeft--;
                output = $"Du tog ut {money} kr! Ditt nya belopp är {amountOfExistingMoney}\nDu har {amountOfWithdrawnsLeft} uttag kvar";
            }
            else if (amountOfWithdrawnsLeft == 0)
            {
                output = "Du har överskridit antalet uttag!";
            }
            else
            {
                output = "Du har skrivit in ett ogiltigt belopp!";
            }
            return output;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_ATM
{
    public class BankClass : IBank
    {

        public int amountOfWithdrawnsLeft = 5;
        public int maxAmount { get; set; }
        public double amountOfExistingMoney = 10000;
        public double amount { get; set; }
        public double amountOfExisting { get; set; }
        public DateTime Birthday { get; set; } = DateTime.Now;

        private List<double> Transaction = new List<double>();
        private List<DateTime> time = new List<DateTime>();





        public BankClass()
        {
        }


        public double CheckAmountOfExistingMoney()
        {
            return amountOfExistingMoney;
        }

        public bool Withdrawn(double amount)
        {

            var date = DateTime.Now;
            try
            {

                if (amount <= amountOfExistingMoney)
                {
                    amountOfExistingMoney -= amount;
                    Transaction.Add(amount);
                    time.Add(date);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public string AllTransaction()
        {  
             string output = "";
            var timeAndMoney = time.Zip(Transaction, (n, w) => new { time = n, money = w });
            foreach (var nw in timeAndMoney)
            {
                output += ($"{nw.time} {nw.money}kr");
            }
            return output;

        }
        public double Deposit(double amount)
        {
            try
            {
                amountOfExistingMoney += amount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return amountOfExistingMoney;

        }

        public string CheckAmountOfWithdraw(double money, bool withdraw)
        {
            int amountOfWithdrawnsLeft1 = amountOfWithdrawnsLeft;
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



        public void CheckMaxAmount()
        {


        }



    }

}
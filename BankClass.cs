using System;

namespace E_ATM
{
    public class BankClass : IBank
    {

        public int amountOfWithdrawnsLeft = 5;
        public int maxAmount { get; set; }
        public double amountOfExistingMoney = 10000;
        public double amount { get; set; }
        public double amountOfExisting {get; set;}



        public BankClass()
        {
        }

        public double CheckAmountOfExistingMoney()
        {
            return amountOfExistingMoney;
        }

        public bool Withdrawn(double amount)
        {

             try
            {
             
             if (amount <= amountOfExistingMoney)
            {
                amountOfExistingMoney -= amount;
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
                output= $"Du tog ut {money} kr! Ditt nya belopp är {amountOfExistingMoney}\nDu har {amountOfWithdrawnsLeft} uttag kvar";

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
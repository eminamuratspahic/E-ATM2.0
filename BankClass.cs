using System;

namespace E_ATM
{
    public class BankClass : IBank
    {

        //public int amountOfWithdrawnsLeft = 5;
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

        public void CheckAmountOfWithdraw()
        {


        }
        public void CheckMaxAmount()
        {


        }



    }

}
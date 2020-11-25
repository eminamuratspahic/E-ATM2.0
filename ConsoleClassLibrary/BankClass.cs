using System;
using DBClassLibrary;
using System.Collections.Generic;

namespace E_ATM
{
    public class BankClass : Login
    {
        public int amountOfWithdrawn;
        public int maxAmount;
        public int amountOfMoney;
       
        int userId = 0;
        public BankClass()
        {
            
        }

        public int CheckAmountOfMoney(int userId)
        {
            this.userId = userId;
            int balance = 0;
            foreach (var item in CheckBalance(userId))
            {
                balance = item.Balance;
            }
            return balance;
        }

        public List<HistoryData> Withdrawn(int userId)
        {
            this.userId = userId;
            List<HistoryData> data = new List<HistoryData>();

            foreach (var item in WithdrawHistory(userId))
            {
                data.Add(item);
            }
            return data;
        }

        public bool CheckAmountOfWithdraw(int userId)
        {
            List<UserData> data = new List<UserData>();
            data = CheckWithdrawalAttempts(userId);
            int attempts = 0;
            DateTime time = new DateTime();

            foreach (var item in data)
            {
                attempts = item.MaxAmount;
                time = item.Time;
            }
            
            if(attempts >= 5)
            {
                return false;
            }
            else
            {
                UpdateMaxWithdrawal(userId);
                return true;
            }

        }
        public void CheckMaxAmount()
        {
            UpdateMaxWithdrawal(userId);

        }
        public string WithdrawMoney(long amount, int userId)
        {
            this.userId = userId;
            long balance = CheckAmountOfMoney(userId);
            if (amount > balance)
            {
                return "Invalid amount, you do not have that amount of money!";
            }
            else
            {
                balance -= amount;
                Withdraw(userId, balance, amount, DateTime.Now.ToString("dd/MM/yyyy"));
                balance = CheckAmountOfMoney(userId);
                return $"Successfully withdrawn: {amount}kr from your account! Your current balance is now: {balance}kr";
            }

        }
        public string DepositMoney(int userId, long amount)
        {
            this.userId = userId;
            Deposit(userId, amount, DateTime.Now.ToString("dd/MM/yyyy"));
            long currentAmount = CheckAmountOfMoney(userId);
            return $"{amount}kr deposited, current balance {currentAmount}";
            
           

        }



    }

}
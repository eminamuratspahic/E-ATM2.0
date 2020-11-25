using System;
using System.Collections.Generic;
using System.Linq;
using DBClassLibrary;


namespace E_ATM
{
    public class Login : DBManager
    {
        public List<User> userData = new List<User>();
        public int UserLoginNumber(int cardNumber)
        {

            foreach (var item in LoginUser(cardNumber))
            {
                userData.Add(item);
            }

            return GetUserID();

        }
        public int UserLoginPass(int cardNumber, int passCode)
        {
            userData.Clear();
            foreach (var item in LoginUserPassCode(cardNumber, passCode))
            {
                userData.Add(item);
            }
            return GetUserID();

        }



        public void FailAttempt(int userId)
        {
            AddAttempts(userId, 1, DateTime.Now.ToString("HH:mm"));
        }
        public bool CheckFailAttempt(int userId)
        {
            List<LoginAttempts> attemptList = new List<LoginAttempts>();
            attemptList = CheckAttempts(userId);
            int attempts = 0;
            DateTime time = new DateTime();
            foreach (var item in attemptList)
            {
                attempts = item.Attempts;
                time = item.Time;

            }

            if (attempts >= 3)
            {
                if ((DateTime.Now - time).TotalMinutes <= 1)
                {

                    return false;
                }
                else
                {
                    UpdateAttempts(userId);
                    return true;
                }

            }
            else
                return true;
        }


        public int GetUserID()
        {
            int userId = 0;
            foreach (var item in userData)
            {
                userId = item.Id;
            }
            return userId;

        }

        public void RegisterNewUser(string firstName, string lastName, int cardNumber, int passCode)
        {
            RegisterUser(firstName, lastName, cardNumber, passCode);
            int userId = 0;
            foreach (var item in LoginUser(cardNumber))
            {
                userId = item.Id;
            }
            CreateData(userId, 1000);

        }





    }
}
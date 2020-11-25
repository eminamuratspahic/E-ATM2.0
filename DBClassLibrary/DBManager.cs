using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;


namespace DBClassLibrary
{

    public class DBManager
    {
        private readonly string dbConnection = "Server=40.85.84.155;Database=Student8;User=Student8;Password=zombie-virus@2020;";


        public List<User> LoginUser(int cardNumber)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {

                return connection.Query<User>($"exec dbo.sp_GetUserCard '{cardNumber}';").AsList();

            }
        }
        public List<User> LoginUserPassCode(int cardNumber, int passCode)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {

                return connection.Query<User>($"exec dbo.sp_GetUserPass '{cardNumber}', '{passCode}';").AsList();

            }
        }

        public void RegisterUser(string firstName, string lastName,  int cardNumber, int passCode)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Query($"exec dbo.sp_RegisterUser '{firstName}', '{lastName}',  '{cardNumber}' , '{passCode}';");
            }
        }
        public void CreateData(int userId, long balance)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Query($"exec dbo.sp_CreateData '{userId}', '{balance}';");
            }
        }

        public List<UserData> CheckBalance(int userId)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                return connection.Query<UserData>($"exec dbo.sp_CheckBalance '{userId}';").AsList();
            }
        }

        public List<HistoryData> WithdrawHistory(int userId)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                return connection.Query<HistoryData>($"exec dbo.sp_WithdrawHistory '{userId}';").AsList();
            }
        }
        public void Withdraw(int userId, long balance, long withDrawn, string date)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Query($"exec dbo.sp_Withdraw '{userId}', '{balance}', '{withDrawn}', '{date}';");
            }
        }
          public void Deposit(int userId, long amount, string date)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Query($"exec dbo.sp_Deposit '{userId}', '{amount}', '{date}';");
            }
        }

        public void AddAttempts(int userId, int attempts, string time)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Query($"exec dbo.sp_Attempts '{userId}', '{attempts}', '{time}';");
            }
        }

        public List<LoginAttempts> CheckAttempts(int userId)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                return connection.Query<LoginAttempts>($"exec dbo.sp_CheckAttempts '{userId}';").AsList();
            }
        }
          public List<UserData> CheckWithdrawalAttempts(int userId)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                return connection.Query<UserData>($"exec dbo.sp_WithdrawalAttempts '{userId}';").AsList();
            }
        }
        public void UpdateAttempts(int userId)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Query($"exec dbo.sp_UpdateAttempts '{userId}';");
            }
        }
         public void UpdateMaxWithdrawal(int userId)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Query($"exec dbo.sp_MaxWithdrawalUpdate '{userId}';");
            }
        }


    }

}
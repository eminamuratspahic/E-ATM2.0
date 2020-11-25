using System;
using System.Collections.Generic;
using System.Linq;
using DBClassLibrary;

namespace E_ATM
{
    public class Register:DBManager
    {
        
        
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
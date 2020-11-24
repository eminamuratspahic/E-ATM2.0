using System;

namespace E_ATM
{
    public class LoginClass : ILogin
    {
        public int pinNum { get; set; }
        public int cardNum { get; set; }
        public int amountOfTries { get; set; }
        MenuClass menuClass = new MenuClass();
        public LoginClass()
        {
        }

        public bool VerifyCardNumber(double card)
        {
            if (cardNum == card)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string VerifyPin(double pin)
        {
            string output = "";

                if (amountOfTries > 0 && pinNum == pin)
                {
                    output += "Grattis! Du kom in!";
                    menuClass.ShowMenu();
                }
                else if (amountOfTries == 0)
                {
                    output += "För många misslyckade försök! Ditt kort spärras!";
                    Environment.Exit(0);
                }
                else
                {
                    amountOfTries--;
                    output += $"Fel försök igen! Du har {amountOfTries} försök kvar!";
                }
                return output;
        }
    }
}



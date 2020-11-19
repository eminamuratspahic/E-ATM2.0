using System;

namespace E_ATM
{

    
    public class LoginClass : ILogin
    {
        public int pinNum { get; set; }
        public int cardNum { get; set; }
        public int amountOfTries { get; set; }

        public LoginClass()
        {
        }

        public string VerifyCardNumber(int card)
        {
             while (true)
            {
                card = int.Parse(Console.ReadLine());

                if (cardNum == card)
                {
                    return "Grattis du kom in! Slå in din pinkod!";
                }else
                {
                    Console.WriteLine("Fel försök igen!");
                }
       
        }
        }

         public string VerifyPin(int pin)
         {

            amountOfTries = 0;

            while (true)
            {
                pin = int.Parse(Console.ReadLine());

                if (amountOfTries < 3 && pinNum == pin)
                {
                    return "Grattis du kom in!";

                }
                else if (amountOfTries > 3)
                {
                    return "För många misslyckade försök! Ditt kort spärras";
                }
                else
                {
                    Console.WriteLine("Fel försök igen!");
                    amountOfTries++;

                }

            }


        
    }
}
}
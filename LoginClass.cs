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
                try
                {
                    card = int.Parse(Console.ReadLine());

                    if (cardNum == card)
                    {
                        return "Grattis du kom in! Slå in din pinkod!";
                    }
                    else
                    {
                        Console.WriteLine("Fel försök igen!");
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Ange i siffror!");
                }
            }
        }

        public string VerifyPin(int pin)
        {
            amountOfTries = 0;
            while (true)
            {
                try
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
                catch (Exception)
                {
                    Console.WriteLine("Du har matat in felaktig format. Ange pin i siffror!");
                }
            }
        }
    }
}

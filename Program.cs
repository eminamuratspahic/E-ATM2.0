using System;

namespace E_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuClass menuClass = new MenuClass();
            LoginClass loginClass = new LoginClass();
            loginClass.cardNum = 123;
            loginClass.pinNum = 111;
            Console.Clear();
            Console.WriteLine("Välkommen till E-ATM!");
            Console.WriteLine("\nSkriv in ditt kortnummer!");
            loginClass.amountOfTries = 3;

            // metod för inloggning kortnr
            while (true)
            {
                double card = TryAndCatch();
                bool verify = loginClass.VerifyCardNumber(card);
                if (verify)
                {
                    Console.WriteLine("Grattis du kom in! Ange pin!");
                    while (true)
                    {
                        double pin = TryAndCatch();
                        Console.WriteLine(loginClass.VerifyPin(pin));
                    }
                }
                else if (!verify)
                {
                    Console.WriteLine("Fel! Försök igen!");

                }
            }
        }
            public static double TryAndCatch()
        {
            while (true)
            {
                try
                {
                    int money = Convert.ToInt32(Console.ReadLine());
                    return money;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange siffror!");
                }
            }
        }
    }
}



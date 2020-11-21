using System;

namespace E_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginClass loginClass = new LoginClass();
            loginClass.cardNum = 123;
            loginClass.pinNum = 111;
            Console.Clear();
            Console.WriteLine("Välkommen till E-ATM!");
            Console.WriteLine("\nSkriv in ditt kortnummer!");
            int pin = 0;
            int card = 0;

            // metod för inloggning kortnr
            Console.WriteLine(loginClass.VerifyCardNumber(card));

            // metod för inloggning pin
            Console.WriteLine(loginClass.VerifyPin(pin));
        }
    }
}



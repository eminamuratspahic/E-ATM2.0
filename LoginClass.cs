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

            amountOfTries = 3;

            while (true)
            {
                pin = int.Parse(Console.ReadLine());

                if (pinNum == pin)// det räckte om du kollar om pin är samma 
                {
                    //return "Grattis du kom in!"; // den här raden visades aldrig , man kommer direkt in om mans slår koden rätt
                    menuClass.ShowMenu();

                }
  /*               else if (amountOfTries > 3)
                {
                    return "För många misslyckade försök! Ditt kort spärras";
                    // Environment.Exit(0); // Man ska loggas ut om man slår koden 3 gånger fel, efter 5 försök så kommer vi in ändå 
                }
                else
                {
                    Console.WriteLine("Fel försök igen!");
                    amountOfTries++;

                } */

                else
                {
                    amountOfTries--;
                    Console.WriteLine($"Fel, Du har {amountOfTries} försök kvar!!");
                        

           if (amountOfTries == 1) 
                {
			        Console.WriteLine("Det här din sista försök, sen loggas du ut!!");   
                    
                }


           if (amountOfTries == 0) 
                {
                    Console.Clear();
			        Console.WriteLine("\nFör många misslyckade försök! Du loggas ut!!"); // Ändrade texten här då vi inte har nån spärrfunktion!!
			        Console.ReadKey();
                    Environment.Exit(0); // Man loggas ut om man slår koden 3 gånger fel,innan, efter 5 försök så komm vi in ändå 
                    
                }

            }

            }
        
    }
}
}
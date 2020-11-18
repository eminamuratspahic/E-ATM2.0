using System;

namespace E_ATM
{

    public class MenuClass
    {

        public string choice;

        BankClass bankClass = new BankClass();

        public enum MenuChoices
        {

            UTTAG = 1,
            TRANSAKTIONSHISTORIK,
            INSÄTTNING,
            AVSLUTA

        }
        public void ShowMenu()
        {
            while (true)
            {

                Console.Clear();
                int index = 0;
                Console.WriteLine("E-ATM\n");

                foreach (string str in Enum.GetNames(typeof(MenuChoices)))
                {
                    index++;

                    Console.WriteLine(index + ": " + str);
                }

                 Console.WriteLine ("\nAnge ditt val : 1-3 :\n");
                 string choice = Console.ReadLine ();

                       int intChoice; 
                    if (!int.TryParse(choice, out intChoice))
                {

                    Console.WriteLine("Valet ska anges i siffervärde, möjliga val 1-2-3.");
                    Console.WriteLine("Tryck valfritt knapp får att gå vidare...");
                    Console.ReadKey();
                }
                else
                {  // testar validering, komentera bort hit om det inte funkar
                    MenuChoices MenuChoice = (MenuChoices)Enum.Parse(typeof(MenuChoices), choice);

                    switch (MenuChoice)
                    {
                        case MenuChoices.UTTAG:
                            Console.WriteLine("UTTAG");

                            Console.WriteLine("Ange det beloppet du vill ta ut!");
                            double money = Convert.ToDouble(Console.ReadLine());
                            bool withdraw = bankClass.Withdrawn(money);
                            Console.WriteLine(bankClass.CheckAmountOfWithdraw(money,withdraw));


                            Console.ReadKey();

                            break;

                        case MenuChoices.TRANSAKTIONSHISTORIK:
                            Console.WriteLine("TRANSAKTIONSHISTORIK");
                            Console.WriteLine(bankClass.AllTransaction());
                            Console.WriteLine("Tryck valfritt knapp får att gå vidare...");
                            Console.ReadKey();
                            break;

                        case MenuChoices.INSÄTTNING:
                            Console.WriteLine("Var god och ange insättningsbeloppet:");
                            double amountOfMoney2 = double.Parse(Console.ReadLine());
                            double newBalance = bankClass.Deposit(amountOfMoney2);
                            Console.WriteLine($"Ditt nya belopp: {newBalance}");
                            Console.ReadKey();
                            break;
                            
                        case MenuChoices.AVSLUTA:
                            Console.WriteLine("LOGGA UT");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Felaktig val, försök igen.");
                            Console.WriteLine("Tryck valfritt knapp får att gå vidare...");
                            Console.ReadKey();
                            break;
                    }
                }
            }

        }

    }
}
using System;

namespace E_ATM
{

    public class MenuClass
    {
        BankClass bankClass = new BankClass();

        public enum MenuChoices
        {
            UTTAG = 1,
            TRANSAKTIONSHISTORIK,
            INSÄTTNING,
            AVSLUTA
        }

        public double TryAndCatch()
        {
            while (true)
            {
                try
                {
                    double money = Convert.ToDouble(Console.ReadLine());
                    return money;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange siffror!");
                }
            }
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

                    Console.WriteLine(index + ": " + str);// skriver ut enum-s alternativ med en index siffra på vänster sida, knuten till varje alternativ
                }

                Console.WriteLine("\nAnge ditt val : 1-4 :\n");
                string choice = Console.ReadLine();
                int intChoice;
                if (!int.TryParse(choice, out intChoice)) // testar om det inmatade valet är en siffra
                {

                    Console.WriteLine("Valet ska anges i siffervärde, möjliga val 1-2-3-4.");
                    Console.WriteLine("Tryck valfritt knapp får att gå vidare...");
                    Console.ReadKey();
                }
                else
                {
                    MenuChoices MenuChoice = (MenuChoices)Enum.Parse(typeof(MenuChoices), choice);
                    switch (MenuChoice)
                    {
                        case MenuChoices.UTTAG:
                            Console.WriteLine("UTTAG");
                            Console.WriteLine("Ange det beloppet du vill ta ut!");
                            double money = TryAndCatch();
                            bool withdraw = bankClass.Withdrawn(money);
                            Console.WriteLine(bankClass.CheckAmountOfWithdraw(money,withdraw));
                            Console.WriteLine("Tryck valfritt knapp får att gå vidare...");
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
                            double amountOfMoney2 = TryAndCatch();
                            double newBalance = bankClass.Deposit(amountOfMoney2);
                            Console.WriteLine($"Ditt nya belopp: {newBalance}");
                            Console.WriteLine("Tryck valfritt knapp får att gå vidare...");
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
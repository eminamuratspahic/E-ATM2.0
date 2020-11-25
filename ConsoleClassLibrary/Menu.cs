using System;
using DBClassLibrary;
using System.Collections.Generic;

namespace E_ATM
{
    public class Menu
    {
        Login test = new Login();
        Register register = new Register();
        BankClass bankclass = new BankClass();
        List<HistoryData> data = new List<HistoryData>();
        static int index = 0;
        int userId = 0;



        public List<string> selectMenus(int choice)
        {
            if (choice == 1)
            {
                List<string> loginMenu = new List<string>()
                {
                    "Login",
                    "Register",
                    "Exit"
                };
                return loginMenu;
            }
            else if (choice == 2)
            {
                List<string> UserMenu = new List<string>()
                {
                    "Withdraw",
                    "Check Balance",
                    "History",
                    "Deposit",
                    "Exit"
                };
                return UserMenu;
            }
            else
            {
                List<string> loginMenu = new List<string>()
                {
                    "Login",
                    "Register",
                    "Exit"
                };
                return loginMenu;
            }


        }

        public void LoginMenu(List<string> menuList)
        {
            while (true)
            {
                int selectMenuItem = SelectMenuFunction(menuList);
                switch (selectMenuItem)
                {
                    case 0:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Cardnumber:");
                            string cardNumber = Console.ReadLine();
                            try
                            {
                                if (test.UserLoginNumber(Convert.ToInt32(cardNumber)) != 0)
                                {
                                    userId = test.GetUserID();
                                    Console.WriteLine("Passcode:");
                                    string passCode = Console.ReadLine();
                                    if (bankclass.CheckFailAttempt(userId) && test.UserLoginPass(Convert.ToInt32(cardNumber), Convert.ToInt32(passCode)) != 0)
                                    {
                                        Console.WriteLine("Success");
                                        userId = test.GetUserID();
                                        test.UpdateAttempts(userId);
                                        UserMenu(selectMenus(2));
                                        break;
                                    }
                                    else if (!bankclass.CheckFailAttempt(userId))
                                    {
                                        Console.WriteLine("You have been blocked out from your account, to many attempts. Try again later!");
                                        userId = 0;
                                    }
                                    else
                                    {

                                        Console.WriteLine("Fail");
                                        test.FailAttempt(userId);
                                        userId = 0;
                                    }

                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input!");
                                Console.ReadKey();
                            }




                        }
                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("First Name:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Last Name:");
                        string lastName = Console.ReadLine();
                        Random rand = new Random();
                        string cardNr = "1337" + rand.Next(200, 999);
                        Console.WriteLine("New passcode: ");
                        string pass = Console.ReadLine();
                        bankclass.RegisterNewUser(firstName, lastName, Convert.ToInt32(cardNr), Convert.ToInt32(pass));
                        Console.WriteLine($"Success!\nCardnumber: {cardNr}\nPasscode: {pass}");
                        Console.ReadKey();
                        break;

                    case 2:

                        return;

                    default:
                        break;
                }
            }
        }

        public void UserMenu(List<string> menuList)
        {
            while (true)
            {
                int selectMenuItem = SelectMenuFunction(menuList);
                switch (selectMenuItem)
                {
                    case 0:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Amount to withdraw:");
                            try
                            {
                                string amount = Console.ReadLine();
                                if(bankclass.CheckAmountOfWithdraw(userId))
                                {
                                    Console.WriteLine(bankclass.WithdrawMoney(Convert.ToInt64(amount), userId));
                                }
                                Console.ReadKey();
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input!");
                                Console.ReadKey();
                            }






                        }
                        break;


                    case 1:
                        Console.Clear();
                        Console.WriteLine(bankclass.CheckAmountOfMoney(userId) + "kr");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        foreach (var item in bankclass.Withdrawn(userId))
                        {
                            Console.WriteLine($"{item.Withdrawn}kr {item.Date}");
                        }
                        Console.ReadKey();

                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Amount to deposit: ");
                        string depositAmount = Console.ReadLine();
                        
                        try
                        {
                            Console.WriteLine(bankclass.DepositMoney(userId, Convert.ToInt64(depositAmount)));
                            Console.ReadKey();
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Invalid input!");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        return;


                    default:
                        break;
                }
            }
        }

        static public int SelectMenuFunction(List<string> items)
        {

            Console.Clear();

            for (int i = 0; i < items.Count; i++) // Loop som ska skriva ut menyn 
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();


            }

            ConsoleKeyInfo keyPressed = Console.ReadKey(); // Håller koll på vad användaren trycker.

            if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {
                    index = 0;
                }
                else { index++; }

            }
            else if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    index = items.Count - 1;
                }
                else { index--; }

            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {

                return index;
            }
            else
            {
                return 0;
            }

            Console.Clear();
            return 9999;



        }

    }

}
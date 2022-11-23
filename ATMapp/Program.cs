using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Atm
{
    public class CardHolder
    {
        public string CardNum { get; set; }
        public int Pin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public CardHolder(string CardNum, int Pin, string FirstName, string LastName, double Balance)
        {
            this.CardNum = CardNum;
            this.Pin = Pin;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Balance = Balance;
        }
        public void SetNum(string newCardNum)
        {
            CardNum = newCardNum;
        }
        public void SetPin(int newPin)
        {
            Pin = newPin;
        }
        public void SetFirstName(string newFirstName)
        {
            FirstName = newFirstName;
        }
        public void SetLastName(string newLastName)
        {
            LastName = newLastName;
        }
        public void SetBalance(double newBalance)
        {
            Balance = newBalance;
        }
        static void Main(string[] args)
        {

            void PrintOptions()
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1. Transfer\n");
                Console.WriteLine("2. Withdraw\n");
                Console.WriteLine("3. Show Balance\n");
                Console.WriteLine("4. Exit\n");
            }
            void Transfer(CardHolder currentUser)
            {
                Console.WriteLine("How much $ would you like to transfer: ");
                double Trans = Double.Parse(Console.ReadLine());
                Console.WriteLine("Please choose Account number: ");
                string AccName = (Console.ReadLine());
                Console.WriteLine("Please choose Bank: ");
                string Bank = (Console.ReadLine());
                
                if (currentUser.Balance < Trans)
                {
                    Console.WriteLine("Insufficient balance :(");
                }
                else if (Trans <= 0)
                {
                    Console.WriteLine("Transfer amount cannot be negative");

                }
                else
                {
                    currentUser.SetBalance(currentUser.Balance - Trans);
                    Console.WriteLine("\n\n Transfer successful");
                    Console.WriteLine($"Thank you for $.Your new balance is:{currentUser.Balance}");
                }
            }

            void Withdraw(CardHolder currentUser)
            {
                Console.WriteLine("How much would you like to withdraw: ");
                double Withdrawal = Double.Parse(Console.ReadLine());
                if (currentUser.Balance < Withdrawal)
                {
                    Console.WriteLine("Insufficient balance :(");
                }
                else if (Withdrawal <= 0)
                {
                    Console.WriteLine("Withdraw amount cant be negative");

                }
                else
                {
                    currentUser.SetBalance(currentUser.Balance - Withdrawal);
                    Console.WriteLine("\n\n PLEASE COLLECT YOUR CASH");
                    Console.WriteLine("\n CURRENT BALANCE IS N : {0}", currentUser.Balance);
                }
            }
            void Balance(CardHolder currentUser)
            {
                Console.WriteLine($"Current balance: {currentUser.Balance}");
            }
            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder("1234", 1111, "Chizoba", "Egbujie", 100.20));
            cardHolders.Add(new CardHolder("5678", 2222, "Ifunanya", "Egbujie", 200.30));
            cardHolders.Add(new CardHolder("9101", 3333, "Odinaka", "Egbujie", 300.40));
            cardHolders.Add(new CardHolder("1121", 4444, "Chikwado", "Egbujie", 400.50));
            cardHolders.Add(new CardHolder("3141", 5555, "Uche", "Egbujie", 500.60));
            cardHolders.Add(new CardHolder("5161", 7777, "Amuche", "Egbujie", 600.70));
            Console.Clear();
            Console.Title = "My Multilingual ATM APP";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n---------------------Welcome to GTBank--------------------\n\n");
            Console.WriteLine("Please insert your ATM card: ");
            Console.WriteLine("Note:We dont accept an actual ATM Card,read the card number");
            Console.WriteLine("\n\nPress Enter to Continue...\n");
            Console.ReadLine();
            string DebitCardNum = "";
            CardHolder currentUser;
            while (true)
            {
                try
                {
                    DebitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.CardNum == DebitCardNum);
                    if (currentUser != null) { break; }
                    else
                    {
                        Console.WriteLine("Card not recognized.Please try again");
                    }
                }
                catch { Console.WriteLine("Card not recognized.Please try again"); }
            }
            Console.WriteLine("Please enter your pin: ");

            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    Console.WriteLine("Checking Card Number and Pin..: ");
                    int timer = 10;
                    for (int i = 0; i < timer; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(200);
                    }
                    Console.Clear();
                    if (userPin.ToString().Length != 4)
                    {
                        Console.WriteLine("your pin must be four digits.Please try again");
                    }
                    else if (currentUser.Pin == userPin) { break; }
                    else
                    {
                        Console.WriteLine("Incorrect pin.Please try again");
                    }
                }
                catch { Console.WriteLine("Incorrect pin.Please try again"); }
            }
            Console.WriteLine($"Welcome {currentUser.FirstName} :)");
            int option = 0;
            do
            {
                PrintOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { Transfer(currentUser); }
                else if (option == 2) { Withdraw(currentUser); }
                else if (option == 3) { Balance(currentUser); }
                else if (option == 4) { break; } else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("\n\nThank you! for banking with us :)");
        }
    }
}

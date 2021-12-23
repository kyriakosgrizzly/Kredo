using System;
using ruletka;
class TestClass
{
    static public Random random = new Random();
    static void Main(string[] args)
    {
        Account User = new Account();
        Roullete roullete = new Roullete();
        //Label
        Type:
        Console.WriteLine($"Current Balance {User.Balance}");
        Console.WriteLine("choose type of bet Color or Number,by writing C or N");
        string? BetType = Console.ReadLine();
        if(!(BetType == "C" || BetType == "N"))
        {
            goto Type;
        }
        Console.WriteLine("Choose bet amount");
        //Label
        Bet:
        bool success = double.TryParse(Console.ReadLine(), out double bet);
        if (!success)
        {
            Console.WriteLine("Wrong input");
            goto Bet;
        }
        if(!(bet < User.Balance))
        {
            Console.WriteLine("Not enough balance");
            goto Bet;

        }
        if (!(bet <= 60))
        {
            Console.WriteLine("Max bet is 60");
            goto Bet;

        }
        // assign user bet
        User.Bet = bet;
        if (BetType == "C")
        {
            User.Type = true;
            Console.WriteLine("Enter Color: R or B");
            //Label
            Color:

            string? color = Console.ReadLine();
            if (!(color == "R" || color == "B"))
            {
                Console.WriteLine("wrong input");
                goto Color;
            }
            roullete.SpinTheWheel();
            User.AfterBet(roullete.CheckForWin(color, User.Type));
        }
        else if (BetType == "N")
        {
            User.Type = false;           
            Console.WriteLine("Enter number:");
            //Label
            Number:
            success = int.TryParse(Console.ReadLine(), out int BetNumber);
            if (!success)
            {
                Console.WriteLine("wrong input");
                goto Number;        
            }
            roullete.SpinTheWheel();
            User.AfterBet(roullete.CheckForWin(BetNumber.ToString(), User.Type));
        }

         
    
    goto Type;           
    }
}
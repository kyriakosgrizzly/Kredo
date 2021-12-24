using System;
using ruletka;
using System.Collections.Generic;
class TestClass
{
    static public Random random = new Random();
    static void Main(string[] args)
    {
        
        var Users = new List<Account>();
        Console.WriteLine("How many players");
        int PlayerCount;
        while (!int.TryParse(Console.ReadLine(),out PlayerCount))
        {
            Console.WriteLine("wrong input");
        }
        Console.WriteLine("enter names");
        for(int i = 0;i < PlayerCount; i++)
        {
            Users.Add(new Account());
            Users[i].Name = Console.ReadLine();
        }
        Roullete roullete = new Roullete();


    //Label
    start:
        for (int i = 0; i < PlayerCount; i++)
        {
            Input(Users[i]);
        }
        roullete.SpinTheWheel();
        foreach(Account user in Users)
        {
            user.AfterBet(roullete.CheckForWin(user.Choice, user.Type));
            Console.WriteLine(user.Balance);
        }
        roullete.WinningNumCol();
       

    //Label
    ExitOrContinue:
    Console.WriteLine("Do you wish to continue the game? answer by typing Y or N");
    string finish = Console.ReadLine();
    if (finish == "Y")
    {
        goto start;
    }
    else if(finish == "N")
    {
            
    }
    else
    {
        goto ExitOrContinue;
    }
          
    }
    static public void Input(object user)
    {
        Account User = user as Account;
    Type:
        Console.WriteLine($"{User.Name} Current Balance {User.Balance}");
        Console.WriteLine("choose type of bet Color or Number,by writing C or N");
        string? BetType = Console.ReadLine();
        if (!(BetType == "C" || BetType == "N"))
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
        if (!(bet < User.Balance))
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
            else
            {
                User.Choice = color;
            }
            
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
            else if(BetNumber > 36 || BetNumber < 0)
            {
                Console.WriteLine("Out of bound");
                goto Number;
            }
            else {
                User.Choice = BetNumber.ToString();
            }
            
        }
    }
}
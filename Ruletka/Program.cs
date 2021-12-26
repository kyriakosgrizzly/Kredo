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


        //start the game
        bool start = true;
        while (start)
        {
            for (int i = 0; i < PlayerCount; i++)
            {
                Input(Users[i]);
            }
            roullete.SpinTheWheel();
            foreach (Account user in Users)
            {
                user.AfterBet(roullete.CheckForWin(user.Choice, user.Type));
                Console.WriteLine(user.Balance);
            }
            roullete.WinningNumCol();


            //check for exit
            while (true)
            {
                Console.WriteLine("Do you wish to continue the game? answer by typing Y or N");
                string finish = Console.ReadLine();
                if (finish == "Y")
                {
                    break;
                }
                else if (finish == "N")
                {
                    start = false;
                    break;
                }
            }
        }
          
    }
    static void Input(object user)
    {
        Account User = user as Account;
        string BetType = "";
        Console.WriteLine($"{User.Name} Current Balance {User.Balance}");
        while (!(BetType == "C" || BetType == "N"))
        {
            Console.WriteLine("choose type of bet Color or Number,by writing C or N");
            BetType = Console.ReadLine();
        }
        Console.WriteLine("Choose bet amount");
        //Label
        double bet;
        bool success;
        while (true)
        {
            success = double.TryParse(Console.ReadLine(), out bet);
            if (!success)
            {
                Console.WriteLine("Wrong input");
            }
            else if (!(bet < User.Balance))
            {
                Console.WriteLine("Not enough balance");
            }
            else if (!(bet <= 60))
            {
                Console.WriteLine("Max bet is 60");
            }
            else
            {
                break;
            }
        }
       
        // assign user bet
        User.Bet = bet;
        if (BetType == "C")
        {
            User.Type = true;
            Console.WriteLine("Enter Color: R or B");
            string? color = "";
            while (!(color == "R" || color == "B")){
                color = Console.ReadLine();
            }
            User.Choice = color;

        }
        else if (BetType == "N")
        {
            User.Type = false;
            Console.WriteLine("Enter number:");

            while (true)
            {
                success = int.TryParse(Console.ReadLine(), out int BetNumber);
                if (!success)
                {
                    Console.WriteLine("wrong input");
                }
                else if(BetNumber > 36 || BetNumber < 0)
                {
                    Console.WriteLine("Out of bound");
                }
                else
                {
                    User.Choice = BetNumber.ToString();
                    break;
                }
            }
            
        }
    }
}
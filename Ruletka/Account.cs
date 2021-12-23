using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruletka
{
    public class Account
    {
        public Double Balance { get; set; }
        public Double Bet { get; set; }
        public bool Type { get; set; }
        public Account()
        {
            Balance = 1000;
        }

        public void AfterBet(bool win)
        {
            if (win)
            {
                if (Type)
                {
                    Balance += Bet / 5;
                }
                else Balance += Bet;
            }
            else Balance -= Bet;
        }
    }
}
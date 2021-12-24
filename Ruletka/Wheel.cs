using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruletka
{
    
    public class Roullete
    {
        static public Random rand = new Random();

        public int WinNum { get; set; }
        
        public string WinCol { get; set; }

        public void SpinTheWheel()
        {
            WinNum = rand.Next(0, 36);
        }
        public bool CheckForWin(string bet, bool type)
        {
            if (type)
            {
                return CheckForColor(bet, WinNum);
            }
            else
            {
                return CheckForColor(bet, WinNum);
            }

        }
        public bool CheckForColor(string bet, int num)
        {
            string win;
            if ((num <= 10 && num >= 1) || (num >= 19 && num <= 28))
            {

                //red
                if (num % 2 == 1)
                {
                    win = "R";
                }
                // Black
                else
                {
                    win = "B";
                }
            }
            else
            {
                if (num % 2 == 1)
                {
                    win = "B";
                }
                // Black
                else
                {
                    win = "R";
                }
            }
            if (num == 0) win = "G";
            WinCol = win;
            if (win == bet) return true;
            return false;
        }
        public void WinningNumCol()
        {
            Console.WriteLine($"Winning number is {WinNum} and Color {WinCol}");
        }
        public bool CheckForNumber(int number, int RandNum)
        {
            if (number == RandNum) return true;
            else return false;

        }
    }
}
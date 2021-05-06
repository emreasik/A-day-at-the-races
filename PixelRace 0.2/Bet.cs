using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelRace_0._2
{
    class Bet  //Bahislerin yapıldığı, güncellendiği class
    {
        public int Amount;
        public int Racer;
        public Betters Bettor;

        public Bet(int Amount, int Racer, Betters Bettor)
        {
            this.Amount = Amount;
            this.Racer = Racer;
            this.Bettor = Bettor;
        }

        public string GetDescription() //Yapılan bahisi string olarak return eder.
        {
            string description = "";

            if (Amount > 0)
            {
                description = String.Format("{0} bets {1} on skeleton #{2}", Bettor.Name, Amount, Racer);
            }
            else
            {
                description = String.Format("{0} hasn't placed any bets", Bettor.Name);
            }
            return description; 
        }

        public int PayOut(int Winner) //Kazancı + veya - olarak döndürür.
        {
            if (Racer == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}

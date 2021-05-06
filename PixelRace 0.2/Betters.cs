using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelRace_0._2
{
    class Betters
    {
        public string Name;
        public Bet MyBet;
        public int Cash; //Parayı tutar

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public Betters(string Name, Bet MyBet, int Cash, RadioButton MyRadioButton, Label MyLabel)
        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.Cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyLabel = MyLabel;
        }

        public void UpdateLabels()  //Bahis yapıldığında Label'ları günceller.
        {
            if (MyBet == null)
            {
                MyLabel.Text = String.Format("{0} hasn't placed any bets", Name);
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription(); //Metottan gelen bahis değerleri form ekranında güncellenir.
            }

            MyRadioButton.Text = Name + " has " + Cash + " bucks";
        }

        public void ClearBet() 
        {
            MyBet.Amount = 0;
        }

        public bool PlaceBet(int Amount, int Racer)
        {
            if (Amount <= Cash) //bahis paramızdan büyük olamaz
            {
                MyBet = new Bet(Amount, Racer, this);
                return true;
            }
            return false;
        }

        public void Collect(int Winner) //Bahis sonucunu oluşan bakiyeyi düzenler.
        {
            Cash += MyBet.PayOut(Winner);
        }
    }
}

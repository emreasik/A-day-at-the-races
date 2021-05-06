using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PixelRace_0._2
{
    class Skeleton
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox;
        public int Location = 0;
        public Random Randomizer = new Random();

        public bool Run()
        {
            int distance = Randomizer.Next(1, 5);

            MoveMyPictureBox(distance);

            Location += distance;
            if (Location >= (RacetrackLength-StartingPosition)) //Yarışın bitmesi kontrol ediliyor. Form içerisinde while döngüsü sonlanmasını sağlar.
                {
                return true;
            }
            return false;

        }

        public void TakeStartingPosition() //Konumu resetler
        {
            MoveMyPictureBox(-Location);
            Location = 0;
        }

        public void MoveMyPictureBox(int distance)
        {
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
        }

        public int LiveRacer() //Canlı yarış için gereken x konumunu yollar.
        {
            Point x = MyPictureBox.Location;
            return x.X;
        }

    }
}

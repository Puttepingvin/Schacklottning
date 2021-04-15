using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schacklottning
{

    class Match
    {

        public Player white;
        public Player black;
        private int result;
        public int Result
        {
            get { return result; }
            set
            {
                result = value;
                double ew = 1 / (1 + Math.Pow(10, (black.elo - white.elo) / 400));
                double eb = 1 / (1 + Math.Pow(10, (white.elo - black.elo) / 400));
                double scorewhite;
                double scoreblack;
                if (result == 1)
                {
                    scorewhite = 1;
                    scoreblack = 0;
                }
                else if(result == 2)
                {
                    scoreblack = 1;
                    scorewhite = 0;
                }
                else if(result == 3)
                {
                    scorewhite = 0.5;
                    scoreblack = 0.5;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                white.score += scorewhite;
                black.score += scoreblack;
                white.elo += 32 * (scorewhite - ew);
                black.elo += 32 * (scoreblack - eb);
            }
        }
        public DateTime timePlayed;

        public Match(Player white, Player black)
        {
            this.white = white;
            this.black = black;
            this.result = -1;
            this.timePlayed = DateTime.Now;
        }

    }
}

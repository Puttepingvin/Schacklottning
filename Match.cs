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
        public int round;
        private double elodiffw = 0.0f;
        private double elodiffb = 0.0f;
        private int result;
        public int Result
        {
            get { return result; }
            set
            {
                //Check if we alrdy updated score and elo
                if (result != -1)
                {
                    if(result == value)
                    {
                        return;
                    }
                    //Revert prev changes
                    white.score -= ScoreForPlayer(white);
                    black.score -= ScoreForPlayer(black);
                    white.elo -= elodiffw;
                    black.elo -= elodiffb;


                }
                //Update score and elo
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
                else if (result == 2)
                {
                    scoreblack = 1;
                    scorewhite = 0;
                }
                else if (result == 3)
                {
                    scorewhite = 0.5;
                    scoreblack = 0.5;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                //Scoreforplayer is used to remap from [0,1,0.5] to whatever is in the settings
                white.score += ScoreForPlayer(white);
                black.score += ScoreForPlayer(black);
                elodiffw = 32 * (scorewhite - ew);
                elodiffb = 32 * (scoreblack - eb);
                white.elo += elodiffw;
                black.elo += elodiffb;
            }
        }
        public DateTime timePlayed;

        public Match(Player white, Player black, int round)
        {
            this.white = white;
            this.black = black;
            this.round = round;
            this.result = -1;
            this.timePlayed = DateTime.Now;
        }

        public double ScoreForPlayer(Player p)
        {
            float pscore = -1;
            switch (result)
            {
                case 1:
                    if (p.ID == white.ID) pscore = Properties.Settings.Default.scoreWin;
                    if (p.ID == black.ID) pscore = Properties.Settings.Default.scoreLoss;
                    break;
                case 2:
                    if (p.ID == white.ID) pscore = Properties.Settings.Default.scoreLoss;
                    if (p.ID == black.ID) pscore = Properties.Settings.Default.scoreWin;
                    break;
                case 3:
                    if (p.ID == white.ID || p.ID == black.ID) pscore = Properties.Settings.Default.scoreDraw;
                    break;
                default:
                    break;

            }
            return pscore;
        }

        public String resToString()
        {
            String output = "";
            if (result == 1)
            {
                output = "1-0";
            }
            else if (result == 2)
            {
                output = "0-1";
            }
            else if (result == 3)
            {
                output = "Remi";
            }
            return output;
        }
    }
}

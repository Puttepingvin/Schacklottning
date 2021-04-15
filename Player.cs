using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schacklottning
{
    class Player : IComparable<Player>
    {
        static int nextId;
        public int ID;
        public String fistname;
        public String lastname;
        public double elo;
        public double score;
        public Boolean active;
        public List<Match> matches;

        public Player(string fistname, string lastname)
        {
            this.fistname = fistname;
            this.lastname = lastname;
            this.elo = 0;
            this.score = 0;
            this.active = true;
            matches = new List<Match>();
            this.ID = nextId++;
            Console.WriteLine(this.ID.ToString());
        }

        public override String ToString()
        {
            return $"{this.fistname} {this.lastname}";
        }
        public int CompareTo(Player other)
        {
            return this.score.CompareTo(other.score);
        }

        public double matchScore(Player other) 
        {
            double diff = this.elo - other.elo;
            return diff*diff;
        }
        public bool isValidMatch(Player other, int tolerance)
        {
            bool found = false;
            for(int i = 1; i <= tolerance; i++)
            {
                if(this.matches.Count >= i && other.matches.Count >= i) { 
                    if(this.matches[this.matches.Count - i].white.ID == other.ID ||
                       this.matches[this.matches.Count - i].black.ID == other.ID ||
                       other.matches[other.matches.Count - i].white.ID == this.ID ||
                       other.matches[other.matches.Count - i].black.ID == this.ID)
                    {
                        found = true;
                        break;
                    }
                }
            }
            return !found;
        } 
    }
}

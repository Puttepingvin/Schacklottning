using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schacklottning
{
    public partial class Form1 : Form
    {
        //These are the autoritative sources on the most current info, ui elements and database should match but these break ties
        private List<Player> playerList;
        private const int StartElo = 1000;
        private List<Match> activeMatches;

        public void AddPlayer(String firstname, String lastname)
        {
            Player player = new Player(firstname, lastname);
            player.elo = StartElo;
            playerList.Add(player);
            lstbPlayers.Items.Add(player);
            
            //Modify database
        }

        public Form1()
        {
            playerList = new List<Player>(); //Load from database
            activeMatches = new List<Match>();
            InitializeComponent();
            AddPlayer("King", "Ghidorah");
            AddPlayer("MF", "DOOM");
            AddPlayer("Mac", "Miller");
            AddPlayer("Ol'Dirty", "Bastard");
            AddPlayer("Nipsey", "Hussle");
            UpdateLists();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addPlayerWindow = new Form2(this);
            addPlayerWindow.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShowRound_Click(object sender, EventArgs e)
        {

        }

        private void btnNewRound_Click(object sender, EventArgs e)
        {
            //TODO: Conform if active matches
            activeMatches = new List<Match>();
            List<Player> activePlayersList = new List<Player>();


            foreach(Player p in playerList)
            {
                if (p.active)
                    activePlayersList.Add(p);
            }


            int numactive = activePlayersList.Count();

            Player[] activePlayers = activePlayersList.ToArray();

            int tolerance = 0;

            double[,] scores = new double[numactive,numactive];
            for(int i = 0; i<numactive; i++)
            {
                for (int j = 0; j < numactive; j++)
                {
                    //Weird order but can improve execution time by a bit maybe
                    if(j <= i)
                    {
                        scores[i, j] = Double.MaxValue;
                    }
                    else if (activePlayers[i].isValidMatch(activePlayers[j], tolerance))
                    {
                        scores[i, j] = activePlayers[i].matchScore(activePlayers[j]);
                    }
                    else
                    {
                        scores[i, j] = Double.MaxValue;
                    }
                }
            }
            bool matched = false;
            //double[,] scores2 = (double[,])scores.Clone();
            List<int> umatchedNums = Enumerable.Range(0, activePlayers.Length).ToList<int>();
            List<Match> draw = createValidMatching(umatchedNums, scores, activePlayers);
            Console.WriteLine("-------------");
            foreach (Match d in draw)
            {
                d.white.matches.Add(d);
                d.black.matches.Add(d);
                Console.WriteLine(d.white.ToString());
                Console.WriteLine(d.black.ToString());
            }

            Form3 addPlayerWindow = new Form3(draw, this);
            addPlayerWindow.Show();




        }

        private List<Match> createValidMatching(List<int> umatchedNums, double[,] scores, Player[] activePlayers)
        {
            //Remember to always add a bye player if odd
            if(umatchedNums.Count < 2)
            {
                return new List<Match>();
            }
            int curr = umatchedNums.First<int>();
            umatchedNums.Remove(curr);
            List<int> possibleMatches = new List<int>(umatchedNums);
            List<Match> output = null;
            bool done = false;
            while(possibleMatches.Count > 0 && !done)
            {
                int bestMatch = -1;
                double bestMatchScore = double.MaxValue;
                foreach (int num in possibleMatches)
                {
                    //curr is always less than num, scores is upper triangular (but 0 is double.max)
                    if(scores[curr,num] < bestMatchScore)
                    {
                        bestMatchScore = scores[curr, num];
                        bestMatch = num;
                    }
                }
                if(bestMatch != -1)
                { 
                    List<int> umatchedNums2 = new List<int>(umatchedNums);
                    umatchedNums2.Remove(bestMatch);

                    output = createValidMatching(umatchedNums2, scores, activePlayers);
                    if(output is null)
                    {
                        possibleMatches.Remove(bestMatch);
                    }
                    else
                    {
                        done = true;
                        var rand = new Random();
                        if(rand.Next()%2 == 0){
                            int t = curr;
                            curr = bestMatch;
                            bestMatch = t;
                        }
                        output.Add(new Match(activePlayers[curr], activePlayers[bestMatch]));
                    }
                }
                else
                {
                    return null;
                }
            }
            return output;
        }

        private void btnMakeActive_Click(object sender, EventArgs e)
        {
            Player player = (Player)lstbInactive.SelectedItem;
            if(player is null)
            {
                MessageBox.Show("No player selected", "No player selected",
                                 MessageBoxButtons.OK);
            }
            else
            {
                player.active = true;
                lstbInactive.Items.Remove(player);
                lstbPlayers.Items.Add(player);
            }
        }

        private void btnMakeInactive_Click(object sender, EventArgs e)
        {
            Player player = (Player)lstbPlayers.SelectedItem;
            if (player is null)
            {
                MessageBox.Show("No player selected", "No player selected",
                                 MessageBoxButtons.OK);
            }
            else
            {
                player.active = false;
                lstbPlayers.Items.Remove(player);
                lstbInactive.Items.Add(player);
            }
        }

        public void UpdateLists()
        {
            playerList.Sort();
            playerList.Reverse();
            lstbResTot.Items.Clear();
            foreach (Player p in playerList)
            {
                lstbResTot.Items.Add($"{p.score}   {p.ToString()}");
            }
        }
    }
}

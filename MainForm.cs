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
    public partial class MainForm : Form
    {
        //These are the authoritative sources on the most current info, ui elements and database should match but these break ties
        private List<Player> playerList;
        private const int StartElo = 1000;
        private List<Match> activeMatches;
        private List<Match> allMatches;
        private int currentRound = 0;

        public void AddPlayer(String firstname, String lastname)
        {
            Player player = new Player(firstname, lastname);
            player.elo = StartElo;
            playerList.Add(player);
            lstbPlayers.Items.Add(player);
            
            //TODO: Modify database
        }

        public MainForm()
        {
            playerList = new List<Player>(); //TODO: Load from database
            activeMatches = new List<Match>();
            allMatches = new List<Match>();
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

        //Add new player button
        private void button1_Click(object sender, EventArgs e)
        {
            AddPlayerForm addPlayerWindow = new AddPlayerForm(this);
            addPlayerWindow.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Show active matches button
        private void btnShowRound_Click(object sender, EventArgs e)
        {
            MatchListForm addPlayerWindow = new MatchListForm(activeMatches, this);
            addPlayerWindow.Show();
        }


        private void btnNewRound_Click(object sender, EventArgs e)
        {
            //Kolla om senaste ronden är avslutad
            bool activeMatch = false;
            foreach(Match m in activeMatches)
            {
                if(m.Result == -1)
                {
                    activeMatch = true;
                }
            }
            if (activeMatch)
            {
                System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Alla resultat är inte inmatade, vill du lotta ny rond ändå?", "Är du säker?", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == System.Windows.MessageBoxResult.No)
                {
                    return;
                }

            }


            //Start new round
            currentRound++;

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

            MatchListForm addPlayerWindow = new MatchListForm(draw, this);
            addPlayerWindow.Show();
            activeMatches = draw;
            allMatches.AddRange(activeMatches);



        }

        //The main matchmaking function, currently very simple.
        private List<Match> createValidMatching(List<int> umatchedNums, double[,] scores, Player[] activePlayers)
        {
            //TODO: Add bye
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
                        output.Add(new Match(activePlayers[curr], activePlayers[bestMatch],currentRound));
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

        //Keeps lists in the UI updated by repopulating them, called after changes to scores, player list etc.
        public void UpdateLists()
        {
            //Update total scores list
            playerList.Sort();
            playerList.Reverse();
            lstbResTot.Items.Clear();
            foreach (Player p in playerList)
            {
                lstbResTot.Items.Add($"{p.score}   {p.ToString()}");
            }

            //Update scores today list
            List<double> scoresToday = new List<double>();
            DateTime today = DateTime.Now.Date;
            lstbResToday.Items.Clear();
            foreach (Player p in playerList)
            {
                double scoreForP = 0;
                foreach (Match m in p.matches)
                {

                    if (DateTime.Equals(m.timePlayed.Date, today))
                    {
                        if (m.Result != -1)
                        {
                            scoreForP += m.ScoreForPlayer(p);
                        }

                    }
                }
                scoresToday.Add(scoreForP);
            }
            for(int i = 0; i < scoresToday.Count; i++)
            {
                lstbResToday.Items.Add($"{scoresToday[i]}  {playerList[i].ToString()}");
            }

        }
    }
}

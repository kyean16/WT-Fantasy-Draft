using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace HelloWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numberOfRounds = 15;

        List<DraftPlayer> playerListOG = new List<DraftPlayer>(); //ArrayList of PLayers
        List<DraftPlayer> playerListTemp = new List<DraftPlayer>();
        Queue<DraftPlayer> draftRoundSchedule = new Queue<DraftPlayer>(); //Queue to be used for turns
        DraftPlayer[] orderArray = new DraftPlayer[8]; // Array hold

        public MainWindow()
        {
            //Initiliaze the playerList Arrray
            for (int i = 1; i < 9; i++)
            {
                //Testing
                DraftPlayer player = new DraftPlayer("Player " + i);
                playerListOG.Add(player);
            }
            InitializeComponent();
        }

        /// <summary>
        /// Method that decides the order of the draft.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimulateDraftOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            String playerDraftOrder = "";
            //Clones the list of Player to a temporary list
            for (int i = 0; i < playerListOG.Count; i++)
            {
                DraftPlayer playerClone = (DraftPlayer)playerListOG[i].Clone(); //Clone Class
                playerListTemp.Add(playerClone);
            }
            int b = 0;
            //Sets the draft order for the draft randomly
            while (playerListTemp.Count > 0)
            {
                int randomNumber = random.Next(0, playerListTemp.Count);
                playerDraftOrder += playerListTemp[randomNumber].getPlayerName() + "\n"; //String
                orderArray[b] = playerListTemp[randomNumber]; //Change to order
                playerListTemp.RemoveAt(randomNumber);
                b++;
            }
            textBoxPlayer.Text = "Draft Order: \n" + playerDraftOrder;
        }

        /// <summary>
        /// Method that generates the DraftRound Schedule in a queue format for easy use.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimulateDraftRounds_Click(object sender, RoutedEventArgs e)
        {
            String draftRounds = "";
            bool order = true; //for Snake order
            for (int i = 0; i < numberOfRounds; i++) //numberOfRounds Rounds
            {
                draftRounds += "--Round " + (i + 1) + "\n";

                if (order)
                {
                    for (int b = 0; b < orderArray.Length; b++)
                    {
                        draftRounds += orderArray[b].getPlayerName() + "\n";
                        draftRoundSchedule.Enqueue(orderArray[b]);
                    }
                    order = false;
                }
                else
                {
                    for (int b = orderArray.Length - 1; b >= 0; b--)
                    {
                        draftRounds += orderArray[b].getPlayerName() + "\n";
                        draftRoundSchedule.Enqueue(orderArray[b]);
                    }
                    order = true;
                }
            }
            textBoxPlayerRounds.Text = draftRounds;
        }

        /// <summary>
        /// Method to simulate the draft turns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimulateDraftTurnsButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxPlayerTurns.Text = "";
            int i = 0;
            int roundNum = 1;
            while (draftRoundSchedule.Count > 0) //While the queue is not empty
            {
                DraftPlayer tempPlayer = draftRoundSchedule.Dequeue();
                if (i == 0)
                {
                    textBoxPlayerTurns.Text += "--Round " + (roundNum) + "\n";
                    roundNum++;
                    i = 8;
                }
                textBoxPlayerTurns.Text += tempPlayer.getPlayerName() + " selected: " + tempPlayer.testDraftAPlayer() + "\n";
                i--;
            }
            displayResult();
            ResetListOfPlayer();
        }

        private void HardResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetListOfPlayer();
            MessageBox.Show("Successfuly Reset Player Roster Database ");
        }

        private void ResetListOfPlayer()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kevin\Desktop\WT-Fantasy-Draft\DatabaseNFL.accdb;Persist Security Info=False;";
            String testString = "";
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                string updateString = "UPDATE NFL2015Roster SET Selected = 'No'";
                OleDbCommand cmd = new OleDbCommand(updateString, connection);
                cmd.ExecuteNonQuery();

                connection.Close(); //Close Connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

       

        private void displayResult()
        {
            textBoxResult.Text = "";
            for(int i = 0; i <orderArray.Length ; i++)
            {
                textBoxResult.Text += "Player " + (i+1) + " (Total Projected Points): " + orderArray[i].getTotalProjectedPoints() + "\n";
            }
        }

        /// <summary>
        /// Method used to save result from the simulation --UNFINISHED
        /// </summary>
        private void SavedDataButton_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kevin\Desktop\WT-Fantasy-Draft\DatabaseNFL.accdb;Persist Security Info=False;";
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                for (int i = 0; i<orderArray.Length; i++)
                {
                    string updateString = "INSERT into SimulationSheet8 (SimulationNumber,Players,FantasyResult) VALUES (1, '" + orderArray[i].getPlayerName() + "', '" + orderArray[i].getTotalProjectedPoints() +"' );";
                    OleDbCommand cmd = new OleDbCommand(updateString, connection);
                    cmd.ExecuteNonQuery();
                }

                connection.Close(); //Close Connection
                MessageBox.Show("Successfuly Saved Result into Database ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}

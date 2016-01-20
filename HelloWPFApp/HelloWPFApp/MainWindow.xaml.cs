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
            Random rnd = new Random();
            //Initiliaze the playerList Arrray
            for (int i = 1; i < 9; i++)
            {
                //Testing
                int randomNumber = rnd.Next(2);
                Console.Write(randomNumber);
                DraftPlayer player = new DraftPlayer("Player " + i ,randomNumber);
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
                playerListTemp[randomNumber].setDraftOrder(b+1); //SetDraftOrderNumber
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
            int roundNum = 0;
            while (draftRoundSchedule.Count > 0) //While the queue is not empty
            {
                DraftPlayer tempPlayer = draftRoundSchedule.Dequeue();
                if (i == 0)
                {
                    roundNum++;
                    textBoxPlayerTurns.Text += "--Round " + (roundNum) + "\n";
                    i = 8;
                }
                textBoxPlayerTurns.Text += tempPlayer.getPlayerName() + " selected: " + tempPlayer.draft(roundNum) + "\n";

                i--;
            }
            DisplayResult();
            ResetListOfPlayer();
        }

        /// <summary>
        /// Hard Reset Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HardResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetListOfPlayer();
            MessageBox.Show("Successfuly Reset Player Roster Database ");
        }

        /// <summary>
        /// Reset all selected to 0
        /// </summary>
        private void ResetListOfPlayer()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kevin\Desktop\WT-Fantasy-Draft\DatabaseNFL.accdb;Persist Security Info=False;";
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                string updateString = "UPDATE NFL2015Roster SET Selected = 'No'";
                OleDbCommand cmd = new OleDbCommand(updateString, connection);
                cmd.ExecuteNonQuery();
                updateString = "UPDATE NFL2015Teams SET Selected = 'No'";
                cmd = new OleDbCommand(updateString, connection);
                cmd.ExecuteNonQuery();

                connection.Close(); //Close Connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        /// <summary>
        /// DisplayResults
        /// </summary>
        private void DisplayResult()
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
            int simNum = 0;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kevin\Desktop\WT-Fantasy-Draft\DatabaseNFL.accdb;Persist Security Info=False;";
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection

                //Receive Simulation Number and increments by one;
                string findSimNumString = "SELECT MAX(SimulationNumber) as simNumber from SimulationSheet8;";
                OleDbCommand command = new OleDbCommand(findSimNumString, connection);
                OleDbDataReader reader =  command.ExecuteReader();
                while (reader.Read())
                {
                    simNum = Convert.ToInt32(reader["SimNumber"].ToString());
                    simNum++;

                    break;
                }

                for (int i = 0; i<orderArray.Length; i++)
                {
                    string updateString = "INSERT into SimulationSheet8 " +
                                          "(SimulationNumber,Players,DraftOrder,Round1,Round2,Round3,Round4,Round5,Round6,Round7,Round8,Round9,Round10,Round11,Round12,Round13,Round14,Round15,Strategy,FantasyResult) " +
                                          "VALUES ('" + simNum + "', "+ 
                                                  "'" + orderArray[i].getPlayerName() + "' ," +
                                                  "'" + orderArray[i].getDraftOrder() + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(0) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(1) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(2) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(3) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(4) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(5) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(6) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(7) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(8) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(9) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(10) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(11) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(12) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(13) + "' ," +
                                                  "'" + orderArray[i].getNFLPlayerRoundName(14) + "' ," +
                                                  "'" + orderArray[i].getStrategyName() + "' ," +
                                                  "'" + orderArray[i].getTotalProjectedPoints() + "' );";
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kevin\Desktop\WT-Fantasy-Draft\DatabaseNFL.accdb;Persist Security Info=False;";
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                Console.Write("Here 1");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes' and a.PositionNFL = 'CAR'" +
                                      "Order by a.FantasyPoints DESC;";
                OleDbCommand command = new OleDbCommand(selectString, connection);
                OleDbDataReader reader = command.ExecuteReader();
                //Loop through the results
                String firstName = "";
                String lastName = "";
                String position = "";
                String team = "";
                Double projectedPoints = 0;

                while (reader.Read())
                {
                    firstName = reader["FirstName"].ToString();
                    lastName = reader["LastName"].ToString();
                    position = reader["Position"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
              

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
                OleDbCommand cmd = new OleDbCommand(updateString, connection);
                cmd.ExecuteNonQuery();

                connection.Close(); //Close Connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}

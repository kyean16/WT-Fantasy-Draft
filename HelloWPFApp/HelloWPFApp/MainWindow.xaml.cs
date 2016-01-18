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
        ArrayList playerListOG = new ArrayList(); //ArrayList of PLayers
        ArrayList playerListTemp = new ArrayList();

        String[] orderArray = new String[8]; // Array hold

        public MainWindow()
        {
            //Initiliaze the playerList Arrray
            for(int i = 1; i < 9; i++)
            {
                playerListOG.Add("Player " + i);
            }
            InitializeComponent();
        }

        /***

  String testString = "";
            try {
                //Database Connection
                //Begins Database Connection
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kevin\Desktop\WT-Fantasy-Draft\DatabaseNFL.accdb;Persist Security Info=False;";
                connection.Open(); //Open the Connection
                //Variable to hold string
                Console.Write("Connection Sucessful \n"); //Success Connection
                //Variable to hold SQL Statement
                string selectString = "Select * From NFL2015FantasyPointProject where (FantasyPoints) IN ( select max(FantasyPoints) from NFL2015FantasyPointProject) ";

                OleDbCommand command = new OleDbCommand(selectString,connection); 
                OleDbDataReader reader = command.ExecuteReader();

                //Loop through the results
                while (reader.Read())
                {
                    testString +=(reader["LastName"].ToString() + " " + reader["FirstName"].ToString() + "\n");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error "  + ex);
            }

    ***/

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            String playerDraftOrder = "";
            for (int i = 0; i < playerListOG.Count; i++)
            {
                Object tempValue = playerListOG[i];
                String tempString = tempValue.ToString();
                playerListTemp.Add(tempString);
            }
            int b = 0;
            while (playerListTemp.Count > 0)
            {
                int randomNumber = random.Next(0, playerListTemp.Count);
                playerDraftOrder += playerListTemp[randomNumber] + "\n";
                orderArray[b] = playerListTemp[randomNumber].ToString(); //Change to order
                playerListTemp.RemoveAt(randomNumber);
                b++;
            }
            textBoxPlayer.Text = "Draft Order: \n" + playerDraftOrder;
        }

        //Show Drafts rounds Number SNAKE FORMAT
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            String draftRounds = "";
            bool order = true; //for Snake order
            for(int i = 0; i < 15; i++) //15 Rounds
            {
                draftRounds += "--Round " + (i + 1) + "\n";

                if (order) { 
                    for(int b = 0; b < orderArray.Length; b++)
                    {
                        draftRounds += orderArray[b] +"\n";
                    }
                order = false;
                 }
                else
                {
                    for (int b = orderArray.Length -1; b >= 0; b--)
                    {
                        draftRounds += orderArray[b] + "\n";
                    }
                    order = true;
                }
            }
            textBoxPlayer.Text = draftRounds;
        }
    }
}

using System;
using System.Data.OleDb;
using System.Windows;

namespace HelloWPFApp
{
    internal class NFLQuery
    {
        private OleDbConnection connection = new OleDbConnection();

        public NFLQuery()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kevin\Desktop\WT-Fantasy-Draft\DatabaseNFL.accdb;Persist Security Info=False;";
        }

        /// <summary>
        /// Test Method to return values for Database
        /// </summary>
        /// <returns></returns>
        public NFLPlayers randomNames()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n"); //Success Connection
                                                          // string selectString = "Select * From NFL2015FantasyPointProject where (FantasyPoints) IN ( select max(FantasyPoints) from NFL2015FantasyPointProject)";
                                                          /*string selectString = "Select a.*" +
                                                                                "From NFL2015FantasyPointProject as a " +
                                                                                "Where(FantasyPoints) IN("+
                                                                                          "Select TOP 1 max(b.FantasyPoints) " +
                                                                                          "From NFL2015FantasyPointProject as b,  NFL2015Roster as c "+
                                                                                          "Where c.FirstName = b.FirstName AND c.LastName = b.LastName AND c.Selected <> 'Yes') "+
                                                                                "Order by a.FantasyPoints;";
                                                                                //"AND b.FirstName = a.FirstName AND b.LastName = a.LastName;";*/
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName +"';";
                OleDbCommand cmd = new OleDbCommand(updateString, connection);
                cmd.ExecuteNonQuery();

                connection.Close(); //Close Connection
                return tempPlayer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
                return null;
            }
        }
    }
}
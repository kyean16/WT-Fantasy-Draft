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
        public NFLPlayers topFantasyPoints()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
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
                    position = reader["PositionNFL"].ToString();
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

        public NFLPlayers draftQB()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                Console.Write("Here 1");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where a.PositionNFL ='QB' AND a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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

        public NFLPlayers draftRB() {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where a.PositionNFL = 'RB' and a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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

        public NFLPlayers draftWR()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where a.PositionNFL = 'WR' and a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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
        public NFLPlayers draftTE()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where a.PositionNFL = 'TE' and a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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
        public NFLPlayers draftK()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where a.PositionNFL = 'K' and a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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
        public NFLPlayers draftFlex()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where (a.PositionNFL = 'WR' OR a.PositionNFL = 'TE' OR a.PositionNFL = 'RB') and a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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
        public NFLPlayers draftWRorRB()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where (a.PositionNFL = 'WR' OR a.PositionNFL = 'RB') and a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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
        public NFLPlayers draftWRorRBorQB()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where (a.PositionNFL = 'QB' OR a.PositionNFL = 'WR' OR a.PositionNFL = 'RB') and a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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
        public NFLPlayers draftWRorRBorQBorTE()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015FantasyPointProject as a, NFL2015Roster as b " +
                                      "Where (a.PositionNFL = 'TE' or a.PositionNFL = 'QB' OR a.PositionNFL = 'WR' OR a.PositionNFL = 'RB') and a.FirstName = b.FirstName AND a.LastName = b.LastName AND b.Selected <>'Yes'" +
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
                    position = reader["PositionNFL"].ToString();
                    team = reader["Team"].ToString();
                    projectedPoints = Convert.ToDouble(reader["FantasyPoints"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Roster set Selected='Yes' where FirstName = '" + firstName + "' and LastName = '" + lastName + "';";
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
        public NFLPlayers draftTeam()
        {
            NFLPlayers tempPlayer;
            try
            {
                //Database Connection
                connection.Open(); //Open the Connection
                Console.Write("Connection Sucessful \n");
                string selectString = "Select top 1 a.* " +
                                      "From NFL2015DefenseRatingProjection as a, NFL2015Teams as b " +
                                      "Where a.TeamName = b.TeamName AND b.Selected <>'Yes'" +
                                      "Order by a.PTS DESC;";
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
                    firstName = reader["TeamName"].ToString();
                    lastName = "";
                    position = "D";
                    team = "";
                    projectedPoints = Convert.ToDouble(reader["PTS"].ToString());
                    break;
                }
                tempPlayer = new NFLPlayers(firstName, lastName, position, team, projectedPoints);

                //Update value in Roster so it is not selected again
                string updateString = "UPDATE NFL2015Teams set Selected='Yes' where TeamName = '" + firstName + "';";
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
using System;
using System.Collections.Generic;

namespace HelloWPFApp
{
    internal class DraftPlayer : ICloneable
    {


        private NFLQuery queries;
        private String playerName;
        private int draftOrder;
        private int strategy;

        private List<NFLPlayers> drafteeList = new List<NFLPlayers>();
      
        int playerQBs; //1
        int playerRBs; //2
        int playerWRs; //2
        int playerTEs; //2
        int playerKs;  //1
        int playerFlex; //1
        int defenses;  //1


        public DraftPlayer(string newPlayerName,int newStrategy)
        {
            setPlayerName(newPlayerName);
            queries = new NFLQuery();
            playerQBs = 0;
            playerRBs = 0;
            playerWRs = 0;
            playerTEs = 0;
            playerFlex = 0;
            defenses = 0;
            strategy = newStrategy;
        }

        public string getNFLPlayerRoundName(int roundNum)
        {
            return drafteeList[roundNum].getFullNameAndPosition();
        }

        /// <summary>
        /// Sets the player name
        /// </summary>
        /// <param name="newPlayerName"></param>
        public void setPlayerName(string newPlayerName)
        {
            playerName = newPlayerName;
        }

        /// <summary>
        /// //Return player name
        /// </summary>
        /// <returns></returns>
        public string getPlayerName()
        {
            return playerName;
        }

        public string getStrategyName()
        {
            if(strategy == 0)
            {
                return "HighestPointPossible";
            }
            else if (strategy == 1)
            {
                return "NFLStrategy";
            }
           
            return "";
        }

        public int getDraftOrder()
        {
            return draftOrder;
        }

        public void setDraftOrder(int newDraftOrder)
        {
            draftOrder = newDraftOrder;
        }

        public string draft(int roundNum)
        {
            if (strategy == 0)
            {
                return draftStrategyHighestPoints();
            }
            else if (strategy == 1)
            {
                return draftStrategyNFL(roundNum);
            }
            return "";
        }

        public string draftStrategyNFL(int roundNum)
        {
            if(roundNum == 1)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftRB();
                playerRBs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 2)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWR();
                playerWRs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 3)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRB();
                if(tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else
                    playerRBs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 4)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRB();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else
                    playerRBs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 5)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRB();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else
                    playerRBs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 6)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRB();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else
                    playerRBs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
           }
            else if (roundNum == 7)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftFlex();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else if (tempNFLPLayerDrafted.getPosition() == "RB")
                    playerRBs++;
                else
                    playerTEs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 8)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRBorQB();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else if (tempNFLPLayerDrafted.getPosition() == "RB")
                    playerRBs++;
                else
                    playerQBs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 9)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRBorQB();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else if (tempNFLPLayerDrafted.getPosition() == "RB")
                    playerRBs++;
                else
                    playerQBs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 10)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRBorQBorTE();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else if (tempNFLPLayerDrafted.getPosition() == "RB")
                    playerRBs++;
                else if (tempNFLPLayerDrafted.getPosition() == "QB")
                    playerQBs++;
                else
                    playerTEs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 11)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRBorQBorTE();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else if (tempNFLPLayerDrafted.getPosition() == "RB")
                    playerRBs++;
                else if (tempNFLPLayerDrafted.getPosition() == "QB")
                    playerQBs++;
                else
                    playerTEs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 12)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWRorRBorQBorTE();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else if (tempNFLPLayerDrafted.getPosition() == "RB")
                    playerRBs++;
                else if (tempNFLPLayerDrafted.getPosition() == "QB")
                    playerQBs++;
                else
                    playerTEs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 13)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftFlex();
                if (tempNFLPLayerDrafted.getPosition() == "WR")
                    playerWRs++;
                else if (tempNFLPLayerDrafted.getPosition() == "RB")
                    playerRBs++;
                else
                    playerTEs++;
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (roundNum == 14)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftK();
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
            else
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftTeam();
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
        }

        /// <summary>
        /// Return a random number that is then converted to a String
        /// </summary>
        /// <returns></returns>
        public string draftStrategyHighestPoints()
        {
            if (playerQBs < 1)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftQB();
                drafteeList.Add(tempNFLPLayerDrafted);
                playerQBs++;
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (playerRBs < 2)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftRB();
                drafteeList.Add(tempNFLPLayerDrafted);
                playerRBs++;
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (playerWRs < 2)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftWR();
                drafteeList.Add(tempNFLPLayerDrafted);
                playerWRs++;
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (playerTEs < 2)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftTE();
                drafteeList.Add(tempNFLPLayerDrafted);
                playerTEs++;
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (playerFlex < 1)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftFlex();
                drafteeList.Add(tempNFLPLayerDrafted);
                playerFlex++;
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (playerKs < 1)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftK();
                drafteeList.Add(tempNFLPLayerDrafted);
                playerKs++;
                return tempNFLPLayerDrafted.getFullName();
            }
            else if (defenses < 1)
            {
                NFLPlayers tempNFLPLayerDrafted = queries.draftTeam();
                drafteeList.Add(tempNFLPLayerDrafted);
                defenses++;
                return tempNFLPLayerDrafted.getFullName();
            }
            else
            {
                NFLPlayers tempNFLPLayerDrafted = queries.topFantasyPoints();
                drafteeList.Add(tempNFLPLayerDrafted);
                return tempNFLPLayerDrafted.getFullName();
            }
        }

        public double getTotalProjectedPoints()
        {
            double totalProjectedPoints = 0;
            for(int i = 0; i < drafteeList.Count; i++)
            {
                totalProjectedPoints += drafteeList[i].getProjectedPoints();
            }
            return totalProjectedPoints;
        }

        /// <summary>
        /// Clones the Class
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
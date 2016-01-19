using System;
using System.Collections.Generic;

namespace HelloWPFApp
{
    internal class DraftPlayer : ICloneable
    {


        private NFLQuery queries = new NFLQuery();
        private String playerName;

        private List<NFLPlayers> drafteeList = new List<NFLPlayers>();


        public DraftPlayer(string newPlayerName)
        {
            setPlayerName(newPlayerName);
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

        /// <summary>
        /// Return a random number that is then converted to a String
        /// </summary>
        /// <returns></returns>
        public string testDraftAPlayer()
        {
            NFLPlayers tempNFLPLayerDrafted = queries.randomNames();
            drafteeList.Add(tempNFLPLayerDrafted);
            return tempNFLPLayerDrafted.getFullName();
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
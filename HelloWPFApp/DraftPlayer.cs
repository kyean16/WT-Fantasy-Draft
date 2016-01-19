using System;

public class DraftPlayer
{
    private String playerName;

	public DraftPlayer(string newPlayerName)
	{
        setPlayerName(newPlayerName);
	}

    //Sets the player name
    public void setPlayerName(string newPlayerName)
    {
        playerName = newPlayerName;
    }

    //Return player name
    public string getPlayerName()
    {
        return playerName;
    }

}

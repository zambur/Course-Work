/****************************************************************
 * HumanPlayer.java
 * Do not modify this file!
 * This file is for humanPlayer.
 * -----------------------------------------------------------------------------------------------------------------
 * Licensing Information: You are free to use or extend these projects for educational purposes provided that
 * (1) you do not distribute or publish solutions, (2) you retain the notice, and (3) you provide clear attribution to UW-Madison
 * 
 * Attribute Information: The Mancala Game was developed at UW-Madison.
 * 
 * The initial project was developed by Chuck Dyer(dyer@cs.wisc.edu) and his TAs.
 * 
 * Current Version with GUI was developed by Fengan Li(fengan@cs.wisc.edu).
 * Some GUI componets are from Mancala Project in Google code.
 */

import java.io.*;

public class HumanPlayer extends Player 
{
	public static final int SLEEP_TIME = 20;
	public static int choice = -1;
    public void move(GameState context)
    {
    	//reset the choice from board
    	choice = -1;
    	//select the first legal move to be safe 
    	for (int i=0; i<6; i++) 
    	{
    		if (!context.illegalMove(i)) 
    		{
    			move = i;
    			break;
    		}
    	}
    
    	//try to get the choice from GUI
    	while (choice == -1)
    	{
    		Utility.tSleep(SLEEP_TIME);
    	}
    	//transform from the index of the bins to the choice
    	if (choice < 6)
    		move = choice;
    	else
    		move = choice - 6;
    	choice = -1;
    }
}

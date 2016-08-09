/****************************************************************
 * Mancala.java
 * Do not modify this file!
 * This file has the main method. You can adjust some parameters like TIME_LIMIT, NUM_STONES here.
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

public class Mancala 
{

    /** time limit each player has to decide on a move (default: 10 secs) **/
    public static final int TIME_LIMIT  = 5;

    /** number of stones with which to initialize bins (default: 4) **/
    public static final int NUM_STONES = 4;
    
    /** pausing time when moving stones among pots **/
    public static final int SLEEP_TIME = 400;

    /**this is the gui for the game **/
    public static GUI gui;
    public static void main(String[] args) throws Exception 
    {
    	String player1 = null, player2;

    	switch (args.length) 
    	{
    		case 1: player2 = args[0];
	    		player1 = new String("HumanPlayer");
	    		break;
    		case 2: player1 = args[0];
	    		player2 = args[1];
	    		break;
    		case 0:
    		default: 
    			player1 = new String("HumanPlayer");
    			player2 = new String("HumanPlayer");
    			break;
    	}
    	
    	//set up the gui
    	gui = new GUI(player1, player2);
    	
    	Match match = new Match(player1, player2, TIME_LIMIT, NUM_STONES);
    	

    	match.loadPlayers();
    	
    	/**Set up the gui**/
    	
    	
    	int winner = match.play();

    	switch (winner) 
    	{
    	case 1: 
    		if (match.getPlayer1Score() == -1) 
    		{
    			Mancala.gui.textArea.append(player1+":1 has won the match by default\n");
    		}
    		else 
    		{
    			Mancala.gui.textArea.append(player1+":1 has won the match " +
    					   match.getPlayer1Score() + " to " +
    					   match.getPlayer2Score() + "\n");
    		}
    		break;
    	case 2: 
    		if (match.getPlayer2Score() == -1) {
    			Mancala.gui.textArea.append(player2+":2 has won the match by default\n" );
    		}
    		else 
    		{
    			Mancala.gui.textArea.append(player2+":2 has won the match " +
    					   match.getPlayer2Score() + " to " +
    					   match.getPlayer1Score() + "\n");
    		}
	    break;
    	case 0:
    		Mancala.gui.textArea.append(player1+":1 and "+player2+":2 tie at " +
 			       match.getPlayer1Score() + " each.\n");
    	}

    	return;
    }
}

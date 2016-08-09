/****************************************************************
 * Player.java
 * Do not modify this file!
 * This is the abstract class. You need to extend this class to implement your own xxxPlayer.java. You are recommended
 * to read and understand this file.
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

public abstract class Player {
    protected int move;  //stores the current best move for the player
    private String screenName;
    private int whichPlayer;
    
    Player() {
	move = 0;
	screenName = new String("");
	whichPlayer = 1;
    }

    /**
     * Callback method to tell the player that it is its turn to move.
     * It can always assume that the player will have at least one valid move.
     *
     * @param context the current position in the game
     *
     * @return the index of the bin to move from.
     */
    public abstract void move(GameState context);

    /**
     * Initializes the internal state of the player.
     *
     * @param screenName the name of the player that will appear on the game display
     * @param whichPlayer either 1 or 2 to indicate if the player is the one who goes first. 
     * If other than 1 or 2 it defaults to 1
     */

    public void initialize(String screenName, int whichPlayer) {
	this.screenName = screenName;
	if (whichPlayer > 2 || whichPlayer < 1) {
	    this.whichPlayer = 1;
	}
	else {
	    this.whichPlayer = whichPlayer;
	}
    }

    /**
     * Retrieves a display name for the player.
     *
     * @return a readable name for this player
     */
    public String getDisplayName() {
	return screenName;
    }

    /**
     * @returns the latest move chosen by the player after the latest search. 
     * The move must be a valid one according to the latest GameContext sent to the player.
     */
    public int getMove() {
	return move;
    }
}

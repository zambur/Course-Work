/****************************************************************
 * Match.java
 * Do not modify this file!
 * This file actually plays the game.
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

public class Match {
    public String player1ClassName, player2ClassName;
    private Player player1, player2;
    private GameState gameContext;
    private int thinkTime;
    private int numStones;
    private int player1score, player2score;
    public static boolean player1Move;

    /**
     * Creates a new match object.
     * Both player classes should extend the abstract Player class.
     * The classes should be on the classpath at run time
     *
     * @param player1 the name of the class representing player1
     * @param player2 the name of the class representing player2
     * @param numStones the initial number of stones in each bin, must be >= 1
     * @param thinkTime the maximum allowable think time per move in seconds.
     *
     * @throws ClassNotFoundException
     */

    Match(String player1, String player2, int thinkTime, int numStones) throws Exception {
	this.player1ClassName = player1;
	this.player2ClassName = player2;
	this.numStones = numStones;
	this.thinkTime = thinkTime;
	player1score = player2score = -1;

	if (numStones < 1) {
	    throw new Exception("Number of stones can't be zero or negative.");
	}

	gameContext = new GameState(numStones);
    }
    
    /**
     * Loads the classes corresponding to the players
     */
    public void loadPlayers() throws Exception
    {
    	player1 = (Player)Class.forName(player1ClassName).newInstance();
    	player2 = (Player)Class.forName(player2ClassName).newInstance();
    }

    /**
     * Executes the actual match playing. Starts with player 1 then alternates
     * until the game ends.
     * <p>
     * Each move is timed with thinkTime. A player is allowed to run searchMove()
     * for this amount of time. After which, the move is acquired using the 
     * getMove() method.
     *
     * @returns the number corresponding to the winning player; either 1 or 2.
     * returns 0 in case of a tie.
     */
    public int play() {
	player1Move = false;
	Player currentMover = player2;
	boolean playAgain = false;

	while (!gameContext.gameOver()) {

	    System.out.println();

	    if (!playAgain) {
		player1Move = !player1Move;
		gameContext.rotate();
	    }
	    else 
	    {
	    	Mancala.gui.textArea.append("** Player moves again! **\n");
	    	//System.out.println("** Player moves again! **");
	    }

	    if (player1Move) 
	    {
	    	currentMover = player1;
	    	Mancala.gui.textArea.append("PLAYER 1 TO MOVE:\n");
	    	//System.out.println("PLAYER 1 TO MOVE:");
	    }
	    else 
	    {
	    	currentMover = player2;
	    	Mancala.gui.textArea.append("PLAYER 2 TO MOVE:\n");
	    	//System.out.println("PLAYER 2 TO MOVE:");
	    }

	    Object mutex = new Object();
	    long timeout = thinkTime*1000;

	    try {
		synchronized (mutex) {
		    MovingThread movingThread = new MovingThread(currentMover, new GameState(gameContext), mutex, timeout);
		    movingThread.start();  //schedule the moving thread
		    mutex.wait(timeout);  //go to sleep for the timeout or until the move returns
		    
		    Thread.sleep(500);  //sleep for half a second to allow for cleanup
		    if (movingThread.isAlive()) {
			movingThread.stop();  //kill the moving thread if it is still going
			Mancala.gui.textArea.append("Thread timeout expired\n");
			//System.out.println("Thread timeout expired");
		    }		    
		}
	    }
	    catch (Exception e) {
		e.printStackTrace();  //nasty, we shouldn't get here
	    }

	    int move = currentMover.getMove();
	    if (gameContext.illegalMove(move)) { //the player chose an illegal move, lose immediately
		if (currentMover == player1) {
			Mancala.gui.textArea.append("Player 1 made an illegal move.\n");
		    //System.out.println("Player 1 made an illegal move.");
		    return 2;
		}
		else {
			Mancala.gui.textArea.append("Player 2 made an illegal move.\n");
		    //System.out.println("Player 2 made an illegal move.");
		    return 1;
		}
	    }
	    Mancala.gui.applyMove(move, player1Move, new GameState(gameContext)); //update the GUI
	    playAgain = gameContext.applyMove(move);  //effect the move on the board
	}

	int status = gameContext.status();

	if (currentMover == player1) {
	    player1score = gameContext.stoneCount(6);
	    player2score = gameContext.stoneCount(13);
	}
	else {
	    player1score = gameContext.stoneCount(13);
	    player2score = gameContext.stoneCount(6);
	}

	switch (status) {
	case GameState.GAME_OVER_WIN: 
	    if (currentMover == player1) return 1;
	    else return 2;
	case GameState.GAME_OVER_LOSE:
	    if (currentMover == player1) return 2;
	    else return 1;
	case GameState.GAME_OVER_TIE:
	    return 0;
	default: return 0;
	}
    }

    /**
     * @returns the score of player1. Meaningless before the game ends.
     */
    public int getPlayer1Score() {
	return player1score;
    }

    /**
     * @returns the score of player2. Meaningless before the game ends.
     */
    public int getPlayer2Score() {
	return player2score;
    }

    //////////////////////////////////
    
    /**
     * Takes care of executing the move in a separate thread so that we can timeout if the player takes too long.
     */
    private static class MovingThread extends Thread{
        private Player player ;
        private GameState context;
        private Object mutex ;
        private long timeout;
        
        private int moveResult;
        
        public MovingThread(Player player, GameState context, Object mutex, long timeout){
            this.player = player;
            this.context = context;
            this.mutex = mutex;
            this.timeout = timeout;
        }
        
        public void run(){
            //System.out.println("Moving thread is waiting for mutex.");
            moveResult = 0;
	    try {
		synchronized (mutex) {  //this is just to ensure that the player doesn't
		                        //move much before the timer is started
		}
		player.move(context);
		//System.out.println("Thread about to exit.");
		synchronized (mutex) {
		    mutex.notify();  //wake up the match if we finished before the time
		}
	    }
	    catch (Exception e) {
		System.out.println(e.toString());
	    }
	}
        
        public int getMove(){
            return player.getMove();
        }
        
    }  
}

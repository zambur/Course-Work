/****************************************************************
 * GameState.java
 * Do not modify this file!
 * The GameState class is used to represent the Mancala Board during play. The
 * current player is always assumed to be on the bottom row. You are recommended to read and understand this file.
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


public final class GameState 
{
    
    /** returned by status() when the game is not over **/
    public static final int GAME_NOT_OVER  = Integer.MIN_VALUE;
    
    /** returned by status() when the player on the lower row has won **/
    public static final int GAME_OVER_WIN  =  1;
    
    /** returned by status() when game is over but the players have tied **/
    public static final int GAME_OVER_TIE  =  0;
    
    /** returned by status() when the player on the upper row has won **/
    public static final int GAME_OVER_LOSE = -1;
    
    public int[] state = { 4, 4, 4, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 0 };

    /**
     * This default constructor will create an initial board for the beginning
     * of a game. Each pocket has 4 stones initially.
     */
    public GameState() {}
    
    /**
     * This constructor assigns a different initial number of stones in the
     * bins of the mancala board than the default 4.
     *
     * @param initialStones the initial number of stones in the bins
     * must be > 0, otherwise it defaults to 4.
     */
    public GameState(int initialStones) 
    {
    	if (initialStones < 1) initialStones = 4;
    	for (int i=0; i<6; i++)
    		state[i] = state[i+7] = initialStones;
    }
 
    /**
    * A copy constructor
    * @param source the object out of which to construct a copy
    */
    public GameState(GameState source) 
    {
    	this.state = arrayCopy(source.state);
    }
    
    /**
     * returns a class constant indicating the current status of the game
     * @return the current game status as defined by the class constants
     */
    public int status() 
    {
    	if (stonesCount(7,12) != 0 && stonesCount(0,5) != 0)
    		return GAME_NOT_OVER;
    	else if (stonesCount(7,13) < stonesCount(0,6))
    		return GAME_OVER_WIN;
    	else if (stonesCount(7,13) == stonesCount(0,6))
    		return GAME_OVER_TIE;
    	else
    		return GAME_OVER_LOSE;
    }
    
    /**
     * returns whether or not the game is over by making a call to status()
     * @return true; the game is over<br>false; otherwise
     */
    public boolean gameOver() 
    {
    	return status() != GAME_NOT_OVER;
    }
    
    /**
     * provides a copy of the mancala board as an array of integers where the bin
     * numbers are indexed in the following way:<pre>
     -----------------------------------------
     |    | 12 | 11 | 10 |  9 |  8 |  7 |    |
     | 13 |-----------------------------|  6 |
     |    |  0 |  1 |  2 |  3 |  4 |  5 |    |
     -----------------------------------------</pre>
     * @return an array of the number of stones in each bin
     */
    public int[] toArray() 
    {
    	return arrayCopy(state);
    }
    
    /**
     * provides a copy of the manacala board as a matrix of integers where the bin
     * coordinates are indexed in the following way:<pre>
     -------------------------------------------------
     |     |(1,5)|(1,4)|(1,3)|(1,2)|(1,1)|(1,0)|     |
     |(1,6)|-----------------------------------|(0,6)|
     |     |(0,0)|(0,1)|(0,2)|(0,3)|(0,4)|(0,5)|     |
     -------------------------------------------------</pre>
     * @return a matrix of the number of stones in each bin
     */
    public int[][] toMatrix() 
    {
    	int[][] matrix = new int[2][7];
    	for (int i = 0; i < 14; ++i)
    		matrix[i/7][i%7] = state[i];
    	return matrix;
    }
    
    /**
     * an accesor for the number of stones in the bin where the bin numbers are
     * indexed in the following way:<pre>
     -----------------------------------------
     |    | 12 |  1 | 10 |  9 |  8 |  7 |    |
     | 13 |-----------------------------|  6 |
     |    |  0 |  1 |  2 |  3 |  4 |  5 |    |
     -----------------------------------------</pre>
     * @param bin the bin to querry for number of stones
     * @return the number of stones in the bin
     */
    public int stoneCount(int bin)
    {
    	return state[bin];
    }
    
    /**
     * an accessor for the number of stones in the bin where the bin numbers are
     * indexed in the following way:<pre>
     -------------------------------------------------
     |     |(1,5)|(1,4)|(1,3)|(1,2)|(1,1)|(1,0)|     |
     |(1,6)|-----------------------------------|(0,6)|
     |     |(0,0)|(0,1)|(0,2)|(0,3)|(0,4)|(0,5)|     |
     -------------------------------------------------</pre>
     * @param bin1 the first coordinate
     * @param bin2 the second coordinate
     * @return the number of stones in the bin
     */
    public int stoneCount(int bin1, int bin2)
    {
    	return state[7*bin1 + bin2];
    }
    
    /**
     * returns a boolean based upon the state and the bin chosen. For efficiency,
     * this method does not take into account state status or turns.
     *
     * @param bin the proposed bin from which to advance the stones
     * must be between 0 and 5 inclusive
     * @return true; the move from this state is legal<br>
     * false; otherwise
     */
    public boolean illegalMove(int bin)
    {
    	return (state[bin] == 0 || bin < 0 || bin == 6 || bin > 12);
    }
    
    /**
     * applies the given move to the given state
     * @param state the initial state before the method executes,
     * and the resulting state once the method completes
     * @param bin the move to apply to the state
     *
     * @returns true if the player gets to move again, false otherwise.
     */
    public boolean applyMove(int bin) 
    {
    	int stones = state[bin];
    	//clear the original bin
    	state[bin] = 0;
    	
    	for (int i = 0; i < stones; ++i) 
    	{
    		int nextBin = (bin+i+1)%14;
    		if (!(nextBin == 6 && bin > 6) && !(nextBin == 13 && bin < 7))
    			++state[nextBin];
    		else
    			++stones;
    	}
    	int lastBin = (bin+stones)%14;
    	boolean lastBinEmpty = state[lastBin] == 1;
    	boolean lastBinOnYourSide = bin/7 == lastBin/7;
    	if ((lastBin == 6 || lastBin == 13) && !gameOver()) 
    	{
    		return true;
        }
    	if (lastBinEmpty && lastBinOnYourSide && lastBin != 6 && lastBin != 13) 
    	{
    		int mancalaBin =  mancalaOf(bin);
    		int neighborBin = neighborOf(lastBin);
    		state[mancalaBin] += state[neighborBin] + 1;
    		state[neighborBin] = 0;
    		state[lastBin] = 0;
    	}
        if (gameOver())
          stonesToMancalas();
        return false;
    }

    /**
     * switches the board's current perspective so that the bottom and top rows
     * switch.
     */
    public void rotate() 
    {
    	int[] rotatedState = new int[state.length];
    	for (int i = 0; i < state.length; ++i)
    		rotatedState[(i+7)%14] = state[i];
    	state = rotatedState;
    }
    
    /**
     * provides a nice String representation of a state
     *
     * @param state the state to convert to a String
     * @return a nice String representation of the state
     */
    public String toString() {
	StringBuffer buffer = new StringBuffer();
	//	buffer.append("        6    5    4    3    2    1       \n");
	buffer.append("+---------------------------------------+\n");
	
	buffer.append("|    |");
	for (int i = 12; i >= 7; --i) {
	    buffer.append(toString(state[i]));
	}
	buffer.append("    |\n");
	
	buffer.append("|");
	buffer.append(toString(state[13]));
	buffer.append("-----------------------------|");
	buffer.append(toString(state[6]));
	buffer.append("\n");
	
	buffer.append("|    |");
	for (int i = 0; i <= 5; ++i) {
	    buffer.append(toString(state[i]));
	}
	buffer.append("    |\n");
	
	buffer.append("+---------------------------------------+\n");
	buffer.append("        0    1    2    3    4    5       \n");
	
	return buffer.toString();
    }
    
    private int stonesCount(int bin1, int bin2) {
	int stones = 0;
	for (int i = bin1; i <= bin2; ++i)
	    stones += state[i];
    return stones;
    }
    
    /* xxx private*/ void stonesToMancalas() {
      state[6]  += stonesCount(0,5);
      state[13] += stonesCount(7,12);
      for (int i = 0; i < 6; ++i) {
        state[i] = 0;
        state[i+7] = 0;
      }
    }

    public int neighborOf(int bin) {
	if (bin == 13)
	    return bin;
	else
	    return 12-bin;
    } 
    
    public int mancalaOf(int bin) {
	return bin / 7 * 7 + 6;
    }
    
    private int[] arrayCopy(int[] source) {
	if (source == null)
	    return null;
	int[] sink = new int[source.length];
	for (int i = 0; i < source.length; ++i)
	    sink[i] = source[i];
	return sink;
    }
    
    private static String toString(int stones) {
	if (stones < 10)
	    return "  " + stones + " |";
	else
	    return " " + stones + " |";
    }

    GameState(int[] state) {
      this.state = state;
    }

}

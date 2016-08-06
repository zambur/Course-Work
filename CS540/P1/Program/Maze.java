/**
 * A data structure to represent a maze. Each cell in the maze is
 * called a square. The maze is represented as a char matrix.
 * (0,0)th element of the matrix represents the top-left corner of the maze. 
 * %: Represents a wall 
 * S: Represents the initial position of the player 
 * G: Represents the goal position.
 * 
 * You do not need to change this class.
 */
public class Maze {
	private char[][] mazeMatrix;

	// the square that the player is in:
	private Square playerSquare;

	// the square that the goal is in:
	private Square goalSquare;

	private int noOfRows;
	private int noOfCols;

	/**
	 * @param mazeMatrix
	 *            character representation of the matrix
	 * @param playerSquare
	 *            the square of the player
	 * @param goalSquare
	 *            the square of the goal
	 */
	public Maze(char[][] mazeMatrix, Square playerSquare, Square goalSquare) {
		this.mazeMatrix = mazeMatrix;
		this.playerSquare = playerSquare;
		this.goalSquare = goalSquare;
		this.noOfRows = mazeMatrix.length;
		this.noOfCols = mazeMatrix[0].length;
	}

	/**
	 * Replaces the value of the square with ch
	 * 
	 * @param square
	 * @param ch
	 */
	public void setOneSquare(Square square, char ch) {
		this.mazeMatrix[square.X][square.Y] = ch;
	}

	/**
	 * @return the character matrix representation of the maze
	 */
	public char[][] getMazeMatrix() {
		return mazeMatrix;
	}

	/**
	 * @param i
	 * @param j
	 * @return return the character that is in the (i,j)th square
	 */
	public char getSquareValue(int i, int j) {
		return mazeMatrix[i][j];
	}

	/**
	 * @return the square that the player is in
	 */
	public Square getPlayerSquare() {
		return playerSquare;
	}

	/**
	 * @return the square that the goal is in
	 */
	public Square getGoalSquare() {
		return goalSquare;
	}

	/**
	 * @return the number of rows in the maze
	 */
	public int getNoOfRows() {
		return noOfRows;
	}

	/**
	 * @return the number of columns in the maze
	 */
	public int getNoOfCols() {
		return noOfCols;
	}
}

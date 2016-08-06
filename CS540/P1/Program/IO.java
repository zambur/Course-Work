import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

/**
 * Simple I/O operations.
 * 
 * You do not need to change this class.
 */
public class IO {
	/**
	 * 
	 * @param fileName a maze file name. File should not contain any extra white
	 *            space.
	 * @return the Maze data structure of the maze represented by the file.
	 */
	public static Maze readInputFile(String fileName) {
		char[][] mazeMatrix = null;
		Square playerSquare = null;
		Square goalSquare = null;
		int noOfRows;
		int noOfCols;

		try {
			ArrayList<String> lines = new ArrayList<String>();
			BufferedReader reader = new BufferedReader(new FileReader(fileName));
			String line;
			while ((line = reader.readLine()) != null)
				if (!line.equals(""))
					lines.add(line);

			noOfRows = lines.size();
			noOfCols = lines.get(0).length();
			mazeMatrix = new char[noOfRows][noOfCols];

			for (int i = 0; i < noOfRows; ++i) {
				line = lines.get(i);
				for (int j = 0; j < noOfCols; ++j) {
					mazeMatrix[i][j] = line.charAt(j);
					if (mazeMatrix[i][j] == 'S')
						playerSquare = new Square(i, j);
					if (mazeMatrix[i][j] == 'G')
						goalSquare = new Square(i, j);
				}
			}

		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return new Maze(mazeMatrix, playerSquare, goalSquare);
	}

	/**
	 * Output the necessary information. You do not need to write any
	 * System.out.println() anywhere.
	 * 
	 * @param maze
	 *            the maze with a “.” in each square that is part of the
	 *            solution path
	 * @param cost
	 *            the cost of the solution path
	 * @param noOfNodesExpanded
	 *            the number of nodes expanded
	 * @param maxDepth
	 *            the maximum depth searched
	 * @param maxFrontierSize
	 *            the maximum size of the frontier list at any point during the
	 *            search
	 */
	public static void printOutput(Maze maze, int cost, int noOfNodesExpanded,
			int maxDepth, int maxFrontierSize) {
		char[][] mazeMatrix = maze.getMazeMatrix();

		for (int i = 0; i < mazeMatrix.length; ++i) {
			for (int j = 0; j < mazeMatrix[0].length; ++j) {
				System.out.print(mazeMatrix[i][j]);
			}
			System.out.println();
		}

		System.out.println("Total solution cost: " + cost);
		System.out.println("Number of nodes expanded: " + noOfNodesExpanded);
		System.out.println("Maximum depth searched: " + maxDepth);
		System.out.println("Maximum size of the frontier: " + maxFrontierSize);
	}
}

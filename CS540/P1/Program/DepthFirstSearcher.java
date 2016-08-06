import java.util.ArrayList;
import java.util.LinkedList;

/**
 * Depth-First Search (DFS)
 * 
 * You should fill the search() method of this class.
 */
public class DepthFirstSearcher extends Searcher {

	/**
	 * Calls the parent class constructor.
	 * 
	 * @see Searcher
	 * @param maze initial maze.
	 */
	public DepthFirstSearcher(Maze maze) {
		super(maze);
	}

	/**
	 * Main depth first search algorithm.
	 * 
	 * @return true if the search finds a solution, false otherwise.
	 */
	public boolean search() {
		// explored list is a 2D Boolean array that indicates if a state associated with a given position in the maze has already been explored.
		boolean[][] explored = new boolean[maze.getNoOfRows()][maze.getNoOfCols()];
		
		// Stack implementing the Frontier list
		LinkedList<State> stack = new LinkedList<State>();
	    stack.push(new State(maze.getPlayerSquare(), null, 0, 0));
		
		while (!stack.isEmpty()) {
			State state = stack.pop();
			noOfNodesExpanded++;

			if(state.getDepth() > maxDepthSearched) {
				maxDepthSearched = state.getDepth();
			}

			// Return true if find a solution
			if (state.isGoal(maze)) {
				state = state.getParent();
				cost = 1;
				while(state != null && state.getParent() != null) {
					maze.setOneSquare(state.getSquare(), '.');
					state = state.getParent();
					cost++;
				}
				return true;
			}
			
			// Add the node to the explored set
			explored[state.getX()][state.getY()] = true;
			// Adding the resulting nodes to the frontier 
			ArrayList<State> successor = state.getSuccessors(explored, maze);

			for (State currState : successor) {
				if(!stack.contains(currState) && !explored[currState.getX()][currState.getY()]) {
					stack.push(currState);
				}
			}

			if(stack.size() > maxSizeOfFrontier) {
				maxSizeOfFrontier = stack.size();
			}
		}
		// Return false if no solution
		return false;
	}

}

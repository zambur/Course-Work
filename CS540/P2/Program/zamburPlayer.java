/****************************************************************
 * Authors: Zach Ambur & Aman Lunia
 * Course: CS 540
 * Date: Summer 2016
 * 
 * zamburPlayer.java 
 * Implements MiniMax search with A-B pruning and iterative deepening search (IDS). The static board 
 * evaluator (SBE) function is simple: the # of stones in zamburPlayer's 
 * mancala minue the # in opponent's mancala.
 * ------------------------------------------------------------------------------
 * ----------------------------------- Licensing Information: You are free to
 * use or extend these projects for educational purposes provided that (1) you
 * do not distribute or publish solutions, (2) you retain the notice, and (3)
 * you provide clear attribution to UW-Madison
 * 
 * Attribute Information: The Mancala Game was developed at UW-Madison.
 * 
 * The initial project was developed by Chuck Dyer(dyer@cs.wisc.edu) and his
 * TAs.
 * 
 * Current Version with GUI was developed by Fengan Li(fengan@cs.wisc.edu). Some
 * GUI componets are from Mancala Project in Google code.
 */

// ################################################################
// zamburPlayer class
// ################################################################

public class zamburPlayer extends Player {

	// Alpha-Beta Search
	// Uses Iterative deepening depth-first search to find the best move.
	// Note that the search can be interrupted by time limit.
	public void move(GameState state) {
		int depth = 1;
		while (true){
			move = maxAction(state, depth);
			depth++;
		}
	}

	// Return the index of the best next move for Max Player (Computer)
	public int maxAction(GameState state, int maxDepth) {
		int binIndex = -1;
		int sbe = Integer.MIN_VALUE;
		int alpha = Integer.MIN_VALUE;
		int beta = Integer.MAX_VALUE;
		for (int i = 5; i >= 0; i--) {
			if (!state.illegalMove(i)) {
				GameState currBoard = new GameState(state);

				if (currBoard.applyMove(i)) {
					sbe = Math.max(sbe, maxAction(currBoard, 1, maxDepth, alpha, beta));
				} else {
					sbe = Math.max(sbe, minAction(currBoard, 1, maxDepth, alpha, beta));
				}
				if (alpha < sbe) {
					binIndex = i;
					alpha = sbe;
				}
			}
		}
		return binIndex;
	}

	// Return the best move for Max Player (Computer)
	public int maxAction(GameState state, int currentDepth, int maxDepth, int alpha, int beta) {
		// Return sbe if search has reached max depth of tree or if it has found an end to the game
		if (currentDepth == maxDepth || state.status() != Integer.MIN_VALUE) {
			return sbe(state);
		}

		int sbe = Integer.MIN_VALUE;
		for (int i = 5; i >= 0; i--) {
			// Make sure move is legal
			if (!state.illegalMove(i)) {
				GameState currBoard = new GameState(state);

				// Check if the current move will result in another free move
				if (currBoard.applyMove(i)) {
					sbe = Math.max(sbe, maxAction(currBoard, currentDepth + 1, maxDepth, alpha, beta));
				} else {
					sbe = Math.max(sbe, minAction(currBoard, currentDepth + 1, maxDepth, alpha, beta));
				}
				// Compare sbe to beta and return if greater than
				if (sbe >= beta) {
					return sbe;
				}
				// Reset alpha to the new highest limiting factor
				alpha = Math.max(alpha, sbe);
			}
		}
		return sbe;
	}

	// Return the best move for Min Player (Opponent)
	public int minAction(GameState state, int currentDepth, int maxDepth, int alpha, int beta) {
		// Return sbe if search has reached max depth of tree or if it has found an end to the game
		if (currentDepth == maxDepth || state.status() != Integer.MIN_VALUE) {
			return sbe(state);
		}

		int sbe = Integer.MAX_VALUE;
		for (int i = 12; i >= 7; i--) {
			// Make sure move is legal
			if (!state.illegalMove(i)) {
				GameState currBoard = new GameState(state);

				// Check if the current move will result in another free move
				if (currBoard.applyMove(i)) {
					sbe = Math.min(sbe, minAction(currBoard, currentDepth + 1, maxDepth, alpha, beta));
				} else {
					sbe = Math.min(sbe, maxAction(currBoard, currentDepth + 1, maxDepth, alpha, beta));
				}
				// Compare sbe to alpha and return if less than
				if (sbe <= alpha) {
					return sbe;
				}
				// Reset beta to the new lowest limiting factor
				beta = Math.min(beta, sbe);
			}
		}
		return sbe;
	}
	// sbe function for game state. 
	// Compares all of computers mancala against all of the opponents mancala. Both in stash and in bins.
	// Note that in the game state, the bins for current player are always at the bottom of the board.
	private int sbe(GameState state) {
		int boardValue = 0;
		for (int i = 0; i < 7; i++) {
			boardValue += (state.stoneCount(i));
		}
		for (int j = 7; j < 14; j++) {
			boardValue -= (state.stoneCount(j));
		}
		return boardValue;
	}
}
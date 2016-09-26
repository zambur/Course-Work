# Program 2

***Written Homework***   
This portion of the homework looks at two different algorithms, Minimax with Alpha Beta Pruning and Hill Climbing. For each 
there are seperate questions asking for implementations of them.

***Program***   
For this program I created a Java based program that plays the game Mancala (also called Kalaha or Wari), which is an ancient
African and Middle Eastern combinatorial game. The game is two- player and turn-based, and uses a board with 12 small bins 
(6 for each player) and two mancalas (the large "scoring" bins, one for each player), and a set of small stones. The 6 small 
bins in front of you and the mancala on your right are yours.

The basic rules, board layout, and opponent player were already programmed for me; my job was to create an expert level player
that could win every game. There are four things I focused on for implementing the best Mancala player:   
1. Minimax search   
2. Alpha-beta pruning   
3. Time management with iterative-deepening search (IDS)   
4. A static board evaluation (SBE) function   

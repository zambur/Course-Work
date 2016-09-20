/**
 * Class to identfiy connections
 * between different layers.
 * 
 */

public class NodeWeightPair{
	public Node node; //The parent node
	public Double weight; //Weight of this connection
	
	//Create an object with a given parent node 
	//and connect weight
	public NodeWeightPair(Node node, Double weight)
	{
		this.node=node;
		this.weight=weight;
	}
}
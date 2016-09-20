/**
 * The main class that handles the entire network
 * Has multiple attributes each with its own use
 */

import java.util.*;


public class NNImpl{
	public ArrayList<Node> inputNodes=null;//list of the output layer nodes.
	public ArrayList<Node> hiddenNodes=null;//list of the hidden layer nodes
	public ArrayList<Node> outputNodes=null;// list of the output layer nodes

	public ArrayList<Instance> trainingSet=null;//the training set

	Double learningRate=1.0; // variable to store the learning rate
	int maxEpoch=1; // variable to store the maximum number of epochs

	/**
	 * This constructor creates the nodes necessary for the neural network
	 * Also connects the nodes of different layers
	 * After calling the constructor the last node of both inputNodes and  
	 * hiddenNodes will be bias nodes. 
	 */

	public NNImpl(ArrayList<Instance> trainingSet, int hiddenNodeCount, Double learningRate, int maxEpoch, Double [][]hiddenWeights, Double[][] outputWeights)
	{
		this.trainingSet=trainingSet;
		this.learningRate=learningRate;
		this.maxEpoch=maxEpoch;

		//input layer nodes
		inputNodes=new ArrayList<Node>();
		int inputNodeCount=trainingSet.get(0).attributes.size();
		int outputNodeCount=trainingSet.get(0).classValues.size();
		for(int i=0;i<inputNodeCount;i++)
		{
			Node node=new Node(0);
			inputNodes.add(node);
		}

		//bias node from input layer to hidden
		Node biasToHidden=new Node(1);
		inputNodes.add(biasToHidden);

		//hidden layer nodes
		hiddenNodes=new ArrayList<Node> ();
		for(int i=0;i<hiddenNodeCount;i++)
		{
			Node node=new Node(2);
			//Connecting hidden layer nodes with input layer nodes
			for(int j=0;j<inputNodes.size();j++)
			{
				NodeWeightPair nwp=new NodeWeightPair(inputNodes.get(j),hiddenWeights[i][j]);
				node.parents.add(nwp);
			}
			hiddenNodes.add(node);
		}

		//bias node from hidden layer to output
		Node biasToOutput=new Node(3);
		hiddenNodes.add(biasToOutput);

		//Output node layer
		outputNodes=new ArrayList<Node> ();
		for(int i=0;i<outputNodeCount;i++)
		{
			Node node=new Node(4);
			//Connecting output layer nodes with hidden layer nodes
			for(int j=0;j<hiddenNodes.size();j++)
			{
				NodeWeightPair nwp=new NodeWeightPair(hiddenNodes.get(j), outputWeights[i][j]);
				node.parents.add(nwp);
			}	
			outputNodes.add(node);
		}	
	}

	/**
	 * Get the output from the neural network for a single instance
	 * Return the idx with highest output values. For example if the outputs
	 * of the outputNodes are [0.1, 0.5, 0.2], it should return 1. If outputs
	 * of the outputNodes are [0.1, 0.5, 0.5], it should return 2. 
	 * The parameter is a single instance. 
	 */
	public int calculateOutputForInstance(Instance inst) {
		for (int i = 0; i < inst.attributes.size(); i++) {
			inputNodes.get(i).setInput(inst.attributes.get(i));
		}

		for (Node hNode : hiddenNodes) {
			hNode.calculateOutput();
		}

		for (Node oNode : outputNodes) {
			oNode.calculateOutput();
		}

		int maxInteger = 0;
		double maxValue = 0.0;
		for (int idx = 0; idx < outputNodes.size(); idx++) {
			if (outputNodes.get(idx).getOutput() >= maxValue) {
				maxValue = outputNodes.get(idx).getOutput();
				maxInteger = idx;
			}
		}

		return maxInteger;
	}

	private double outputError(Node outputNode, int classValue) {
		Double error = outputNode.getSum();
		if (error <= 0.0) {
			error = 0.0;
		} else {
			error = 1.0;
		}
		error *= classValue - outputNode.getOutput();
		return error;
	}

	private double hiddenError(int hiddenIndex, Instance inst, Double[][]errors) {
		double error = 0.0;
		for (int output = 0; output < outputNodes.size(); output++) {
			error += outputNodes.get(output).parents.get(hiddenIndex).weight * errors[output][inst.classValues.get(output)];
		}

		if (hiddenNodes.get(hiddenIndex).getSum() <= 0.0) {
			return 0.0;
		} else {
			return error;
		}		
	}

	/**
	 * Train the neural networks with the given parameters
	 * 
	 * The parameters are stored as attributes of this class
	 */
	public void train() {
		for (int epoch = 0; epoch < maxEpoch; epoch++) {
			for (Instance inst : trainingSet) {
				Double errors [][] = new Double [outputNodes.size()][inst.classValues.size()];
				// update the Neural Networks
				calculateOutputForInstance(inst);

				for (int oNode = 0; oNode < outputNodes.size(); oNode++) {
					for (NodeWeightPair parentNodes : outputNodes.get(oNode).parents) {
						errors[oNode][inst.classValues.get(oNode)]=outputError(outputNodes.get(oNode) , inst.classValues.get(oNode));
						parentNodes.weight += learningRate * parentNodes.node.getOutput() * errors[oNode][inst.classValues.get(oNode)];
					}
				}

				for (int hNode = 0; hNode < hiddenNodes.size(); hNode++) {
					if (hiddenNodes.get(hNode).parents != null) {
						for (NodeWeightPair parentNodes : hiddenNodes.get(hNode).parents) {
							parentNodes.weight += learningRate * parentNodes.node.getOutput() * hiddenError(hNode, inst, errors);
						}
					}
				}

				}
			}
		}
	}
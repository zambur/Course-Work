import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 * Fill in the implementation details of the class DecisionTree using this file. Any methods or
 * secondary classes that you want are fine but we will only interact with those methods in the
 * DecisionTree framework.
 * 
 * You must add code for the 1 member and 4 methods specified below.
 * 
 * See DecisionTree for a description of default methods.
 */
public class DecisionTreeImpl extends DecisionTree {
	private DecTreeNode root;
	//ordered list of class labels
	private List<String> labels; 
	//ordered list of attributes
	private List<String> attributes; 
	//map to ordered discrete values taken by attributes
	private Map<String, List<String>> attributeValues; 


	/**
	 * Answers static questions about decision trees.
	 */
	DecisionTreeImpl() {
		// no code necessary this is void purposefully
	}

	/**
	 * Build a decision tree given only a training set.
	 * 
	 * @param train: the training set
	 */
	DecisionTreeImpl(DataSet train) {

		this.labels = train.labels;
		this.attributes = train.attributes;
		this.attributeValues = train.attributeValues;
		// TODO: add code here
		root = buildTree(train.instances, attributes, null, null);
	}

	private DecTreeNode buildTree(List<Instance> currInstances, List<String> unvisitedAttributes, String parentAttributeValue, String defVal){
		if(currInstances.isEmpty())
			return (new DecTreeNode(defVal, "", parentAttributeValue, true));

		if(allSame(currInstances))
			return (new DecTreeNode(currInstances.get(0).label, "", parentAttributeValue, true));

		if(unvisitedAttributes.isEmpty())
			return (new DecTreeNode(majorityLabel(currInstances), "", parentAttributeValue, true));

		String bestAttribute = bestAttribute(currInstances, unvisitedAttributes);
		DecTreeNode subTree = new DecTreeNode(majorityLabel(currInstances), "", parentAttributeValue, false);

		for(String attrValue : attributeValues.get(bestAttribute)){			
			int attIndex = getAttributeIndex(bestAttribute);
			List<Instance> newInstances = new ArrayList<Instance>();
			for(Instance b : currInstances){
				if(b.attributes.get(attIndex).equals(attrValue))
					newInstances.add(b);
			}

			ArrayList<String> attrUnvisitedPass = new ArrayList<String>();
			for(String attr: unvisitedAttributes) {
				if(!attr.equals(bestAttribute)) {
					attrUnvisitedPass.add(attr);
				}
			}

			subTree.addChild(buildTree(newInstances, attrUnvisitedPass, attrValue, majorityLabel(currInstances)));
		}
		subTree.attribute = bestAttribute;
		return subTree;
	}


	private String majorityLabel(List<Instance> instances){
		int label0 = 0;
		int label1 = 0;

		for(Instance a : instances)
			if(a.label.equals(labels.get(0)))
				label0++;
			else
				label1++;

		if(label0<label1)
			return labels.get(1);
		else
			return labels.get(0);
	}

	private boolean allSame(List<Instance> instances){
		String label = instances.get(0).label;

		for(Instance a : instances)
			if(!label.equals(a.label))
				return false;

		return true;
	}

	@Override
	public String classify(Instance instance) {
		// TODO: add code here
		DecTreeNode node = root;
		String label = "";
		for (int i=0;i<attributes.size();i++){
			if (node.terminal){
				label = node.label;
				break;
			}
			int index = getAttributeIndex(node.attribute);
			for (DecTreeNode child : node.children) {
				if (child.parentAttributeValue.equals(instance.attributes.get(index))) {
					node = child;
					label = node.label;
				}
			}
		}
		return label;
	}

	@Override
	public void rootInfoGain(DataSet train) {
		this.labels = train.labels;
		this.attributes = train.attributes;
		this.attributeValues = train.attributeValues;
		// TODO: add code here
		for(int a = 0; a < attributes.size(); a++) {
			System.out.print(attributes.get(a) + " ");
			double gain = calcH(train.instances) - calcCondH(train.instances, attributes.get(a));
			System.out.format("%.5f\n", gain);
		}

	}

	private String bestAttribute(List<Instance> instances, List<String> attributes) {
		String bestAttr = attributes.get(0);
		double bestGain = -1;
		for(String a : attributes) {

			double gain = calcH(instances) - calcCondH(instances, a);
			if (gain > bestGain) {
				bestGain = gain;
				bestAttr = a;
			}
		}
		return bestAttr;
	}

	private double calcCondH(List<Instance> instances, String attr) {
		List<String> attrValues = attributeValues.get(attr);
		int[] numAttrWithValue = new int[attrValues.size() * 2];
		for(int i = 0; i < instances.size(); i++) {
			String value = instances.get(i).attributes.get(getAttributeIndex(attr));
			for(int n = 0; n < attrValues.size(); n++) {
				if(value.equals(attrValues.get(n)) & instances.get(i).label.equals(labels.get(0))) {
					numAttrWithValue[2 * n]++;
				} else if (value.equals(attrValues.get(n)) & instances.get(i).label.equals(labels.get(1))) {
					numAttrWithValue[2 * n + 1]++;
				}
			}
		}
		double condH = 0.0;
		double entropy = 0.0;
		for(int v = 0; v < attrValues.size(); v++) {
			entropy = 0.0;
			if((numAttrWithValue[2 * v] + numAttrWithValue[2 * v + 1]) != 0) {
				double probability = ((double) numAttrWithValue[2 * v]) / ((numAttrWithValue[2 * v] + numAttrWithValue[2 * v + 1]));
				if (probability != 0 && probability != 1) {
					entropy = - (probability * (Math.log(probability) / Math.log(2))) - ((1 - probability) * (Math.log(1 - probability) / Math.log(2)));
				}
				probability = ((double) numAttrWithValue[2 * v] + numAttrWithValue[2 * v + 1]) / instances.size();
				condH = condH + probability * entropy;
			}
		}
		return condH;
	}

	private double calcH(List<Instance> instances) {
		// Create array to keep track of the number of instances that have that label
		int labelValueCount[] = new int[this.labels.size()];
		// iterate through all the instances and increment the index of the label when found
		for (int i = 0; i < instances.size(); i++) {
			labelValueCount[getLabelIndex(instances.get(i).label)]++;
		}
		double entropy = 0.0;
		for (int i = 0; i < this.labels.size(); i++) {
			double probability = ((double) labelValueCount[i] / instances.size());
			if (probability != 0 && probability != 1)
				entropy = entropy - (probability)*(Math.log(probability) / Math.log(2));
		}
		return entropy;
	}


	@Override
	public void printAccuracy(DataSet test) {
		// TODO: add code here
		List<Instance> instances = test.instances;
		double err=0;
		for(Instance a : instances){
			if(!a.label.equals(classify(a)))
				err++;
		}
		double accuracy = 1-(err/instances.size());
		System.out.format("%.5f\n", accuracy);
	}
	/**
	 * Build a decision tree given a training set then prune it using a tuning set.
	 * ONLY for extra credits
	 * @param train: the training set
	 * @param tune: the tuning set
	 */
	DecisionTreeImpl(DataSet train, DataSet tune) {

		this.labels = train.labels;
		this.attributes = train.attributes;
		this.attributeValues = train.attributeValues;
		// TODO: add code here
		// only for extra credits
		root = buildTree(train.instances, attributes, null, null);
		List<DecTreeNode> unPrunedNodes= new ArrayList<DecTreeNode>();
		List<DecTreeNode> prunedNodes= new ArrayList<DecTreeNode>();
		for(DecTreeNode a : root.children){
			unPrunedNodes.add(a);
			prunedNodes.add(prune(a, tune.instances, root.attribute, tune.instances));
		}
		double accuracy = accuracy(tune.instances);
		for(DecTreeNode a:prunedNodes){
			root.children.remove(prunedNodes.indexOf(a));
			root.children.add(prunedNodes.indexOf(a), a);
		}
		for(DecTreeNode a :unPrunedNodes){
			double newAccuracy = accuracy(tune.instances);
			if(newAccuracy<=accuracy){
				root.children.remove(unPrunedNodes.indexOf(a));
				root.children.add(unPrunedNodes.indexOf(a), a);
			}
		}
	}

	private DecTreeNode prune(DecTreeNode T, List<Instance> instances, String attribute, List<Instance> check){
		List<Instance> newInstances = new ArrayList<Instance>();				
		if(!T.terminal ){
			int attIndex = getAttributeIndex(attribute);
			for(Instance b : instances){
				if(b.attributes.get(attIndex).equals(T.parentAttributeValue))
					newInstances.add(b);
			}
			List<DecTreeNode> unPrunedNodes= new ArrayList<DecTreeNode>();
			List<DecTreeNode> prunedNodes= new ArrayList<DecTreeNode>();
			for(DecTreeNode a : T.children){
				unPrunedNodes.add(a);
				prunedNodes.add(prune(a, newInstances, T.attribute, check));
			}
			double accuracy = accuracy(check);
			for(DecTreeNode a:prunedNodes){
				T.children.remove(prunedNodes.indexOf(a));
				T.children.add(prunedNodes.indexOf(a), a);
			}
			for(DecTreeNode a :unPrunedNodes){
				double newAccuracy = accuracy(check);
				if(newAccuracy<=accuracy){
					T.children.remove(unPrunedNodes.indexOf(a));
					T.children.add(unPrunedNodes.indexOf(a), a);
				}
			}
			return new DecTreeNode(majorityLabel(newInstances), T.attribute, T.parentAttributeValue, true);
		}
		return T;
	}

	private double accuracy(List<Instance> instances){
		double err=0;
		for(Instance a : instances){
			if(!a.label.equals(classify(a)))
				err++;
		}
		double accuracy = 1-(err/instances.size());
		return accuracy;
	}

	@Override
	/**
	 * Print the decision tree in the specified format
	 */
	public void print() {

		printTreeNode(root, null, 0);
	}

	/**
	 * Prints the subtree of the node with each line prefixed by 4 * k spaces.
	 */
	public void printTreeNode(DecTreeNode p, DecTreeNode parent, int k) {
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < k; i++) {
			sb.append("    ");
		}
		String value;
		if (parent == null) {
			value = "ROOT";
		} else {
			int attributeValueIndex = this.getAttributeValueIndex(parent.attribute, p.parentAttributeValue);
			value = attributeValues.get(parent.attribute).get(attributeValueIndex);
		}
		sb.append(value);
		if (p.terminal) {
			sb.append(" (" + p.label + ")");
			System.out.println(sb.toString());
		} else {
			sb.append(" {" + p.attribute + "?}");
			System.out.println(sb.toString());
			for (DecTreeNode child : p.children) {
				printTreeNode(child, p, k + 1);
			}
		}
	}

	/**
	 * Helper function to get the index of the label in labels list
	 */
	private int getLabelIndex(String label) {
		for (int i = 0; i < this.labels.size(); i++) {
			if (label.equals(this.labels.get(i))) {
				return i;
			}
		}
		return -1;
	}

	/**
	 * Helper function to get the index of the attribute in attributes list
	 */
	private int getAttributeIndex(String attr) {
		for (int i = 0; i < this.attributes.size(); i++) {
			if (attr.equals(this.attributes.get(i))) {
				return i;
			}
		}
		return -1;
	}

	/**
	 * Helper function to get the index of the attributeValue in the list for the attribute key in the attributeValues map
	 */
	private int getAttributeValueIndex(String attr, String value) {
		for (int i = 0; i < attributeValues.get(attr).size(); i++) {
			if (value.equals(attributeValues.get(attr).get(i))) {
				return i;
			}
		}
		return -1;
	}
}

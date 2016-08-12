/**
 * This class provides a framework for accessing a decision tree. Do not modify or place code here,
 * instead create an implementation in a file DecisionTreeImpl.
 */
abstract class DecisionTree {
  /**
   * Evaluates the learned decision tree on a single instance.
   * 
   * @return the classification of the instance
   */
  abstract public String classify(Instance instance);

  /**
   * Prints the tree in specified format.
   */
  abstract public void print();

  /**
   * Print the information gain of each attribute as computed from creating the root node for the
   * given DataSet.
   * 
   * Print each line with one attribute
   * the Attr_name then a space then the info gain use precision of 5
   * decimal places in output.
   * 
   * Example:
   * A1 0.12345
   * A2 0.45678 
   * A3 0.24890
   * ....
   */
  abstract public void rootInfoGain(DataSet train);
  
  /**
   * Print the accuracy of the classification for test set with 5 decimal places
   * Example:
   * 0.12345
   */
  abstract public void printAccuracy(DataSet test);
}

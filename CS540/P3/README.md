# Program 3

***Written Homework***   
This portion of the homework looks at two different algorithms, Unsupervised Learning by Clustering and Decision Trees. For 
each there are seperate questions asking for implementations of them.

***Program***   
In this problem I implemented a program that builds a decision tree for categorical attributes and 2-class classification 
tasks. 

In the DecisionTreeImpl(DataSet train) method, I built the decision tree using the training data provided. To finish this part, 
I also wrote a recursive function corresponding to the DecisionTreeLearning function.

public String classify(Instance instance) takes an example, or an instance, as its input and computes the classification 
output (as a string) of the previously-built decision tree.

For the constructor DecisionTreeImpl(DataSet train, DataSet tune), after I built the tree, I would prune it using the tuning 
dataset provided and a iterative Pruning Algorithm.

# Program 4

***Written Homework***   
This portion of the homework looks at two different examples of the Bayesian Network. For 
each example there are seperate questions asking for different implementations of it.

***Program***   
For this problem I wrote a program that builds a 2-layer, feed-forward neural network and trains it using the back-propagation 
algorithm. The problem that the neural network will handle is a multi-class classification problem for recognizing handwritten 
digits. All inputs to the neural network will be numeric. The neural network has only one hidden layer. The network is also 
fully connected between consecutive layers, meaning each unit, which we’ll call a node, in the input layer is connected to all 
nodes in the hidden layer, and each node in the hidden layer is connected to all nodes in the output layer. Each node in the 
hidden layer and the output layer will also have an extra input from a “bias node" that has constant value +1. So, we can 
consider both the input layer and the hidden layer as containing one additional node called a bias node. All nodes in the 
hidden and output layers (except for the bias nodes) use the ReLU activation function. The initial weights of the network are 
randomized.

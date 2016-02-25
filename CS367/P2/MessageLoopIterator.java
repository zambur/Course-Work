package com.zachambur;
import java.util.Iterator;

/**
 * An Iterator for the MessageLoop data structure.
 */
public class MessageLoopIterator<E> implements Iterator<E>{
	
	DblListnode<E> curr;
	DblListnode<E> staticCurr;
	boolean reachedEnd;

    /**
     * Constructor: receive a Double List node as parameter.
     *
     * @param node
     */
	MessageLoopIterator(DblListnode<E> node) {
		Iterator<E> itr;
		staticCurr = node;
		curr = node;
		reachedEnd = false;
	}

    /**
     * Try to see if the next node is available or not. Since this is a circular
     * doubly list nodes, if the next node is equal to the first one in the list
     * Return false.
     *
     * @return True if there is available next node and false otherwise.
     */
	public boolean hasNext() {
		if(curr == null) {
			return false;
		}
		else if(reachedEnd == true) {
			return false;
		}
		else {
			return true;
		}
	}

    /**
     * Advance to the next node and return the data of this node.
     *
     * @return an object which is the data of the node.
     */
	public E next() {
		curr = curr.getNext();
		if(curr == staticCurr) {
			reachedEnd = true;
		}
		return curr.getData();
	}

    /**
     * Implemented the remove operation of Iterator<E> interface, but it is not
     * supported in this program.
     */
	public void remove() {
		throw new UnsupportedOperationException();
	}
}

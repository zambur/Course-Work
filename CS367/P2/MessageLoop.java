package com.zachambur;
import java.util.Iterator;

/**
 * This class is responsible to create a data structure called MessageLoop that
 * used DblListnode as the main implementation.
 */
public class MessageLoop<E> implements LoopADT<E>{
		
	DblListnode<E> curr;
	
	public MessageLoop() {
		curr = null;
	}

	/**
     * Adds the given item immediately before the current 
     * item.  After the new item has been added, the new item becomes the 
     * current item.
     * 
     * @param item - the item to add
     */
    public void addBefore(E item) {
    	DblListnode<E> newNode = new DblListnode<E>(item);
    	if(curr == null) {
    		curr = newNode;
    	}
    	else if(curr.getPrev() == null) {
    		newNode.setNext(curr);
    		newNode.setPrev(curr);
    		curr.setNext(newNode);
    		curr.setPrev(newNode);
    		curr = newNode;
    	}
    	else {
    		newNode.setNext(curr);
    		newNode.setPrev(curr.getPrev());
    		curr.getPrev().setNext(newNode);
    		curr.setPrev(newNode);
    		curr = newNode;
    	}
    }
    
    /**
     * Adds the given item immediately after the current 
     * item.  After the new item has been added, the new item becomes the 
     * current item.
     * 
     * @param item - the item to add
     */
    public void addAfter(E item) {
    	DblListnode<E> newNode = new DblListnode<E>(item);
    	if(curr == null) {
    		curr = newNode;
    	}
    	else if(curr.getNext() == null) {
    		newNode.setNext(curr);
    		newNode.setPrev(curr);
    		curr.setNext(newNode);
    		curr.setPrev(newNode);
    		curr = newNode;
    	}
    	else {
    		newNode.setNext(curr.getNext());
    		newNode.setPrev(curr);
    		curr.getNext().setPrev(newNode);
    		curr.setNext(newNode);
    		curr = newNode;
    	}
    }
    
    /**
     * Returns the current item.  If the Loop is empty, an 
     * EmptyLoopException is thrown.
     * 
     * @return the current item
     * @throws EmptyLoopException if the Loop is empty
     */
    public E getCurrent() {
    	if(curr == null) {
    		throw new EmptyLoopException();
    	}
		return curr.getData();
	}
    
    /**
     * Removes and returns the current item.  The item immediately 
     * after the removed item then becomes the  current item.  
     * If the Loop is empty initially, an EmptyLoopException 
     * is thrown.
     * 
     * @return the removed item
     * @throws EmptyLoopException if the Loop is empty
     */
    public E removeCurrent() {
    	if(curr == null) {
    		throw new EmptyLoopException();
    	}
    	if(curr.getNext() == null) {
    		curr = null;
    		return null;
    	}
    	DblListnode<E> newNode = curr;
    	curr.getPrev().setNext(curr.getNext());
    	curr.getNext().setPrev(curr.getPrev());
    	curr = curr.getNext();
		return newNode.getData();
	}
    
    /**
     * Advances the current item forward one item resulting in the item 
     * that is immediately after the current item becoming the  
     * current item.
     */
    public void forward() {
    	curr = curr.getNext();
	}
    
    /**
     * Moves the current item backwards one item resulting in the item 
     * that is immediately before the current item becoming the  
     * current item.
     */
    public void back() {
    	curr = curr.getPrev();
	}

    /**
     * Returns the number of items in this Loop.
     * @return the number of items in this Loop
     */
    public int size() {
    	if(curr == null) {
    		return 0;
    	}
    	int count = 1;
    	DblListnode<E> travNode = curr;
    	if(travNode.getNext() == null) {
    		return count;
    	}
    	while(travNode.getNext() != curr) {
    		count ++;
    		travNode = travNode.getNext();
    	}
		return count;
	}
    
    /**
     * Returns an iterator for this Loop.
     * Rather that using the Iterable interface we'll combine it with the ADT.
     * @return an iterator for this Loop
     */
    public Iterator<E> iterator() {
		return new MessageLoopIterator<E>(curr);
	}

}

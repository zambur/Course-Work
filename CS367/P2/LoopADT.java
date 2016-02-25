package com.zachambur;
import java.util.Iterator;

/**
 * A Loop ADT is a circular sequence of items.  A Loop has a current item 
 * and the ability to move forward or backwards.  A Loop can be modified by 
 * removing the current item or by adding an item either before or after the 
 * current item.
 */
public interface LoopADT<E> {
    
    /**
     * Adds the given item immediately before the current 
     * item.  After the new item has been added, the new item becomes the 
     * current item.
     * 
     * @param item - the item to add
     */
    void addBefore(E item);
    
    /**
     * Adds the given item immediately after the current 
     * item.  After the new item has been added, the new item becomes the 
     * current item.
     * 
     * @param item - the item to add
     */
    void addAfter(E item);
    
    /**
     * Returns the current item.  If the Loop is empty, an 
     * EmptyLoopException is thrown.
     * 
     * @return the current item
     * @throws EmptyLoopException if the Loop is empty
     */
    E getCurrent();
    
    /**
     * Removes and returns the current item.  The item immediately 
     * after the removed item then becomes the  current item.  
     * If the Loop is empty initially, an EmptyLoopException 
     * is thrown.
     * 
     * @return the removed item
     * @throws EmptyLoopException if the Loop is empty
     */
    E removeCurrent();
    
    /**
     * Advances the current item forward one item resulting in the item 
     * that is immediately after the current item becoming the  
     * current item.
     */
    void forward();
    
    /**
     * Moves the current item backwards one item resulting in the item 
     * that is immediately before the current item becoming the  
     * current item.
     */
    void back();

    /**
     * Returns the number of items in this Loop.
     * @return the number of items in this Loop
     */
    int size();
    
    /**
     * Returns an iterator for this Loop.
     * Rather that using the Iterable interface we'll combine it with the ADT.
     * @return an iterator for this Loop
     */
    Iterator<E> iterator();
}
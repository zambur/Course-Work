
public interface QueueADT<E> {
	/**
	 * Checks if the queue is empty.
	 * @return true if the queue is empty; otherwise false
	 */
	boolean isEmpty();
	
	/**
	 * Checks if the queue is full.
	 * @return true if the queue is full; otherwise false
	 */
	boolean isFull();
	
	/**
	 * Returns the front item of the queue without removing it.
	 * @return the front item of the queue
	 * @throws EmptyQueueException
	 */
	E peek() throws EmptyQueueException;
	
	/**
	 * Removes and returns the front item of the queue.
	 * 
	 * @return the first item in the queue
	 * @throws EmptyQueueException if the queue is empty
	 */
	E dequeue() throws EmptyQueueException;
	
	/**
	 * Inserts the item at the rear of the queue.
	 * 
	 * @param item The item to add to the queue.
	 * @throws FullQueueException if the queue is full
	 */
	void enqueue(E item) throws FullQueueException;
	
	/**
	 * Returns the number of items the queue can hold
	 * 
	 * @return the number of items the queue can hold
	 */
	int capacity();
	
	/**
	 * Returns the number of items in the queue
	 * 
	 * @return the number of items in the queue
	 */
	int size();
	
	/**
	 * Returns a string representation of the queue (for printing).
	 * 
	 * @return a string representation of the queue
	 */
	String toString();

}

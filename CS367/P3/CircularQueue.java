import java.util.ArrayList;

/**
 * The CircularQueue class that represents a circular ArrayList queue
 */
public class CircularQueue<E> implements QueueADT<E> {

	private int front;
	private int rear;
	private int arraySize;
	private ArrayList<E> circularArray;
	
    /**
     * The constructor of the CircularQueue() class, that initializes all private
     * variables to their respective starting values
     */
	public CircularQueue(int size) {
		front = -1;
		rear = 0;
		arraySize = size;
		circularArray = new ArrayList<E>();
	}
	
    /**
     * Checks if the queue is empty.
     * @return true if the queue is empty; otherwise false
     */
	@Override
	public boolean isEmpty() {
		if(front == -1) {
			return true;
		}
		else {
			return false;
		}
	}

    /**
     * Checks if the queue is full.
     * @return true if the queue is full; otherwise false
     */
    @Override
	public boolean isFull() {
		if(front == rear) {
			return true;
		}
		else {
			return false;
		}
	}

    /**
     * Returns the front item of the queue without removing it.
     * @return the front item of the queue
     * @throws EmptyQueueException
     */
	@Override
	public E peek() throws EmptyQueueException {
		if(front == -1) {
			throw new EmptyQueueException();
		}
		else {
			return circularArray.get(front);
		}
	}

    /**
     * Removes and returns the front item of the queue.
     *
     * @return the first item in the queue
     * @throws EmptyQueueException if the queue is empty
     */
	@Override
	public E dequeue() throws EmptyQueueException {
		if(front == -1) {
			throw new EmptyQueueException();
		}
		else {
			E tmp = circularArray.get(front);
			circularArray.remove(front);
			if(front == arraySize - 1) {
				front = 0;
			}
			else {
				front++;
			}
			if(front == rear) {
				front = -1;
				rear = 0;
			}
			return tmp;
		}
	}

    /**
     * Inserts the item at the rear of the queue.
     *
     * @param item The item to add to the queue.
     * @throws FullQueueException if the queue is full
     */
	@Override
	public void enqueue(E item) throws FullQueueException {
		if(front == rear) {
			throw new FullQueueException();
		}
		if(front == -1) {
			front = 0;
		}
		circularArray.add(rear, item);
		if(rear == arraySize - 1) {
			rear = 0;
		}
		else {
			rear++;
		}
		
	}

    /**
     * Returns the number of items the queue can hold
     *
     * @return the number of items the queue can hold
     */
	@Override
	public int capacity() {
		return arraySize;
	}

    /**
     * Returns the number of items in the queue
     *
     * @return the number of items in the queue
     */
	@Override
	public int size() {
		int numItems = 0;
		if(front == -1) {
			return 0;
		}
		else if(front == rear) {
			return arraySize;
		}
		else {
			for(int i = front; i != rear; i++) {
				numItems++;
				if(i == arraySize - 1) {
					i = 0;
				}
			}
			return numItems;
		}
	}
}

import java.util.Comparator;

///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Main Class File:  RealTimeScheduler.java
// File:             PriorityQueue.java
// Semester:         CS367 Spring 2014
//
// Author:           Zach Ambur
// Email:            zambur@wisc.edu
// CS Login:         zachary
// Lecturer's Name:  Jim Skrentny
// Lab Section:      none
//////////////////////////// 80 columns wide //////////////////////////////////


/**
 * The PriorityQueue class that represents a priority queue implemented as an
 * array based min-heap
 */
public class PriorityQueue<E> implements QueueADT<E> {
	
	private E[] pq;
	private int queueSize;
	private Comparator<E> queueComparator;
	private int nextLoc;
	
    /**
     * Creates a priority queue using the specified capacity.
     *
     * @param maxCapacity the integer representation of the max size
     * of the circular array queue
     */
	public PriorityQueue(Comparator<E> comparator, int maxCapacity) {
		queueSize = maxCapacity;
		queueComparator = comparator;
		nextLoc = 1;
		pq = (E[]) new Object[maxCapacity + 1];
	}
	
    /**
     * Checks if the priority queue is empty.
     * @return true if the priority queue is empty; otherwise false
     */
	@Override
	public boolean isEmpty() {
		if(pq[1] == null) {
			return true;
		}
		else {
			return false;
		}
	}

    /**
     * Checks if the priority queue is full.
     * @return true if the priority queue is full; otherwise false
     */
	@Override
	public boolean isFull() {
		if(pq[queueSize] == null) {
			return false;
		}
		else {
			return true;
		}
	}

    /**
     * Returns the item with the highest priority of the queue
     * @return the item with the highest priority of the queue
     * @throws EmptyQueueException
     */
	@Override
	public E peek() throws EmptyQueueException {
		if(pq[1] == null) {
			throw new EmptyQueueException();
		}
		else {
			return pq[1];
		}
	}

    /**
     * Removes and returns the front item of the queue. Then reorders the heap.
     *
     * @return the first item in the queue
     * @throws EmptyQueueException if the queue is empty
     */
	@Override
	public E dequeue() throws EmptyQueueException {
		if(pq[1] == null) {
			throw new EmptyQueueException();
		}
		else if(pq[2] == null) {
			E tmp = pq[1];
			pq[1] =null;
			nextLoc--;
			return tmp;
		}
		else {
			E tmp = pq[1];
			pq[1] = pq[nextLoc - 1];
			pq[nextLoc - 1] = null;
			nextLoc--;
			int curr = 1;
			boolean done = false;
			while(!done) {
				int checkPos = -1;
				if(curr != nextLoc -1) {
					checkPos = curr + 1;
					if(queueComparator.compare(pq[curr], pq[checkPos]) > 0) {
						E replace = pq[checkPos];
						pq[checkPos] = pq[curr];
						pq[curr] = replace;
						curr = checkPos;
					}
					else {
						done = true;
					}
				}
				else{
					done = true;
				}
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
		if(pq[queueSize] != null) {
			throw new FullQueueException();
		}
		if(nextLoc > queueSize) {
				throw new FullQueueException();
			}
		else {
			pq[nextLoc] = item;
			nextLoc++;
			int curr = nextLoc - 1;
			boolean done = false;
			while(!done) {
				int checkPos = curr - 1;
				if(curr - 1 == 0) {
					done = true;
				}
				else if(queueComparator.compare(pq[curr], pq[checkPos]) >= 0) {
					done = true;
				}
				else {
					E tmp = pq[checkPos];
					pq[checkPos] = pq[curr];
					pq[curr] = tmp;
					curr = checkPos;
				}
			}
		}
	}

    /**
     * Returns the number of items the queue can hold
     *
     * @return the number of items the queue can hold
     */

	@Override
	public int capacity() {
		return queueSize;
	}

    /**
     * Returns the number of items in the queue
     *
     * @return the number of items in the queue
     */
	@Override
	public int size() {
		if(nextLoc == 1) {
			return 0;
		}
		else {
			return nextLoc - 1;
		}
		
	}

}

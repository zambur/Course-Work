package com.zachambur;

/**
 * This class is thrown when an operation, mainly aimed at elements, is
 * performed on an empty loop.
 */
public class EmptyLoopException extends RuntimeException {
	
	public EmptyLoopException() {
		super();
	}
	
	public EmptyLoopException(String msg) {
		super(msg);
	}

}

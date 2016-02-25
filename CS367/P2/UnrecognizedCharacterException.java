package com.zachambur;

/**
 * This exception class is thrown if and only if the entered character is
 * invalid. By invalid, it means that the character is not in alphabet.txt
 */
public class UnrecognizedCharacterException extends RuntimeException {
	
	public UnrecognizedCharacterException() {
		super();
	}
	
	public UnrecognizedCharacterException(String msg) {
		super(msg);
	}

}

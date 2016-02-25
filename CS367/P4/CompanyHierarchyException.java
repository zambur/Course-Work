///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Main Class File:  CompanyHierarchyMain.java
// File:             CompanyHierarchyException.java
// Semester:         CS367 Spring 2014
//
// Author:           Zach Ambur
// Email:            zambur@wisc.edu
// CS Login:         zachary
// Lecturer's Name:  Jim Skrentny
//
//////////////////// PAIR PROGRAMMERS COMPLETE THIS SECTION ////////////////////
//                   CHECK ASSIGNMENT PAGE TO see IF PAIR-PROGRAMMING IS ALLOWED
//                   If allowed, learn what PAIR-PROGRAMMING IS, 
//                   choose a partner wisely, and complete this section.
//
// Pair Partner:     Griffin Lacek
// Email:            lacek@wisc.edu
// CS Login:         lacek
// Lecturer's Name:  Jim Skrentny
//
//////////////////////////// 80 columns wide //////////////////////////////////

public class CompanyHierarchyException extends RuntimeException {
	
	/**
	 * Is a basic custom exception that is throw in CompanyHierarchy and catch
	 * and dealt with in CompanyHierarchyMain.
	 *
	 */
	public CompanyHierarchyException() {
		super();
	}
	
	/**
	 * Is a custom exception that is throw in CompanyHierarchy with a message 
	 * with the specific exception that it broke and catch and dealt with 
	 * in CompanyHierarchyMain by displaying the message.
	 *
	 */
	public CompanyHierarchyException(String msg) {
		super(msg);
	}

}

///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Main Class File:  CompanyHierarchyMain.java
// File:             CompanyHierarchyMain.java
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

import java.text.ParseException;
import java.util.*;
import java.io.*;

/**
 * Creates a Company Hierarchy Tree which organizes the employees of a company
 * by their position in the company. It adds employees through a file that is
 * passed in through the command line arguments. It then prompts the user to 
 * edit this tree through a variety of inputs.
 * 
 * @author Griffin Lacek & Zach Ambur
 */
public class CompanyHierarchyMain {

    public static void main(String[] args) throws ParseException {
    	
    //Scanner to read file
    Scanner in = null;
    
    //Boolean to control user input loop
    boolean stop = false;
    
    //Create an empty tree
    CompanyHierarchy companyTree = new CompanyHierarchy();
    
	// *** Checks whether exactly one command-line argument is given ***
    if(args.length != 1) {
    	System.out.println("Usage: java CompanyHierarchyMain FileName");
    	System.exit(1);
    }  
	// *** Checks whether the input file exists and is readable ***
    File inFile = new File(args[0]);
    if (!inFile.exists() || !inFile.canRead()) {
        System.err.println("Error: Cannot access input file");
        System.exit(1);
     }

	/* Loads the data from the input file and use it to 
	 *  construct an company tree. Note: employees are to be added to the 
	 *  company tree in the order in which they appear in the text file. 
	 */
    try {
    	in = new Scanner(inFile);
    } 
    catch (FileNotFoundException e) {
           System.err.println("Problem with input file!");
           System.exit(1);
       }
    
    while(in.hasNextLine()) {
    	// Splits up the contents of each employee 
    	String employee = in.nextLine();
    	String [] employeeInfo = employee.split("\\s*,\\s*");
    	
    	String name = employeeInfo[0];
    	int id = Integer.parseInt(employeeInfo[1]);
    	String joiningDate = employeeInfo[2];
    	String title = employeeInfo[3];
    	
    	if(employeeInfo.length < 5) {
    		//Create new employee object
        	Employee newEmployee = new Employee(name, id, joiningDate, title);
        	//Add created employee to company tree
        	companyTree.addEmployee(newEmployee, 1, null);
    	}
    	else {
    		String managerName = employeeInfo[4];
    		int managerId = Integer.parseInt(employeeInfo[5]);
        	
        	
        	//Create new employee object
        	Employee newEmployee = new Employee(name, id, joiningDate, title);
        	//Add created employee to company tree
        	companyTree.addEmployee(newEmployee, managerId, managerName);
    	}	
    }
    // Creates a scanner to read user input
    in = new Scanner(System.in);
	/* Prompts the user to enter command options and 
	 *  process them until the user types x for exit. 
	 */
	while (!stop) {
		/* Checks the user input and splits it up for each command and anything
		 * they have after will be stored in a string to later be split up
		 */
        System.out.println("\nEnter Command: ");
	    String input = in.nextLine();
	    String remainder = null;
	    if (input.length() > 0) {
		char option = input.charAt(0);
		if (input.length() > 1) {
		    remainder = input.substring(1).trim();
		}

		switch (option) {
		/* Add a new employee with given details to the company tree. Also 
		 * checks to see if the information given is correct and will catch
		 * any CompanyHierarchyExceptions that are throw from this call
		 */
		case 'a':{
			// Checks to make sure there is a remainder
			if(remainder == null) {
				System.out.println("invalid command");
				break;
			}
			if(remainder.equals("")) {
				System.out.println("invalid command");
				break;
			}
			// Splits up the contents of the remainder
			String[] contents = remainder.split("\\s*,\\s*");
			int id = Integer.parseInt(contents[0]);
			String name = contents[1];
			String dateOfJoining = contents[2];
			String title = contents[3];
			int supervisorId = Integer.parseInt(contents[4]);
			String supervisorName = contents[5];
			Employee newEmployee = new Employee(name, id, dateOfJoining, title);
			boolean checkAdd = false;
			// Adds the employee to the tree if possible
			try {
				checkAdd = companyTree.addEmployee(newEmployee, supervisorId, 
						supervisorName);
			}
			catch(CompanyHierarchyException exception) {
				System.out.println(exception.getMessage());
				break;
			}
			if(checkAdd == true) {
				System.out.println("Employee added");
			}
			else {
				System.out.println
				("Cannot add employee as supervisor was not found!");
			}
			break;
		}

		/* Print the names of the co-workers of the employee with given id 
		 * and name. Also checks to see if the information given is correct and 
		 * will catch any CompanyHierarchyExceptions that are throw from this 
		 * call.
		 */
		case 'c':{
			// Checks to make sure there is a remainder
			if(remainder == null) {
				System.out.println("invalid command");
				break;
			}
			if(remainder.equals("")) {
				System.out.println("invalid command");
				break;
			}
			// Splits up the remainder
			String[] contents = remainder.split("\\s*,\\s*");
			int id = Integer.parseInt(contents[0]);
			String name = contents[1];
			List<Employee> coworkers = null;
			// Gets a list of co-workers, if possible
			try {
				coworkers = companyTree.getCoWorkers(id, name);
			}
			catch(CompanyHierarchyException exception) {
				System.out.println(exception.getMessage());
				break;
			}
			if(coworkers == null) {
				System.out.println("Employee not found!");
				break;
			}
			if(coworkers.isEmpty()) {
				System.out.println("The employee has no co-workers.");
				break;
			}
			// Prints the names of the co-workers on separate lines
			Iterator<Employee> itr = coworkers.iterator();
			while(itr.hasNext()) {
				System.out.println(itr.next().getName());
			}
		    break;
		}
		
		/* Display information about the company tree such as the number of 
		 * employees in the company tree, the max levels of the tree, and 
		 * the name of the CEO of the company.
		 */
		case 'd':{
			if(remainder != null) {
				System.out.println("invalid command");
				break;
			}
			System.out.println("# of employees in company tree: " 
					+ companyTree.getNumEmployees());
			System.out.println("max levels in company tree: " 
					+ companyTree.getMaxLevels());
			System.out.println("CEO: " + companyTree.getCEO());
		    break;
		}

		// Print the names of the employees that has the given title.
		case 'e':{
			// Checks to make sure there was a title given
			if(remainder == null) {
				System.out.println("invalid command");
				break;
			}
			if(remainder.equals("")) {
				System.out.println("invalid command");
				break;
			}
			// Gets list of employees with the same title
			List<Employee> employeeList = 
					companyTree.getEmployeeWithTitle(remainder);
			if(employeeList.isEmpty()) {
				System.out.println("Employee not found!");
				break;
			}
			// Prints the names of the employees on separate lines
			Iterator<Employee> itr = employeeList.iterator();
			while(itr.hasNext()) {
				System.out.println(itr.next().getName());
			}
		    break;
		}

		/* Removes the employee with given id and name from the company tree 
		 * and re-assign the worker's to the removed employee's supervisor. 
		 */
		case 'r':{
			// Checks to make sure there is a remainder
			if(remainder == null) {
				System.out.println("invalid command");
				break;
			}
			if(remainder.equals("")) {
				System.out.println("invalid command");
				break;
			}
			// Splits up the contents of the remainder
			String[] contents = remainder.split("\\s*,\\s*");
			int id = Integer.parseInt(contents[0]);
			String name = contents[1];
			boolean checkRemove = false;
			// Removes the employee from the tree, if possible
			try {
				checkRemove = companyTree.removeEmployee(id, name);
			}
			catch(CompanyHierarchyException exception) {
				System.out.println(exception.getMessage());
				break;
			}
			if(checkRemove == true) {
				System.out.println("Employee removed");
				break;
			}
			else {
				System.out.println("Employee not found!");
			}
		    break;
		}

		/*
		 * Print the name(s) of all the supervisors in the supervisor chain of 
		 * the given employee.
		 */
		case 's':{
			// Checks to make sure there is a remainder
			if(remainder == null) {
				System.out.println("invalid command");
				break;
			}
			if(remainder.equals("")) {
				System.out.println("invalid command");
				break;
			}
			// Splits up the contents of the remainder
			String[] contents = remainder.split("\\s*,\\s*");
			int id = Integer.parseInt(contents[0]);
			String name = contents[1];
			List<Employee> supervisorChain = null;
			// Gets a list of supervisors, if possible
			try {
				supervisorChain = companyTree.getSupervisorChain(id, name);
			}
			catch(CompanyHierarchyException exception) {
				System.out.println(exception.getMessage());
				break;
			}
			if(supervisorChain == null) {
				System.out.println("Employee not found!");
				break;
			}
			else {
				// Prints the names of the supervisors on separate lines
				Iterator<Employee> itr = supervisorChain.iterator();
				while(itr.hasNext()) {
					System.out.println(itr.next().getName());
				}
			}
		    break;
		}

		/* Updates the employee with given id and name by replacing with 
		 * the provided employee details.
		 */
		case 'u':{
			// Checks to make sure there is a remainder
			if(remainder == null) {
				System.out.println("invalid command");
				break;
			}
			if(remainder.equals("")) {
				System.out.println("invalid command");
				break;
			}
			// Splits up the contents of the remainder
			String[] contents = remainder.split("\\s*,\\s*");
			int id = Integer.parseInt(contents[0]);
			String name = contents[1];
			int newid = Integer.parseInt(contents[2]);
			String newname = contents[3];
			String dateOfJoining = contents[4];
			String title = contents[5];
			Employee newEmployee = new Employee(newname, newid, dateOfJoining, 
					title);
			boolean checkUpdate = false;
			// Updates the employee if possible
			try {
				checkUpdate = companyTree.replaceEmployee(id, name, 
						newEmployee);
			}
			catch(CompanyHierarchyException exception) {
				System.out.println(exception.getMessage());
				break;
			}
			if(checkUpdate == true) {
				System.out.println("Employee replaced");
				break;
			}
			else {
				System.out.println("Employee not found!");
			}
		    break;
		}

		/* Print the names of the employees whose date of joining are 
		 * between startDate and endDate given by the user
		 */
		case 'j':{
			// Checks to make sure the user gave start and end dates
			if(remainder == null) {
				System.out.println("invalid command");
				break;
			}
			if(remainder.equals("")) {
				System.out.println("invalid command");
				break;
			}
			// Splits up the remainder into 2 different dates
			String[] contents = remainder.split("\\s*,\\s*");
			String startDate = contents[0];
			String endDate = contents[1];
			List<Employee> employeeList = null;
			// Gets a list of employees, if possible
			try {
				employeeList = companyTree.getEmployeeInJoiningDateRange
						(startDate, endDate);
			}
			catch(CompanyHierarchyException exception) {
				System.out.println(exception.getMessage());
				break;
			}
			if(employeeList.isEmpty()) {
				System.out.println("Employee not found!");
				break;
			}
			else {
				// Prints the names of the employees on separate lines
				Iterator<Employee> itr = employeeList.iterator();
				while(itr.hasNext()) {
					System.out.println(itr.next().getName());
				}
			}
			break;
		}

		//Exits program
		case 'x':{
			stop = true;
			System.out.println("exit");
			break;
		}
		default:
			break;
		}
	   }
	}
	in.close();
   }
    
}

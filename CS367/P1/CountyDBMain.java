///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Title:            p1
// Files:            CountyDBMain.java, CountyDatabase.java, Storm.java, County.java
// Semester:         CS367 Spring 2014
//
// Author:           Zach Ambur
// Email:            zambur@wisc.edu
// CS Login:         zachary
// Lecturer's Name:  Lecture 2 Jim Skrentny
//
//////////////////// PAIR PROGRAMMERS COMPLETE THIS SECTION ////////////////////
//
// Pair Partner:     Griffin Lacek
// Email:            lacek@wisc.edu
// CS Login:         lacek
// Lecturer's Name:  Lecture 2 Jim Skrentny
//
//                   STUDENTS WHO GET HELP FROM ANYONE OTHER THAN THEIR PARTNER
// Credits:          none
//////////////////////////// 80 columns wide //////////////////////////////////
import java.util.*;
import java.io.*;

/**
 * CountyDBMain class creates and uses a CountyDatabase to represent and process 
 * information about counties and storms. It creates a file from the command-line
 * arguments and then creates counties and storms that are in the file.  This
 * class also takes in user input and then displays different information to the 
 * user depending on what they ask for.  The user can also edit the county database
 * by removing counties.
 *
 * <p>Bugs: none
 *
 * @author Zach Ambur & Griffin Lacek
 */
public class CountyDBMain {

	public static void main(String[] args) {
		
		List<Storm> stormList;  // declares a temporary list to hold Storms in
		List<Storm> stormList2; // declares a temporary list to hold Storms in
		
		boolean stop = false; // controls if the while loop for user input 
		                     // should continue, closes while loop when true.
		
		// checks whether exactly one command-line argument is given
		 if(args.length != 1) {
			System.out.println("Usage: java CountyDBMain FileName");
			System.exit(1);
		} 
        // checks whether the input file exists and is readable
		 // creates a file based on the command-line argument
		File f = new File(args[0]); 
		// declares a scanner to read the contents of the file
		Scanner in = null; 
		try {
			in = new Scanner(f);
		}
		catch (FileNotFoundException e) { // catch error if file was not found
			// displays error message
			System.out.println("Error: Cannot access input file"); 
			System.exit(1); // quits program
		}

        // Loads the data from the input file and use it to 
		//  construct a county database. 
		CountyDatabase cDatabase = new CountyDatabase();
		while(in.hasNext()) {
			String line = in.nextLine();
			String[] contents = line.split(","); // splits contents by ;
			String countyName = contents[0].trim();
			if(!cDatabase.containsCounty(countyName)) {
				cDatabase.addCounty(countyName); // adds county to the database
			}
			// adds storm to the correct county
			cDatabase.addStorm(new Storm(contents[1], contents[2], 
					Integer.parseInt(contents[3])), countyName);
		}

		// prompts the user to enter command options and 
		//  process them until the user types x for exit. 
		  // creates new scanner to read user input
		Scanner stdin = new Scanner(System.in); 
        while (!stop) { // continue until stop is true
            System.out.println("Enter Options");
            String input = stdin.nextLine();
            String remainder = null;
            if (input.length() > 0) {
            	// creates char varible for users first entry
                char option = input.charAt(0); 
            // if user enters in another entry, creates a string of that entry
                if (input.length() > 1) {
                    remainder = input.substring(1).trim();
                }

                switch (option) {

                case 'a':{
                	/* print the names and dates of all storms with damage amount 
                	 * inputted by user on separate lines. If no storms have 
                	 * that amount, display "no storms found".
                	 */
                	// if incorrect input, displays error message
                	if(remainder == null) { 
                		System.out.println("invalid input");
                	}
                	else {
                		// gets a list of storms with corresponding amount
                		stormList = cDatabase.getStormsWithDamageAmount
                				(Integer.parseInt(remainder));
                		if(stormList != null) {
                			// creates an iterator to go through the storm list
                			Iterator<Storm> stormIterator 
                				= stormList.iterator();
                			while(stormIterator.hasNext()) {
                				Storm newStorm = stormIterator.next();
                				// prints storms name and date
                				System.out.println(newStorm.getName() 
                						+ ", " + newStorm.getDate());
                			}
                		}
                		else {
                			// if no storms found prints this message
                			System.out.println("no storms found");
                		}
                	}
                	System.out.println();
                    break;
                }
                
                case 'c':{
                	/* Displays each storm with date in the county with the 
                	 * name that the user inputs, if it is not in the 
                	 * database it displays "county not found".
                	 */
                	// if incorrect input, displays error message
                	if(remainder == null) {
                		System.out.println("invalid input");
                	}
                	else {
                		// gets a list of storms from corresponding county
                		stormList = cDatabase.getStormsFromCounty(remainder);
                		if(stormList != null) {
                			// creates an iterator to go through the storm list
                			Iterator<Storm> stormIterator 
                				= stormList.iterator();
                			while(stormIterator.hasNext()) {
                				Storm newStorm = stormIterator.next();
                				// prints storms name, date, and damage amount
                				System.out.println(newStorm.getName() 
                						+ ", " + newStorm.getDate()
                						+ ", " + newStorm.getDamageAmount());
                			}
                		}
                		else {
                			// if no storms found prints this message
                			System.out.println("county not found");
                		}
                	}
                	System.out.println();
                    break;
                }
                
                case 'd':{
                	/* display the storm name(s), and damage amount(s) for 
                	 * each storm that occurred on the given date 
                	 * provided by the user
                	 */
                	// if incorrect input, displays error message
                	if(remainder == null) {
                		System.out.println("invalid input");
                	}
                	else {
                		// gets list of storms with corresponding date
                		stormList = cDatabase.getStormsWithDate(remainder);
                		if(stormList != null) {
                			// creates an iterator to go through the storm list
                			Iterator<Storm> stormIterator 
                				= stormList.iterator();
                			while(stormIterator.hasNext()) {
                				Storm newStorm = stormIterator.next();
                				// prints storms name and damage amount
                				System.out.println(newStorm.getName() 
                						+ ", " + newStorm.getDamageAmount());
                			}
                		}
                		else {
                			// if no storms found prints this message
                			System.out.println("storm not found");
                		}
                	}
                	System.out.println();
                	break;
                }

                case 'i':{
                	/* Displays the total number of storms and counties, 
                	 * as well as the number of storms in the county with the
                	 * most storms, least storms, and then displays the average 
                	 * number of storms in each county. Also displays the percent
                	 * of storms in the database with damage of 0. Then finally 
                	 * displays the name, date, and damage amount of the three
                	 * storms that caused the most expensive damage 
                	 * 
                	 */
                	// creates a county iterator to go through the database
                	Iterator<County> countyIterator = cDatabase.iterator();
                	int cCounty = 0; // total count of all counties
                	int cStorm = 0; // total count of all the storms
                	// number of storms in the county which contains the most storms
                	int mostStorms = 0;
                	// number of storms in the county which contains the least storms
                	int leastStorms = 100;
                	while(countyIterator.hasNext()) {
                		County currCounty = countyIterator.next();
                		stormList = currCounty.getStorms();
                		cStorm = cStorm + stormList.size();
                		if(stormList.size() > mostStorms) {
                			mostStorms = stormList.size();
                		}
                		else if(stormList.size() < leastStorms) {
                			leastStorms = stormList.size();
                		}
                		cCounty++;
                	}
                	int averageStorms = cStorm / cCounty;
                	System.out.println("Storms: " + cStorm + ", " 
                			+ "Counties: " + cCounty);
                	System.out.println("# of storms/county: most " 
                			+ mostStorms + ", least " 
                			+ leastStorms + ", average " + averageStorms);
                	System.out.println("% of storms that have a "
                			+ "damage amount of 0: " 
                			+ cDatabase.getPercentageOfStormsNoDamage());
                	cDatabase.printThreeMostExpensiveStorms();
                	System.out.println();
                    break;
                }

                case 'r':{
                	/* removes the county with the given name provided 
                	 * by the user from the database
                	 */
                	// if incorrect input, displays error message
                	if(remainder == null) {
                		System.out.println("invalid input");
                	}
                	else {
                		if(cDatabase.containsCounty(remainder)) {
                			// removes county from database
                			cDatabase.removeCounty(remainder);
                			System.out.println("county removed");
                		}
                		else {
                			System.out.println("county not found");
                		}
                	}
                	System.out.println();
                    break;
                }
                
                case 's':{
                	/* Searches through the database for the two counties
                	 * provided by the user and then compares the counties
                	 * by total damage amount from storms. Will display 
                	 * either "same damage amount" or "different damage
                	 * amount"
                	 */
                	// if incorrect input, displays error message
                	if(remainder == null || !remainder.contains(";")) {
                		System.out.println("invalid input");
                	}
                	else {
                		String[] counties = remainder.split(";");
                		int totalDamage1 = 0;
                		int totalDamage2 = 0;
                		if(cDatabase.containsCounty(counties[0]) 
                				&& cDatabase.containsCounty(counties[1])) {
                			stormList = cDatabase.getStormsFromCounty
                					(counties[0]);
                			Iterator<Storm> stormIterator 
                				= stormList.iterator();
                			while(stormIterator.hasNext()) {
                				Storm newStorm = stormIterator.next();
                				totalDamage1 += newStorm.getDamageAmount();
                			}
                			stormList2 = cDatabase.getStormsFromCounty
                					(counties[1]);
                			Iterator<Storm> stormIterator2 
                				= stormList2.iterator();
                			while(stormIterator2.hasNext()) {
                				Storm newStorm = stormIterator2.next();
                				totalDamage2 += newStorm.getDamageAmount();
                			}
                			if(totalDamage1 == totalDamage2) {
                				System.out.println("same damage amount");
                			}
                			else if(totalDamage1 != totalDamage2) {
                				System.out.println("different damage amounts");
                			}
                		}
                		else{
                			System.out.println("counties are not valid");
                		}
                	}
                	System.out.println();
                	break;
                }

                case 'w':{
                	/* Displays the average damage amount for all storms that
                	 * match the storm that the user enters
                	 * 
                	 */
                	// if incorrect input, displays error message
                	if(remainder == null) {
                		System.out.println("invalid input");
                	}
                	else {
                		stormList = cDatabase.getStormsWithName(remainder);
                		if(stormList != null) {
                			int totalAmount = 0;
                			int stormCount = 0;
                			Iterator<Storm> stormIterator 
                				= stormList.iterator();
                			while(stormIterator.hasNext()) {
                				Storm storm = stormIterator.next();
                				totalAmount = totalAmount 
                						+ storm.getDamageAmount();
                				stormCount++;
                			}
                			double average = totalAmount / stormCount;
                			System.out.println("average damage amount: " 
                					+ average);
                		}
                		else {
                			System.out.println("no storms found");
                		}
                	}
                	System.out.println();
                	break;
                }

                //***exits program***
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
        stdin.close(); // closes scanner
    }
}
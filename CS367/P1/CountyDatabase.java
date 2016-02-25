///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Main Class File:  CountyDBMain.java
// File:             CountyDatabase.java
// Semester:         CS367 Spring 2014
//
// Author:           Zach Ambur
// CS Login:         zachary
// Lecturer's Name:  Lecture 2 Jim Skrentny
//
//////////////////// PAIR PROGRAMMERS COMPLETE THIS SECTION ////////////////////
//
// Pair Partner:     Griffin Lacek
// CS Login:         lacek
// Lecturer's Name:  Lecture 2 Jim Skrentny
//
//                   STUDENTS WHO GET HELP FROM ANYONE OTHER THAN THEIR PARTNER
// Credits:          none
//////////////////////////// 80 columns wide //////////////////////////////////
import java.util.Iterator;
import java.util.List;
import java.util.ArrayList;
import java.lang.IllegalArgumentException;

/**
 * The County Databae class keeps a complete list of all of the counties entered.
 * It also contains methods to be called from the main class on different ways
 * to sort these counties and their storms. Methods also include ways to remove
 * counties as a whole and also storms in the different counties.
 *
 * <p>Bugs: none
 *
 * @author Zach Ambur & Griffin Lacek
 */
public class CountyDatabase {
	
	// declares the database that will hold all the counties
	ArrayList<County> countyContainer;
	// declares a temporary list of storms to use throughout this class
	ArrayList<Storm> stormContainer; 
	Iterator<County> countyIterator; // declares a county iterator
	Iterator<Storm> stormIterator; // declares a storm iterator
	double noDamageStorms; // number of storms that caused no damage
	double DamageStorms; // number of storms that caused damage
	// a list of the three storms that caused the most damage
	ArrayList<Storm> topStormDamage = new ArrayList<Storm>();
	int oneDamage = 0; // storm with the most damage
	int twoDamage = 0; // storm with the second most damage
	int threeDamage = 0; // storm with the third most damage
	
	// County Database constructor that creates an empty
	//  list of all the counties
	public CountyDatabase() {
		countyContainer = new ArrayList<County>();
	}
	
	/**
	 * addCounty method creates a new county and adds it to the
	 * database of counties, if the county is already in the 
	 * database it does nothing and just returns.
	 *
	 * @param name String of the name of the county
	 * @return void
	 */
	void addCounty(String name) throws IllegalArgumentException {
		if(name == null) {
			System.out.println("invalid input");
		}
		else {
			if(countyContainer.isEmpty()) {
				countyContainer.add(new County(name));
			}
			else {
				int count = 0;
				countyIterator = countyContainer.iterator();
				while(countyIterator.hasNext()) {
					County currCounty = countyIterator.next();
					if(currCounty.getName().equals(name)) {
						count++;
					}
				}
				if(count == 0) {
					countyContainer.add(new County(name));
				}
			}
		}
	}
	
	/**
	 * addStorm method adds the storm that is passed, into 
	 * the corresponding county that is also passed in.
	 *
	 * @param storm Storm that will be added to the county
	 * @param county String of the county name
	 * @return void
	 */
	void addStorm(Storm storm, String county) 
			throws IllegalArgumentException {
		if(storm == null || county == null) {
			System.out.println("invaid input");
		}
		else {
			countyIterator = countyContainer.iterator();
			while(countyIterator.hasNext()) {
				County currCounty = countyIterator.next();
				if(currCounty.getName().equals(county)) {
					currCounty.getStorms().add(storm);
				}
			}	
		}
	}
	
	/**
	 * containsCounty method checks to see if the county is in the
	 * county database
	 *
	 * @param county String of the county name
	 * @return true if the county is in the county database
	 */
	boolean containsCounty(String county) throws IllegalArgumentException {
		if(county == null) {
			System.out.println("invalid input");
			return false;
		}
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			if(countyIterator.next().getName().equals(county)) {
				return true;
			}
		}
		return false;
	}
	
	/**
	 * containsStorm method checks to see if the storm is in any
	 * of the counties in the database
	 *
	 * @param storm Storm to be checked
	 * @return true if the storm is in a county
	 */
	boolean containsStorm(String storm) throws IllegalArgumentException {
		if(storm == null) {
			System.out.println("invalid input");
			return false;
		}
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			stormIterator = currCounty.getStorms().iterator();
			while(stormIterator.hasNext()) {
				if(stormIterator.next().equals(storm))
					return true;
			}
		}
		return false;
	}
	
	/**
	 * hasStorm method checks to see if the given storm
	 * is in the given county
	 *
	 * @param storm Storm to be checked
	 * @param county String of the county name
	 * @return true if the storm is in the county
	 */
	boolean hasStorm(String storm, String county) 
			throws IllegalArgumentException {
		if(storm == null || county == null) {
			System.out.println("invalid input");
			return false;
		}
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			if(currCounty.getName().equals(county)) {
				stormIterator = currCounty.getStorms().iterator();
				while(stormIterator.hasNext()) {
					if(stormIterator.next().getName().equals(storm)) {
						return true;
					}
				}
			}
			else return false;
		}
		return false;
	}

	/**
	 * getStormsWithDamageAmount method creates a list
	 * of storms with the given damage amounts
	 *
	 * @param amount An Integer of the damage amount
	 * @return List<Storm> containing the storms with the given
	 * damage amount
	 */
	List<Storm> getStormsWithDamageAmount(Integer amount) 
			throws IllegalArgumentException {
		if(amount == null) {
			System.out.println("invalid input");
			return null;
		}
		stormContainer = new ArrayList<Storm>();
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			stormIterator = currCounty.getStorms().iterator();
			while(stormIterator.hasNext()) {
				Storm currStorm = stormIterator.next();
				int stormDamage = currStorm.getDamageAmount();
				if(stormDamage == amount) {
					stormContainer.add(currStorm);
				}
			}
		}
		if(stormContainer.size() < 1) {
			return null;
		}
		return stormContainer;
	}

	/**
	 * getStormsWithDate method creates a list of
	 * storms with the given date
	 *
	 * @param date String of the date of storms
	 * @return List<Storm> containing storms with the
	 * given date
	 */
	List<Storm> getStormsWithDate(String date) 
			throws IllegalArgumentException {
		if(date == null) {
			System.out.println("invalid input");
			return null;
		}
		stormContainer = new ArrayList<Storm>();
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			stormIterator = currCounty.getStorms().iterator();
			while(stormIterator.hasNext()) {
				Storm currStorm = stormIterator.next();
				if(currStorm.getDate().equals(date)) {
					stormContainer.add(currStorm);
				}
			}
		}
		if(stormContainer.size() < 1) {
			return null;
		}
		return stormContainer;
	}
	
	/**
	 * getStormsWithName method creates a list of
	 * storms with the given name
	 *
	 * @param name String of the name of the storm
	 * @return List<Storm> containing the storms with 
	 * the given name
	 */
	List<Storm> getStormsWithName(String name) 
			throws IllegalArgumentException {
		if(name == null) {
			System.out.println("invalid input");
			return null;
		}
		stormContainer = new ArrayList<Storm>();
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			stormIterator = currCounty.getStorms().iterator();
			while(stormIterator.hasNext()) {
				Storm currStorm = stormIterator.next();
				if(currStorm.getName().equals(name)) {
					stormContainer.add(currStorm);
				}
			}
		}
		if(stormContainer.size() < 1) {
			return null;
		}
		return stormContainer;
	}
	
	/**
	 * getStormsFromCounty method creates a list of
	 * storms in the given county
	 *
	 * @param county Sting of county name
	 * @return List<Storm> containing all the storms
	 * in the given county
	 */
	List<Storm> getStormsFromCounty(String county) 
			throws IllegalArgumentException {
		if(county == null) {
			System.out.println("invalid input");
			return null;
		}
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			if(currCounty.getName().equals(county)) {
				return currCounty.getStorms();
			}
		}
		return null;
	}
	
	/**
	 * getPercentageOfStroms method gets the percentage 
	 * of storms in the database that have a damage 
	 * amount of 0.
	 *
	 * @return double percentage of storms
	 */
	double getPercentageOfStormsNoDamage() {
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			stormIterator = currCounty.getStorms().iterator();
			while(stormIterator.hasNext()) {
				Storm currStorm = stormIterator.next();
				if(currStorm.getDamageAmount() == 0) {
					noDamageStorms++;
				}
				else {
					DamageStorms++;
				}
			}
		}
		double stormPerc = (noDamageStorms / 
				(DamageStorms + noDamageStorms)) * 100;
		noDamageStorms = 0;
		DamageStorms = 0;
		return stormPerc;
	}
	
	/**
	 * iterator method creates an Iterator over the 
	 * County objects in the database.
	 *
	 * @return Iterator<County> of the County objects in the database.
	 */
	Iterator<County> iterator() {
		Iterator<County> cIterator = countyContainer.iterator();
		return cIterator;
	}
	
	/**
	 * printThreeMostExpensiveStorms method Print the names, 
	 * dates, and damage amounts of the three storms that 
	 * have the largest damage amounts, in descending order
	 *
	 * @return void
	 */
	void printThreeMostExpensiveStorms() {
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			stormIterator = currCounty.getStorms().iterator();
			while(stormIterator.hasNext()) {
				Storm currStorm = stormIterator.next();
				if(currStorm.getDamageAmount() >= oneDamage) {
					twoDamage = oneDamage;
					oneDamage = currStorm.getDamageAmount();
					topStormDamage.add(0, currStorm);
					if(topStormDamage.size() >= 4) {
						topStormDamage.remove(3);
					}
				}
				else if(currStorm.getDamageAmount() >= twoDamage) {
					threeDamage = twoDamage;
					twoDamage = currStorm.getDamageAmount();
					topStormDamage.add(1, currStorm);
					if(topStormDamage.size() >= 4) {
						topStormDamage.remove(3);
					}
				}
				else if(currStorm.getDamageAmount() >= threeDamage) {
					threeDamage = currStorm.getDamageAmount();
					topStormDamage.add(2, currStorm);
					if(topStormDamage.size() >= 3) {
						topStormDamage.remove(3);
					}
				}
			}
		}
		stormIterator = topStormDamage.iterator();
		while(stormIterator.hasNext()) {
			Storm currStorm = stormIterator.next();
			System.out.println(currStorm.getName() + ", " 
					+ currStorm.getDate() + ", " 
					+ currStorm.getDamageAmount());
		}
		oneDamage = 0;
		twoDamage = 0;
		threeDamage = 0;
	}
	
	/**
	 * removeCounty method removes the given county
	 * form the county database
	 *
	 * @param county String of county name
	 * @return true if county was successfully removed
	 */
	boolean removeCounty(String county) throws IllegalArgumentException {
		if(county == null) {
			System.out.println("invalid input");
			return false;
		}
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			if(currCounty.getName().equals(county)) {
				return countyContainer.remove(currCounty);
			}
		}
		return false;
	}
	
	/**
	 * removeStormsWithName method removes all storms
	 * with the given name.
	 *
	 * @param storm String of storm name
	 * @return true if any storms were removed successfully
	 */
	boolean removeStormsWithName(String storm) 
			throws IllegalArgumentException {
		if(storm == null) {
			System.out.println("invalid input");
			return false;
		}
		int count = 0;
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			stormIterator = currCounty.getStorms().iterator();
			while(stormIterator.hasNext()) {
				Storm currStorm = stormIterator.next();
				if(currStorm.getName().equals(storm)) {
					currCounty.getStorms().remove(currStorm);
					count++;
				}
			}
		}
		if(count > 0) {
			return true;
		}
		return false;
	}
	
	/**
	 * removeStormsWithDamageAmount method removes all
	 * storms with the given damage amount
	 *
	 * @param damage Integer with the damage amount
	 * @return true if any storms were successfully removed
	 */
	boolean removeStormsWithDamageAmount(Integer damage) 
			throws IllegalArgumentException {
		if(damage == null) {
			System.out.println("invalid input");
			return false;
		}
		int count = 0;
		countyIterator = countyContainer.iterator();
		while(countyIterator.hasNext()) {
			County currCounty = countyIterator.next();
			stormIterator = currCounty.getStorms().iterator();
			while(stormIterator.hasNext()) {
				Storm currStorm = stormIterator.next();
				if(currStorm.getDamageAmount() == damage) {
					currCounty.getStorms().remove(currStorm);
					count++;
				}
			}
		}
		if(count > 0) {
			return true;
		}
		return false;
	}
	
	/**
	 * size method gets and returns the amount of counties that
	 * are in the county database
	 *
	 * @return the number of counties in the database as an integer
	 */
	int size() {
		int count = countyContainer.size();
		return count;
	}
}
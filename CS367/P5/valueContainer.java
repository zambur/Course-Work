///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Main Class File:  LoadBalancerMain.java
// File:             valueContainer.java
// Semester:         CS367 Spring 2014
//
// Author:           Griffin Lacek
// CS Login:         lacek
// Lecturer's Name:  Jim Skrentny
//
//////////////////// PAIR PROGRAMMERS COMPLETE THIS SECTION ////////////////////
//
// Pair Partner:     Zach Ambur
// CS Login:         zachary
// Lecturer's Name:  Jim Skrentny
//
//////////////////////////// 80 columns wide //////////////////////////////////

/**
 * This class holds the information that is in the value V reference in the 
 * hashMap. Each value contains an IP address along with a access time. The 
 * access time is the timestep at which this value was added to the hashMap.
 *
 * @author Griffin Lacek and Zach Ambur
 */
public class valueContainer {

	int ipAddress;
	long accessTime;
	
	/**
     * Constructs the value entry with the specified ip address and access time.
     */
	public valueContainer(int ip, long access) {
		ipAddress = ip;
		accessTime = access;
	}
	
	/**
	 * Returns the ip address that corresponds to the related value.
	 * @return The ip address
	 */
	public int getIp() {
		return ipAddress;
	}
	
	/**
	 * This takes in a new long variable and replaces the old access time of
	 * the value and updates its access time with the variable passed in.
	 *
	 * @param access A new access time
	 */
	public void setAccess(long access) {
		accessTime = access;
	}
	
	/**
	 * Returns the access time that corresponds to the related value.
	 * @return The access time
	 */
	public long getAccess() {
		return accessTime;
	}
}

/****************************************************************
 * Utility.java
 * Do not modify this file!
 * This file is a utility class. You do not need to read or understand this class.
 * -----------------------------------------------------------------------------------------------------------------
 * Licensing Information: You are free to use or extend these projects for educational purposes provided that
 * (1) you do not distribute or publish solutions, (2) you retain the notice, and (3) you provide clear attribution to UW-Madison
 * 
 * Attribute Information: The Mancala Game was developed at UW-Madison.
 * 
 * The initial project was developed by Chuck Dyer(dyer@cs.wisc.edu) and his TAs.
 * 
 * Current Version with GUI was developed by Fengan Li(fengan@cs.wisc.edu).
 * Some GUI componets are from Mancala Project in Google code.
 */
public class Utility 
{
	public static void tSleep(int sleepTime)
	{
		try 
    	{
    	    Thread.sleep(sleepTime);                 
    	} catch(InterruptedException ex) 
    	{
    	    Thread.currentThread().interrupt();
    	}
	}

}

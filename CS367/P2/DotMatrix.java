package com.zachambur;
import java.io.*;
import java.util.*;

/**
 * The DotMatrix class stores a mapping of individual characters and their 
 * respective Dot Matrix representations. It reads a text file that
 * contains the dot matrix representations of all characters and creates 
 * a TreeMap. The key of every map element stores a single character
 * and the value of the map element is a List<String> that stores the dot matrix 
 * representation of the key.
 */


public class DotMatrix {

	 /*dm will store the mapping between characters and their dot 
	 matrix representations*/
     private Map <String, List<String>> dm;
     static String characters = null;

     /*
      * Class constructor
      */
     public DotMatrix() {
       	dm = new TreeMap<String, List<String>>();
     }
     
     /*
      * The loadAlphabets method takes a text file name as parameter. 
      * The first line of the text file contains the characters that 
      * we will use to create the message loop. The remainder of the 
      * text file contains the dot matrix representations of the characters 
      * in the same order as they appear in the first line of the file
      * 
      * dot_mat_alpha stores the dot matrix representation of a character
      */
     public void loadAlphabets(String filename) {
     	try {
      		File f = new File(filename);
      		Scanner s = new Scanner(f); 
        	String line = null; 
        	
      		List<String> dot_mat_alpha = new ArrayList<String>();			      
      		if(s.hasNext())
      			characters = s.nextLine();
      		int i = 0;
        	while (s.hasNext() && (line = s.nextLine()) != null && i < characters.length()) {	    	  
      			char c = line.charAt(0);
      			if (c == '#') {	    		  
      				String alpha = Character.toString(characters.charAt(i++));					  
      				this.dm.put(alpha, dot_mat_alpha);
      				dot_mat_alpha = new ArrayList<String>();
      			}
      			else 
      				dot_mat_alpha.add(line);						  					  	    	  
      		}					
      		//Dot Matrix representation for the blank character
      		dot_mat_alpha = new ArrayList<String>(); 
      		for(int j = 0; j < 7; j++) {
      			dot_mat_alpha.add("     ");
      		}
      		this.dm.put(" ", dot_mat_alpha);
      	}

      	catch (FileNotFoundException e) {
      		System.out.println(" Dot Matrix Alphabets file not found");
      		System.exit(1);
      	}
    }// End of loadAlphabets method
    
    /*
     * The getDotMatrix method takes as parameter a single character and
     * returns a list of strings that stores the dot matrix representation 
     * of the character.
     */
    public List<String> getDotMatrix (String s) {
        List<String> dot_mat_rep = this.dm.get(s.toUpperCase());
        return dot_mat_rep;
        
    }
    
    /*
     * The isValidCharacter method takes as parameter a single character and
     * returns a boolean 'true' if the character is found in the map, otherwise
     * it returns a boolean 'false'
     */
	public boolean isValidCharacter(String s) {
		return (characters.toUpperCase().contains(s.toUpperCase()) || s.equals(" "));
	}
   
} // End of class DotMatrix
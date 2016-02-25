import java.io.File;
import java.io.IOException;
import java.util.Iterator;
import java.util.Scanner;
import java.util.List;
///////////////////////////////////////////////////////////////////////////////
//ALL STUDENTS COMPLETE THESE SECTIONS
//Title:            p5
//Files:            LoadBalancerMain.java, SimpleHashMap.java, 
//					valueContainer.java
//Semester:         CS367 Spring 2014
//
//Author:           Griffin Lacek
//Email:            lacek@wisc.edu
//CS Login:         lacek
//Lecturer's Name:  Jim Skrentny
//
////////////////////PAIR PROGRAMMERS COMPLETE THIS SECTION ////////////////////
//
//Pair Partner:     Zach Ambur
//Email:            zambur@wisc.edu
//CS Login:         zachary
//Lecturer's Name:  Jim Skrentny
//
////////////////////////////80 columns wide //////////////////////////////////

/**
 * Only contains a main method that is the organizer of the whole program. It 
 * is in direct relation with the SimpleHashMap.java class that helps 
 * determine which hosting server, identified by its IP address, that each page
 * request, identified by the file that is passed in, should be routed to.
 *
 * @author Griffin Lacek and Zach Ambur
 */
public class LoadBalancerMain
{

	/**
	 * The only method in this class that does most of the work for this
	 * program. It checks to make sure it has the correct number of command
	 * line arguments, and then reads the file of page requests that is passed 
	 * in and routes each one of those pages to a hosting server.  Making sure 
	 * that each hosting server never exceeds its cache size. If there are more
	 * pages mapped to a single server then it can hold, it then evicts a page 
	 * using a Least-Recently-Used algorithm. It also can display two different
	 * modes, one that just prints out the final count for each hosting server
	 * and the number of evictions. But the verbose mode prints out everything 
	 * the first modes prints but also prints out each IP address of the server
	 * it was routed to when it was routed.
	 *
	 * @param args A String array
	 */
    public static void main(String[] args) throws IOException
    {
		Scanner scanner = null;
        if(args.length != 3) {
        	System.out.println("Error! Incorrect number of arguments provided.");
        	System.exit(1);
        }
        	
				
        
        
        int maxServers = Integer.parseInt(args[0]);
        int cacheSize = Integer.parseInt(args[1]);
        File inFile = new File(args[2]);
        if (!inFile.exists() || !inFile.canRead()) {
            System.err.println("Error: Cannot access input file");
            System.exit(1);
         }
        scanner = new Scanner(inFile);
        boolean isVerbose = (args.length == 4) && (args[3].equals("-v"));
        
        String line;
        int currServer = 0;
        long lastAccess = 0;
        int evictionCount = 0;
        int[] referenceCount = new int[maxServers];
        int[] serverLoad = new int[maxServers];
        
        SimpleHashMap<String, valueContainer> map = new SimpleHashMap<String, valueContainer>();
        
        
        while (scanner.hasNextLine()) {
						line = scanner.nextLine();
						
						if (currServer >= maxServers) {
							currServer = 0;
						}
						
						valueContainer keyValues = map.get(line);

						if(serverLoad[currServer] >= cacheSize && keyValues == null) {
							List<SimpleHashMap.Entry<String, valueContainer>> entries = map.entries();
							Iterator<SimpleHashMap.Entry<String, valueContainer>> itr = entries.iterator();
							SimpleHashMap.Entry<String, valueContainer> LRUEntry = null;
							while(itr.hasNext()) {
								SimpleHashMap.Entry<String, valueContainer> currEntry = itr.next();
								if(currServer == currEntry.getValue().getIp()) {
									if(LRUEntry == null) {
										LRUEntry = currEntry;
									}
									else if(currEntry.getValue().getAccess() < LRUEntry.getValue().getAccess()) {
										LRUEntry = currEntry;
									}
								}
							}
							map.remove(LRUEntry.getKey());
							evictionCount++;
							if(isVerbose) {
								System.out.println("Page " + LRUEntry.getKey() + " has been evicted.");
							}
						}
						
						//Create new entry
						valueContainer entryValues = new valueContainer(currServer, lastAccess);
						//Add entry to map
						//valueContainer keyValues = map.get(line);
						if(keyValues != null) {
							keyValues.setAccess(lastAccess);
							int keyIP = keyValues.getIp();
							map.put(line, keyValues);
							referenceCount[keyIP]++;
						}
						else{
							map.put(line, entryValues);
							referenceCount[currServer]++;
							serverLoad[currServer]++;
							currServer++;
						}
						
						if(isVerbose) {
							System.out.println("192.168.0." + currServer);
						}
						
						lastAccess++;
						
						
        }
        scanner.close();
        
        //Output the number of requests routed to each server
        currServer = 0;
        for(int i = 0; i < maxServers; i++) {
        	System.out.println("192.168.0." + currServer + " : " + referenceCount[i]);
        	currServer++;
        }
        //Output the total number of evictions
        System.out.println("Evictions" + " : " + evictionCount);
    }
    
    

}

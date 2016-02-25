///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Title:            p3
// Files:            RealTimeScheduler.java, CircularQueue.java,
//					 PriorityQueue.java, ProcessGenerator.java,
//					 IncorrectConfigFormatException.java,
//					 ConfigReader.java
//
// Semester:         CS367 Spring 2014
//
// Author:           Zach Ambur
// Email:            zambur@wisc.edu
// CS Login:         zachary
// Lecturer's Name:  Jim Skrentny
// Lab Section:      none
//////////////////////////// 80 columns wide //////////////////////////////////
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

/**
 * This class gets the configuration file as its only command line argument.
 * It then determines whether the set of tasks and compute resources described
 * in the configuration can be run without missing any deadlines
 */
public class RealTimeScheduler {
	
	private static int gcd(int a, int b) {
		while (b > 0)
	    {
	        int temp = b;
	        b = a % b;
	        a = temp;
	    }
	    return a;
	}
	
	private static int lcm(int a, int b) {
	    return a * (b / gcd(a, b));
	}
	
	private static int lcm(int[] input) {
	    int result = input[0];
	    for(int i = 1; i < input.length; i++) { 
	    	result = lcm(result, input[i]);
	    }
	    return result;
	}
	
	public static void main(String[] args) throws FullQueueException, EmptyQueueException {
		
		Scanner fileScr = null;
		ArrayList<Integer> contents = new ArrayList<Integer>();
		
		if(args.length != 1) {
			System.out.println("Incorrect command line argument");
			System.exit(1);
		}
		
		File inFile = new File(args[0]);
        if (!inFile.exists() || !inFile.canRead()) {
            System.err.println("Problem with input file!");
            System.exit(1);
         }
        try {
         fileScr = new Scanner(inFile);
        } catch (FileNotFoundException e) {
            System.err.println("Problem with input file!");
            System.exit(1);
        }
        
        while(fileScr.hasNextLine()) {
        	String line = fileScr.nextLine();
        	if(line.contains(" ")) {
        		int space = line.indexOf(" ");
        		String part1 = line.substring(0, space).trim();
        		contents.add(Integer.parseInt(part1));
        		String part2 = line.substring(space).trim();
        		contents.add(Integer.parseInt(part2));
        	}
        	else {
        		contents.add(Integer.parseInt(line));
        	}
        }
        int[] values = new int[contents.size()];
        for(int i = 0; i < contents.size(); i++) {
        	values[i] = contents.get(i);
        }
        int[] periods = new int[(contents.size() - 3)/2];
        int index = 0;
        for(int i = 3; i < values.length; i=i+2) {
        		periods[index] = values[i];
        		index++;
        }
          
        ComputeResourceGenerator compResGen;
        CircularQueue<ComputeResource> circularQueue = new CircularQueue<>(values[1]);
        Comparator compare = new Comparator();
        PriorityQueue<Task> priorityQueue = new PriorityQueue<>(compare, values[2]);
        ProcessGenerator procGen = new ProcessGenerator();
        for(int i = 3; i < values.length; i = i + 2) {
        	procGen.addProcess(values[i], values[i+1]);
        }
        ArrayList<Task> tasks;
        int time = 0;
        for(int i = 0; i <= lcm(periods); i++) {
        	time = i;
        	compResGen = new ComputeResourceGenerator(values[0]);
        	if(circularQueue.size() != circularQueue.capacity()) {
        		for(int j = 0; j < circularQueue.capacity(); j++) {
        			if(circularQueue.isFull()) {
        				throw new FullQueueException();
        			}
        			else {
        				circularQueue.enqueue(compResGen.getResources().get(j));
        			}
        		}
        	}

        	tasks = procGen.getTasks(time);
        	for(int k = 0; k < tasks.size(); k++) {
        		if(priorityQueue.isFull()) {
        			throw new FullQueueException();
        		}
        		else {
        			priorityQueue.enqueue(tasks.get(k));
        		}
        	}
        	if(priorityQueue.size() != 0) {
        		for(int l = 0; l < circularQueue.size(); l++) {
        			priorityQueue.peek().updateProgress(circularQueue.dequeue().getValue());
        			if(priorityQueue.peek().isComplete()) {
        				priorityQueue.dequeue();
        			}
        			else if(priorityQueue.peek().missedDeadline(time)) {
        				System.out.println("Deadline missed at timestep " + time);
        				System.exit(1);
        			}
        		}
        	}
        }
        System.out.println("Scheduling complete after " + time + " timesteps.");
	}
}

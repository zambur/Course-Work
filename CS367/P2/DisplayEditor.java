package com.zachambur;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Scanner;

/**
 * This class is the main class which prompts the users' input.
 */
public class DisplayEditor {

	public static void main(String[] args) {
		
		Scanner in = null;
		MessageLoop<List<String>> mainLoop = new MessageLoop<>();
		DotMatrix dm = new DotMatrix();
		File alphabetFile;
		
		boolean useFile = args.length == 2;
        if (useFile) {
                File inFile = new File(args[0]);
                if (!inFile.exists() || !inFile.canRead()) {
                    System.err.println("Problem with input file!");
                    System.exit(1);
                 }
                try {
                 in = new Scanner(inFile);
                } catch (FileNotFoundException e) {
                    System.err.println("Problem with input file!");
                    System.exit(1);
                }
                alphabetFile = new File(args[1]);
                if (!alphabetFile.exists() || !alphabetFile.canRead()) {
                    System.err.println("Problem with input file!");
                    System.exit(1);
                 }
                try {
                 in = new Scanner(alphabetFile);
                } catch (FileNotFoundException e) {
                    System.err.println("Problem with input file!");
                    System.exit(1);
                }
        }
        else {
                in = new Scanner(System.in);
                System.out.print("Enter the dot-matrix alphabets file: ");
                alphabetFile = new File(in.next());
                if (!alphabetFile.exists() || !alphabetFile.canRead()) {
                    System.err.println("Problem with input file!");
                    System.exit(1);
                 }
                try {
                 in = new Scanner(alphabetFile);
                } catch (FileNotFoundException e) {
                    System.err.println("Problem with input file!");
                    System.exit(1);
                }
		}
        
		boolean stop = false;

        /**
         * Load up the dot matrix tree map for each character in the alphabet.
         */
		while(!stop) {
			in = new Scanner(System.in);
			dm.loadAlphabets(alphabetFile.getName());
			System.out.print("enter command (? for help)> ");
			String input = in.nextLine();
			String remainder = null;
			if (input.length() > 0) {
				char option = input.charAt(0); 
				if (input.length() > 1) {
					remainder = input.substring(2);
				}

				
				switch (option) {

                    /**
                     * This option prints out the list of available commands for users.
                     * */
				case '?': {
					System.out.println("s (save)     l (load)      d (display)\n"
							         + "n (next)     p (previous)  j (jump)\n"
							         + "x (delete)   a (add after) i (insert before)\n"
							         + "c (content)  r (replace)   q (quit)");
					break;
				}

                /**
                 * This option saves the message to the file with specified name. If
                 * the file name already exist, display an overwriting warning
                 * message before saving the message. If the filename cannot be
                 * written to, display the message.
                 */
				case 's': {
					if(remainder == null) {
						System.out.println("invalid command");
					}
					else if(mainLoop.size() == 0) {
						System.out.println("no messages to save");
					}
					else {
						PrintWriter printData = null;
						File outputFile = new File(remainder);
						if (outputFile.exists()) {
		                    System.out.println("warning: file already exists, will be overwritten");
						}
		                try {
		                	printData = new PrintWriter(outputFile);
		                } catch (FileNotFoundException e) {
		                    System.out.println("unable to save");
		                }
		                mainLoop.back();
						Iterator<List<String>> nodeItr = mainLoop.iterator();
						while(nodeItr.hasNext()) {
							List<String> data = nodeItr.next();
							Iterator<String> dataItr = data.iterator();
							while(dataItr.hasNext()) {
								printData.println(dataItr.next());
							}
							printData.println("##########");
						}
						printData.close();
					}
					
					break;
				}

                /**
                 * This option loads the message. If the specified file name does
                 * not exist or cannot be read from, display "unable to load".
                 * Otherwise, load the message from the file until the entire file
                 * is read. Set the current character to be the first character read
                 * from the file. Assume that the file content is already in the
                 * correct format.
                 */
				case 'l': {
					if(remainder == null) {
						System.out.println("invalid command");
					}
					else {
						Scanner scannerData = null;
						File inputFile = new File(remainder);
						if (!inputFile.canRead() || !inputFile.exists()) {
							System.out.println("unable to load");
						}
						try {
							scannerData = new Scanner(inputFile);
						} catch (FileNotFoundException e) {
							System.err.println("unable to load");
						}
						List<String> data = new ArrayList<String>();
						boolean sameNode;
						while(scannerData.hasNextLine()) {
							sameNode = true;
							while(sameNode) {
								String line = scannerData.nextLine();
								if(line.startsWith("#")) {
									mainLoop.addAfter(data);
									data = new ArrayList<String>();
									sameNode = false;
								}
								else {
									data.add(line);
								}
							}
						}
						scannerData.close();
					}
					break;
				}

                /**
                 * This option displays the message. If the message loop is empty,
                 * display "no messages". Otherwise, display the message in the
                 * loop, starting with the current character in a 7 x 5 dot-matrix
                 * display (going forward through the entire loop). Each character
                 * must be separated from the other characters by a blank line.
                 */
				case 'd': {
					if(mainLoop.size() == 0) {
						System.out.println("no messages");
					}
					else {
						mainLoop.back();
						Iterator<List<String>> nodeItr = mainLoop.iterator();
						while(nodeItr.hasNext()) {

							List<String> data = nodeItr.next();
							Iterator<String> dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println();
						}
						mainLoop.forward();
					}

					break;
				}

                /**
                 * This option goes forward to the next character in the loop and
                 * displays the current context. If the message loop is empty,
                 * display "no messages".
                 */
				case 'n': {
					if(mainLoop.size() == 0) {
						System.out.println("no messages");
					}
					else{
						mainLoop.forward();
						List<String> data;
						Iterator<String> dataItr;
						if(mainLoop.size() == 1) {
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
						}
						else if(mainLoop.size() == 2) {
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.back();
						}
						else if(mainLoop.size() > 2){
							mainLoop.back();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.back();
						}
					}
					break;
				}

                /**
                 * This option goes back to the previous character in the loop and
                 * display the current context. If the message loop is empty,
                 * displays "no messages".
                 */
				case 'p' : {
					if(mainLoop.size() == 0) {
						System.out.println("no messages");
					}
					else {
						mainLoop.back();
						List<String> data;
						Iterator<String> dataItr;
						if(mainLoop.size() == 1) {
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
						}
						else if(mainLoop.size() == 2) {
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.back();
						}
						else if(mainLoop.size() > 2){
							mainLoop.back();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.back();
						}
					}
					break;
				}

                /**
                 * This option "jumps" N characters in the loop (forward if N > 0,
                 * backward if N < 0) and displays the current context. If the
                 * message loop is empty, displays "no messages".
                 */
				case 'j': {
					if(remainder == null) {
						System.out.println("invalid command");
						break;
					}
					int n = Integer.parseInt(remainder);
						if(n > mainLoop.size() || mainLoop.size() == 0) {
							System.out.println("no messages");
						}
					else {
						if(n > 0) {
							for(int i = 0; i < n; i++) {
								mainLoop.forward();
							}
						}
						if(n < 0) {
							for(int i = 0; i > n; i--) {
								mainLoop.back();
							}
						}
					}
					List<String> data;
					Iterator<String> dataItr;
					if(mainLoop.size() == 1) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
					}
					else if(mainLoop.size() == 2) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					else if(mainLoop.size() > 2){
						mainLoop.back();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					break;
				}

                /**
                 * Deletes the current character in the message. If the message loop
                 * becomes empty as a result of the removal, display "no messages".
                 * Otherwise, make the character after the removed character the
                 * current character and displays the current context.
                 */
				case 'x': {
					if(mainLoop.size() == 0) {
						System.out.println("no messages");
					}
					else{
						mainLoop.removeCurrent();
						if (mainLoop.size() == 0) {
							System.out.println("no messages");
						}
					}
					List<String> data;
					Iterator<String> dataItr;
					if(mainLoop.size() == 1) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
					}
					else if(mainLoop.size() == 2) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					else if(mainLoop.size() > 2){
						mainLoop.back();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					break;
				}

                /**
                 * If the message loop is empty, add all the characters in the
                 * message to the message loop, one character per node converted to
                 * its dot matrix representation, and added one after another.
                 * Otherwise, add these characters in the same manner immediately
                 * after the current character. In either case, the current
                 * character will become the last character that was added and then
                 * display the current context.
                 *
                 * If any of the characters in the message is an invalid character,
                 * it won't be able to be converted to the dot matrix representation
                 * so add nothing; instead display
                 * "An unrecognized character has been entered." and then return to
                 * the menu prompt. An invalid character is not defined in the dot
                 * mapping file alphabets.txt
                 */
				case 'a': {
					if(remainder == null) {
						System.out.println("invalid command");
					}
					else {
						int j = 0;
						while(j < remainder.length()) {
								String s = "" + remainder.charAt(j);
								if(!dm.isValidCharacter(s)) {
									j = remainder.length();
									System.out.println("An unrecognized character"
											+ "has been entered.");
								}
								j++;
						}
						for(int i = 0; i < remainder.length(); i++) {
							String dmChar = "" + remainder.charAt(i);
							mainLoop.addAfter(dm.getDotMatrix(dmChar));
						}
						List<String> data;
						Iterator<String> dataItr;
						if(mainLoop.size() == 1) {
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
						}
						else if(mainLoop.size() == 2) {
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.back();
						}
						else if(mainLoop.size() > 2){
							mainLoop.back();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							System.out.println("**********");
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							System.out.println("**********");
							mainLoop.forward();
							data = mainLoop.getCurrent();
							dataItr = data.iterator();
							while(dataItr.hasNext()) {
								System.out.println(dataItr.next());
							}
							mainLoop.back();
						}
					}
					
					
					break;
				}

                /**
                 * If the message loop is empty, insert all the characters in the
                 * message to the message loop, one character per node converted to
                 * its dot matrix representation, and inserted one before another.
                 * Otherwise, insert these characters in the same manner immediately
                 * before the current character. In either case, the current
                 * character will become the last character that was inserted and
                 * then display the current context.
                 *
                 * If any of the characters in the message is an invalid character,
                 * it won't be able to be converted to the dot matrix representation
                 * so insert nothing; instead display
                 * "An unrecognized character has been entered." and then return to
                 * the menu prompt. An invalid character is not defined in the dot
                 * mapping file alphabets.txt
                 */
				case 'i': {
					if(remainder == null) {
						System.out.println("invalid command");
					}
					else {
						int j = 0;
						while(j < remainder.length()) {
								String s = "" + remainder.charAt(j);
								if(!dm.isValidCharacter(s)) {
									j = remainder.length();
									System.out.println("An unrecognized character"
											+ "has been entered.");
								}
								j++;
						}
						for(int i = 0; i < remainder.length(); i++) {
								String dmChar = "" + remainder.charAt(i);
								mainLoop.addBefore(dm.getDotMatrix(dmChar));
							}
					}
					List<String> data;
					Iterator<String> dataItr;
					if(mainLoop.size() == 1) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
					}
					else if(mainLoop.size() == 2) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					else if(mainLoop.size() > 2){
						mainLoop.back();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					
					break;
				}

                /**
                 * Display the current context.
                 */
				case 'c': {
					if(mainLoop.size() == 0) {
						System.out.println("no messages");
					}
					List<String> data;
					Iterator<String> dataItr;
					if(mainLoop.size() == 1) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
					}
					else if(mainLoop.size() == 2) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					else if(mainLoop.size() > 2){
						mainLoop.back();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					break;
				}

                /**
                 * If the message loop is empty, display "no messages". Otherwise,
                 * replace the current character with the new character and display
                 * the current context (see note below). If the character entered is
                 * invalid display "An unrecognized character has been entered." and
                 * don't replace the message in the message loop. The program should
                 * continue with it's normal operation.
                 */
				case 'r': {
					if(remainder == null || remainder.length() > 1) {
						System.out.println("invalid command");
					}
					else if(mainLoop.size() == 0) {
						System.out.println("no messages");
					}
					else if(!dm.isValidCharacter(remainder)) {
						System.out.println("An unrecognized character"
								+ "has been entered.");
					}
					else {
						mainLoop.removeCurrent();
						mainLoop.addBefore(dm.getDotMatrix(remainder));
					}
					List<String> data;
					Iterator<String> dataItr;
					if(mainLoop.size() == 1) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
					}
					else if(mainLoop.size() == 2) {
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					else if(mainLoop.size() > 2){
						mainLoop.back();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						System.out.println("**********");
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						System.out.println("**********");
						mainLoop.forward();
						data = mainLoop.getCurrent();
						dataItr = data.iterator();
						while(dataItr.hasNext()) {
							System.out.println(dataItr.next());
						}
						mainLoop.back();
					}
					
					break;
				}

                /**
                 * Display "quit" and quit the program.
                 */
				case 'q': {
					stop = true;
                    System.out.println("exit");
					break;
				}
				
				default:
					break;
				}
			}
		}
		
	}

}
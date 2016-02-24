/*******************************************************************************
Author: Zach Ambur
CS Login: zachary
Course: CS 368, Fall 2014
Assignment: Programming Assignment 5
*******************************************************************************/
#include <fstream>
#include <string>
#include <cstring>
#include <iostream>

using namespace std;


/**
 * This function first sees if the file passed in
 * exists and is readable. If it is then it will go line by line to find if there
 * are any occurrences of the word the user is searching for. It will print out 
 * the entire line if the word is found in that line and return the number of times
 * the word was in the file.
 *
 * @param fileName  the string of the file
 * @param word  the string of the word to be found
 * @return The number of occurrences of the passed word, or -1 if file doesn't exist
 */
int printFile(string &fileName, string &word) {
		ifstream file(fileName.c_str());
				
		if (file) {
			int lineNum = 0;
			int count = 0;
			string line;
			while (!getline(file, line).eof()) {
				int start = 0;
				lineNum++;
                // If word is found in this line
				if (line.find(word) != string::npos) {
					cout << "Line " << lineNum << ": " << line << endl;
                    // Counting the occurrences of word in this line
					while ((start = line.find(word, start)) != string::npos) {
						count++;
                        // Moves the starting point to the char after the length of the
                        //  word so it doesn't count duplicates
						start += word.length(); 
					}
				}
			}
			file.close();
			return count;
		}
		else {
			cerr << "File '" << fileName << "’ could not be opened" << endl;
		    file.close();
			return -1;
		}
}


/**
 * This is the main function of the program. It parses the arguments passed in
 * and sets them to their assigned values. It then calls printFile() to see if
 * the given word is in the given file.
 *
 * @param argc  the number of arguments passed
 * @param argv  an array of all the arguments passed in
 * @return 0
 */
int main(int argc, char *argv[]) {
    // If the word and/or file was not given
	if (argc < 3) {
		cout << "Invalid number of arguments" << endl;
		return 0;
	}
	string word = argv[1];
    string fileName = argv[2];
	int occurrences = printFile(fileName, word);
    // If the file could not be opened
	if (occurrences != -1) {
		cout << "occurrences of '" << word << "’ = " << occurrences << endl;
	}
    return 0;
}
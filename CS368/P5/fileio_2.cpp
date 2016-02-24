/*
 * fileIO.cpp
 *
 * Example showing file input and output
 * 
 * Modified by Hidayath Ansari for CS 368, Fall 2014
 * Updated by Jim Skrentny for CS 368, Fall 2006
 * Written by Beck Hasti for CS 368, Spring 2004
 */
#include <fstream>
#include <iostream>
#include <string>

using namespace std;

/*  
 * countLines
 *
 * Counts the number of lines in the file with the given name.
 * The lines are also echoed to standard output (along with the line number)
 * If the file cannot be opened, -1 is returned.
 */
int countLines(string& fileName, int method) {

    ifstream myFile(fileName.c_str()); 	// We can't pass a "string" to 
					// the ifstream constructor!

    if (myFile) {       // if the file was successfully opened
        int count = 0;

        if (method == 1) {
        	// VERSION 1: C style strings
        	//     uses a char array and member function getline()
        	char line[100];
        	while (!myFile.getline(line, 100).eof()) {
        		count++;
        		cout << "Line " << count << ": " << line << endl;
        	}
	}
	else if (method == 2) {
	        // VERSION 2: C++ style strings
        	// uses a string object and free function getline()
        
        	string line;
	        while (!getline(myFile, line).eof()) {
        		count++;
            		cout << "Line " << count << ": " << line << endl;
        	}
	}

        myFile.close();   // close the file now that we're done with it
        return count;

    } else {
        cerr << "Unable to open " << fileName << " in countLines" << endl;
        myFile.close();
        return -1;
    }
}





int main() {

    // Test the countLines function
    string name = "p5test.txt";
    int numLines = countLines(name, 1);
    cout << "(1) File " << name << " has " << numLines << " lines" << endl;
    numLines = countLines(name, 2);
    cout << "(2) File " << name << " has " << numLines << " lines" << endl;
  
    return 0;
}

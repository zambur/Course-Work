// Program 1a - Text Sorting
// By Zach Ambur
// CS 537
// 01/31/16

#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>

// Global variable for the index of the word in the line
int finalIndex;

// Given the file this function will count the total number
// of lines in the file
int countLines(FILE *filename) {
	int numLines = 0;
	while(!feof(filename)) {
		char c = fgetc(filename);
		if (c == '\n') {
			numLines++;
		}
	}
	// Sets the cursor back to the beginning of the file
	rewind(filename);
	return numLines;
}

// Given a line in the file this will return the word at
// the correct index the user is searching for
char* getString(char* line) {
	int currIndex = 1;
	char *nextWord;
	char *word = strtok(line, " ");
	while(currIndex < finalIndex) {
		nextWord = strtok(NULL, " ");
		if (nextWord != NULL) {
			word = nextWord;
		}
		currIndex++;
	}
	return word;
}

// Given 2 lines of the file this fuctions will compare the 2 lines
// returning which ones comes first
int stringCompare(const void *lineA, const void *lineB) { 
	char *firstLine = strdup(*(const char**)lineA);
	char *secondLine = strdup(*(const char**)lineB);
		
    return strcmp(getString(firstLine), getString(secondLine));
}

int main(int argc, char *argv[]) {
	char *inputFile;
	// Each line is only a length of 128 characters max
	char line[128];
	int i;
	
	if (argc == 2) {
		inputFile = argv[1];
		finalIndex = 1;
	}
	else if (argc == 3) {
		inputFile = argv[2];
		char *inputNumber = argv[1];
		// Check that the first command line argument starts with a '-'
		if (inputNumber[0] != '-') {
			fprintf(stderr, "Error: Bad command line parameters\n");
			exit(1);
		}
		finalIndex = atoi(inputNumber + 1);
		// Check that the '-' is followed by a number
		if (finalIndex <= 0) {
			fprintf(stderr, "Error: Bad command line parameters\n");
			exit(1);
		}
	}	
	else {
		fprintf(stderr, "Error: Bad command line parameters\n");
		exit(1);
	}
	
	FILE *fp = fopen(inputFile, "r");
	if (fp == NULL) {
		fprintf(stderr, "Error: Cannot open file %s\n", inputFile);
		exit(1);
	}
	
	// Get the number of lines in the file
	int numLines = countLines(fp);
	char *lineArray[numLines];
	int arrayIndex = 0;
	
	while (fgets(line, sizeof(line), fp) != NULL) {
		//Check that each line is less than 128 characters
		if (line[(strlen(line) - 1)] != '\n') {
			fprintf(stderr, "Line too long\n");
			exit(1);
		}
		lineArray[arrayIndex] = malloc(strlen(line) + 1);
		if (lineArray[arrayIndex] == NULL) {
			fprintf(stderr, "malloc failed\n");
			exit(1);
		}
		strcpy(lineArray[arrayIndex], line);
		arrayIndex++;
	}
	
	fclose(fp);
	
	//Short file by using quick sort
	qsort(&lineArray[0], numLines, sizeof(char*), stringCompare);
	
	// Print the file in a sorted manner
	for (i = 0; i < numLines; i++) {
		printf("%s", lineArray[i]);
	}
		
	// Free the memory of the array
	for(i = 0; i < numLines; i++){
		free(lineArray[i]);
	}
	
	// Return success
	return 0;
}
/* Written by Zach Ambur
 * Section 001
 * November 24, 2015
 */

#include  <stdlib.h>
#include  <stdio.h>
#include  <signal.h>

// Declaring global variables
int int1;
int int2;
int division;
int rem;

// The signal interupt handler to decipher which signal interupt occured and then deal with it accordingly
void handler(int signum){
	switch(signum) {
		// Handles divide by 0 signal interupt
		case SIGFPE:
			// Displays unsuccessful attempt to divide by 0
  			printf("Can't divide by 0.\n");
			// Prints the current integer values, number of divisions and remainder
			printf("%d / %d is 0 with a remainder of 0\n", int1, int2);
			// Gracefully exits program
 			exit(0);
			break;
		// Handles user control-C signal interupt
		case SIGINT:
			// Prints the current integer values, number of divisions and remainder
			printf("\n%d / %d is %d with a remainder of %d\n", int1, int2, division, rem);
			// Gracefully exits program
			exit(0);
			break;
	}
}

// The main function of the program that is in an infinite loop that will contine to get 
//  two integers from the user to find and display the number of divisions and remainder
int main(int argc, char *argv[]) {
	// Infinite loop
	while (1) {
		// Setting up division by 0 signal interupt
		struct sigaction div_action;
		memset(&div_action, 0, sizeof(div_action));
		div_action.sa_handler = handler;
		sigaction(SIGFPE, &div_action, NULL);

		// Setting up user control-C signal interupt
		struct sigaction input_action;
		memset(&input_action, 0, sizeof(input_action));
		input_action.sa_handler = handler;
		sigaction(SIGINT, &input_action, NULL);
		
		// char arrays for the users entered inputs
		char input1[50];
		char input2[50];
	
		// Prompts and gets user input
		printf("Enter first integer: ");
		fgets(input1, 50, stdin);
		printf("Enter second integer: ");
		fgets(input2, 50, stdin);
		
		// Stores user inputs
		int1 = atoi(input1);
		int2 = atoi(input2);
		// Calculates number of divisions done
		division = int1 / int2;
		// Calculates remainder
		rem = int1 % int2;
		// Prints results to user
		printf("%d / %d is %d with a remainder of %d\n", int1, int2, division, rem);
	}
}

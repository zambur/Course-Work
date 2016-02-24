/* Written by Zach Ambur
 * Section 1
 * November 4, 2015
 */

#include  <stdlib.h>
#include  <stdio.h>
#include  <signal.h>
#include  <time.h>

// Declaring global variables
int count = 4; // Number of times user can enter control-C
const int alarmTime = 3; // Number of seconds between each alarm
time_t currTime;

// The signal interupt handler to decipher which signal interupt occured and then deal with it accordingly
void alarm_handler(int signum){
	switch(signum) {
		// Handles alarm signal interupt by printing the current time and re-arming the alarm
		case SIGALRM:
  			currTime = time(NULL);
  			printf("current time is ");
  			printf(ctime(&currTime));
			alarm(alarmTime);
			break;
		// Handles user control-C signal interupt
		case SIGINT:
			// If the user has entered control-C 5 times, display the an exit message and exit the program
			if (count <= 0) {
				printf("\nFinal Control-c caught. Exiting.\n");
				exit(0);
			}
			// If there have been fewer than 5 control-C inputs, display how many are left and continue the program
			printf("\nControl-c caught. %d more before program is ended.\n", count);
			count--;
			break;
	}
}

// Main function of the program which sets up the signal interupts and then enters and infinite loop
int main(int argc, char *argv[]){

  // Printing welcoming message
  printf("Date will be printed every 3 seconds.\n");
  printf("Enter ^C 5 times to end the program:\n");

  // Setting up alarm signal interupt
  struct sigaction alarm_action;
  memset(&alarm_action, 0, sizeof(alarm_action));
  alarm_action.sa_handler = alarm_handler;
  sigaction(SIGALRM, &alarm_action, NULL);

  // Setting up user input signal interupt
  struct sigaction input_action;
  memset(&input_action, 0, sizeof(input_action));
  input_action.sa_handler = alarm_handler;
  sigaction(SIGINT, &input_action, NULL);

  // Call alarm interupt every 3 seconds
  alarm(alarmTime);

  // Enter while loop so program doesn't exit main()
  while (1) {
  }
}

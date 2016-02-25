#include<stdio.h>
#include<stdlib.h>
#include<unistd.h>
#include <sys/types.h>
#include <sys/wait.h>
#include<string.h>
#include <fcntl.h>
#include <sys/types.h>
#include <sys/stat.h>

#define MAX_LINE_LENGTH 129
#define PATH_MAX 128

//Displays Error Message
void ErrorMsg() {	
	char error_message[30] = "An error has occurred\n";
	write(STDERR_FILENO, error_message, strlen(error_message));
}

// Returns the number of arguments inputed
int argCount(char *command) {
	int count = 0;
	char *string = strdup(command);	
	char *token;
   	token = strtok(string, " \t\n");
   	while (token != NULL) {
		token = strtok(NULL, " \t\n");
		count++;
	}
	return count;
}

int main(int argc ,char *argv[]) {	
	// Check for valid arguments
	if (argc != 1) {
		ErrorMsg();
		exit(1);
	}
	
  	int pathNum = 1;
  	char *mypath[MAX_LINE_LENGTH];
	mypath[0] = "/bin";
		
	while(1) {
		char input[10 * MAX_LINE_LENGTH];
		char buff[PATH_MAX + 1];
		char *dir;
		char *cwd;
		char *redirPath = NULL;
		
		printf("whoosh> ");
		fflush(stdout);
		if (fgets(input, sizeof(input), stdin) == NULL) {
			ErrorMsg();
			continue;
		} else {
			strtok(input, "\n");
			if (strlen(input) > MAX_LINE_LENGTH) {
				ErrorMsg();
				continue;
			}
			// Get number of arguments
			int numArgs = argCount(input);
		
			if (numArgs != 0) {
				int i = 0;
				char *userInput[numArgs + 1];
				char *token = strtok(input, " ");
				// Put each argument in userInput array
				while (token != NULL) {
					if (i < numArgs) {
						if ((i + 1) == numArgs) {
							userInput[i] = token;
						} else {
							userInput[i] = strdup(token);
						}
						i++;
					}
					token = strtok(NULL, " ");	
				}
			
		    	int redir = 0;
		    	int lastRedir = 0;
				// Check for any redirects
		    	for(i = 1; i < numArgs; i++) {
		      		if(strcmp(userInput[i], ">") == 0) {
						redir++;
						lastRedir = i;
		      		}
		    	}
				// Redirect error handling
		    	if(redir > 1) {
		      		ErrorMsg();
		      		continue;
		    	} else if (redir == 1) {
					// Redirect error handling
		      		if(lastRedir != numArgs - 2) {
						ErrorMsg();
						continue;
		      		}
	       		 	if (userInput[numArgs - 1][0] == '/') {
	        			if(chdir(userInput[numArgs - 1]) == 0) {
							// Save redirect path
	       				 	redirPath = strdup(userInput[numArgs - 1]);
	        			} else {
							// Redirect error handling
	        				ErrorMsg();
	      				  	continue;
	       			 	}
					}
					// Delete the path
	      		  	numArgs = numArgs - 2;
		    	}
				userInput[numArgs] = NULL;
				// Exit on command
				if (strcmp(userInput[0], "exit") == 0) {
					exit(0);
				} else if (strcmp(userInput[0], "cd") == 0) {
					// Change directory to home
					if (numArgs == 1) {
						dir = getenv("HOME");
						if (chdir(dir) != 0) {
							ErrorMsg();
						}			
					} else {
						// Change directory to the given path
						dir = userInput[1];
						if (chdir(dir) != 0) {
							ErrorMsg();
						}
					}
				} else if (strcmp(userInput[0], "pwd") == 0) {
					// Print working directory
					cwd = getcwd(buff, PATH_MAX + 1);
					if (cwd != NULL) {
						printf("%s\n", cwd);
					} else {
						ErrorMsg();	
					}
				} else if (strcmp(userInput[0], "path") == 0) {
					if(numArgs > 1) {
						// Change path to given path
	          		  	pathNum = 0;
	          		  	for(i = 1 ; i < numArgs; i++) {
	           			 	if(userInput[i][0] == '/') {
	          				  	mypath[i - 1] = strdup(userInput[i]);
	          				  	pathNum++;
	          			  	} else {
	            				ErrorMsg();
	            			}
	            		} 
					} else {
						// Remove path
	         		   	mypath[0] = NULL;
	         		   	pathNum = 0;
					}
				} else {		
					// Execute other commands			
					int fileExists = 0;
					// Save current working directory
					cwd = getcwd(buff, PATH_MAX + 1);
					// Check every path to find executable command
            		for(i = 0; i < pathNum; i++) {
              		  	chdir(mypath[i]);              
						struct stat buffer;
              		  	if(stat(userInput[0], &buffer) == 0) {
							// File exists
               			 	fileExists = 1;
							char *string = malloc(strlen(mypath[i]) + strlen("/") + strlen(userInput[0]) + 1);
							strcpy(string, mypath[i]);
							strcat(string, "/");
							strcat(string, userInput[0]);
                			userInput[0] = string;
							// Return to current directory
                			chdir(cwd);
                			break;
              	 	   	}
            		}
            		if (fileExists == 0) {
						ErrorMsg();
						continue;
					} else {
						// Create new process
           			 	int rc = fork();
             		   	if (rc == 0) {
							// Child will execute file
              			  	if (redir == 1) {
								if (redirPath != NULL) {
                    				chdir(redirPath);
								}
								close(STDOUT_FILENO);
								open("output.out", O_CREAT | O_TRUNC | O_WRONLY, S_IRUSR | S_IWUSR);
								close(STDERR_FILENO);
								open("output.err", O_CREAT | O_TRUNC | O_WRONLY, S_IRUSR | S_IWUSR);
                			}
                			if (execv(userInput[0], userInput) == -1) {
	                			ErrorMsg();
	                			exit(1);
                			}
              	  		} 
						// Parent waits for child
						else if(rc > 0) {
                			wait(NULL);
              			}
					}
				}
			}
		}
	}
	return 0;
}


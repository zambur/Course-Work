/* Assignment 1: Program 2 : Guessing Game
 * by Zach Ambur
 */

#include <stdlib.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <stdio.h>
#include <assert.h>
#include <unistd.h>

//Declaires Node structure
typedef struct node 
{
	int data;
	struct node * next;
} Node;

/* Creates a new node structure and adds a node to the front
 * of the linked list. 
 * Parameters:
 * *head: the current head node 
 * intforlist: int to be the data of the new node
*/
Node * listadd(Node *head, int intforlist) 
{
	Node * newNode;
	newNode = malloc(sizeof(Node));
		
	newNode->data = intforlist;
	newNode->next = head;
	head = newNode;
	
	return newNode;
}

/* Creates the singly linked list by reading the input file
 * and calling listadd() for each int to add new nodes to 
 * the list. 
 * Parameters:
 * fd : file directory
*/ 
Node * createlist(int fd) 
{	
	int *tempArray; //Temporary array to hold read integers
	int fileSize;
	int numInts;
	int byteSize; //Number of bytes to read by read()
	struct stat s;
    fstat(fd, &s);

	fileSize = s.st_size;
	numInts = fileSize / sizeof(int);
	tempArray = malloc(fileSize * sizeof(int));

	Node * head = NULL;
	head = malloc(sizeof(Node));
	if (head == NULL) 
	{
		return NULL;
	}
	
	head->data = 0;
	head->next = NULL;
	
	for (int i = 0; i < numInts; i++) 
	{
		byteSize = read(fd, &tempArray[i], sizeof(int));
			if (byteSize == -1) 
			{
				printf("Read failed.");
				exit(1);
			}
		head = listadd(head, tempArray[i]);
	}
	return head;
}

/* Iterates through the linked list to see if a node with 
 * data intvalue is in the list. 
 * Parameters:
 * *head: the current head of list
 * intvalue: the data value to search for
*/
int inlist(Node *head, int intvalue) 
{
	Node * curr = head;
	
	while (curr != NULL) 
	{
		if (intvalue == curr->data) 
			return 1;
		else 
			curr = curr->next;
	}
	
	return 0;
}

/* Allows the user to guess values contained in the linked list by
 * calling inlist() on the user's input. Infinitely loops until q 
 * is entered.
 * Parameters:
 * *listhead: the head node of the linked list
*/
void playgame(Node * listhead) 
{	
	Node *head = listhead;
	char userInput[50]; //Array that holds the user input
	int userNum; //int the user inputed
	int listCheck; //Set to check if the value returned by inlist is 1 or 0
	
	printf("This game has you guess which integers are in the list.\n");
	printf("Enter an integer (followed by the newline)\nor q (followed by the newline) to quit.");
	
	while(userInput[0] != 113) 
	{
		printf("\nInteger guess: ");
		fgets(userInput, 50, stdin);
		
		if(userInput[0] == 113)
		{
			printf("Quiting.\n");
			exit(0);
		}
		
		userNum = atoi(userInput);
		listCheck = inlist(head, userNum);
		
		if(listCheck == 1)
			printf("%d is in the list.", userNum);
		else
			printf("%d is not in the list.", userNum);
	}
}

/* This program reads integers from a file, stores them in
 * a singly linked list, and then calls playgame() which  
 * allows user input to guess the values of integers
 * in the linked list.
 */
int main(int argc, char *argv[])
{
	int fd; //File directory
	
	// Checks for incorrect number of command line arguments
	if (argc != 2)
	{
		fprintf(stderr, "Incorrect number of arguments.\n");
	    exit(1);
    }

	if ((fd = open(argv[1], O_RDONLY)) < -1)
    {
    	fprintf(stderr, "Cannot open file.\n");
	    exit(1);
	}
	
	//Creates NULL head node to be assigned to head node of createlist.
	Node * head = NULL;
	head = malloc(sizeof(Node));
	if (head == NULL) {
		return 1;
	}
	
	head->data = 1;
	head->next = NULL;
	
	//Creates the linked list from the input file and sets the head node to head
	head = createlist(fd);
	
	//Calls playgame()	
	playgame(head);
	
	//Closes file directory and checks for error
	if (close(fd) == -1 ) 
	{
        fprintf(stderr, "Error closing file.\n");
		exit(1);
    }
	return 0; 
}
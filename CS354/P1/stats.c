/* Assignment 1: Program 1
 * by Zach Ambur
 */

#include <unistd.h>
#include <fcntl.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/stat.h>
#include <sys/types.h>

/* This program reads numbers from a binary file
 * and displays all the numbers value on the screen
 * and also displays the average of the numbers.
 *
*/
int main(int argc, char *argv[]) {

        int file, i, numItems;
        int sum = 0;
        int *array;
        struct stat fileStats;

		// Checks for the correct number of command line arguments
        if (argc != 2)
        {
                fprintf(stderr, "Incorrect number of arguments.\n");
                exit(1);
        }

		// Checks that the file passed in can be opened and read
        if ((file = open(argv[1], O_RDONLY)) < -1)
        {
                fprintf(stderr, "Cannot open file.\n");
                exit(1);
        }

		// Gets the stats of the file, includeing the byte size
        if (fstat(file, &fileStats) < 0)
        {
                fprintf(stderr, "File Error");
                exit(1);
        }

        numItems = (fileStats.st_size / sizeof(int));

		// Dynamically allocates an array 
        if ((array = malloc(numItems)) == NULL)
                fprintf(stderr, "Error allocating memmory.");

		// Reads the numbers from the binary file and prints them on the screen
        for (i = 0; i < numItems; i++)
        {
                if (read(file, (void*)array, sizeof(int)) < 0)
                {
                        fprintf(stderr, "Error during read.\n");
                }
                sum += *array;
                printf("%d\n", *array);
        }

		// Computes the average of the numbers
        printf("Average:  %d\n", (sum/numItems));

		// Closes the file
        if (close(file) == -1)
        {
                fprintf(stderr, "Error closing file.");
                exit(1);
        }
        return 0;
}
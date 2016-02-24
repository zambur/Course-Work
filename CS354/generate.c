/* written by Karen Miller
 * Jan 2, 2014
 */

#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <assert.h>
#include <unistd.h>

#define NUMINTS 10

/* This program writes each element of an array of integers
 * to a file in binary format and to stdout as ASCII.
 * The file name is provided as the single command line argument.
 */
int main(int argc, char *argv[])
{
    char *outfile;
    int fd;
    int i;
    int numbytes;
    int integers[] = { 10, 10, 26, 300, -145629, 67, 11111111, -1, 8000, 0 };

    /* if a single command line argument is not specified, print usage
     * information and exit
     */
    if (argc != 2) {
	fprintf(stderr, "usage: generate <file>\n");
	exit(1);
    }

    outfile = argv[1];
    fd = open(outfile, O_WRONLY | O_CREAT | O_TRUNC, S_IRUSR|S_IWUSR);
    assert(fd > -1);  /* exit if open() failed */

    /* for each integer in the array, write to the file and send
     * to stdout
     */
    for (i = 0; i < NUMINTS; i++) {
        numbytes = write(fd, &integers[i], sizeof(int));
        assert(numbytes == sizeof(int)); /* exit if write() failed */
	printf("%d\n", integers[i]);
    }

    if ( close(fd) == -1 ) {
        fprintf(stderr, "error closing file -- quitting");
	exit(1);
    }

    return 0;
}


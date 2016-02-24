/* Written by Zach Ambur
 * Section 1
 * November 4, 2015
 */
#include <stdio.h>

//Declares array of 100000 integers
int arr[100000];

int main(int argc, char *argv[]) {
	
	int arrSize = 100000;    //Size of array
	int i;                   //array iterator
	
	//Fills arr[] with value of i at index i
	for  (i = 0; i < arrSize; i++) {
		arr[i] = i;
	}

	return 0;
}

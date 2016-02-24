/* Written by Zach Ambur
 * Section 1
 * November 4, 2015
 */
#include <stdio.h>

//Declares a 2D array with 3000 rows, 500 columns
int arr2d[3000][500];

int main(int argc, char *argv[]) {
	
	int rowSize = 3000;  //Number of rows in 2D array
	int colSize = 500;   //Number of columns in 2D array
	int i, j;            //Row and column iterators
	
	//Sets each element in the 2D array to the sum of the 
	//current row and current column
	for  (i = 0; i < rowSize; i++) {
		for (j = 0; j < colSize; j++) {
			arr2d[i][j] = i + j;
		}
	}
	
	return 0;
}

// Program 3:  Book List
// You can assume that the file that we use to test
// your code will be similar to this one.

// Once your code runs successfully, you should look at
// your output carefully to see if it ran successfully
// Add your own tests for SortedList's implementations


#include <iostream>
#include "Book.h"
#include "SortedList.h"

using namespace std;

int main() {
	
	// test Book destructor, copy constructor, copy assignment operator
	Book bk1 = Book(12345, "cs.", 2010, 2.13);
	cout << "Book1" << endl;
    	bk1.print();
	
	//copy constructor
	Book bk2(bk1);

	//test
	if (bk1.getID() != bk2.getID() || bk1.getYear() != bk2.getYear()
	    || bk1.getRating() != bk2.getRating())
		cout << "error with Book copy constructor" << endl;
	cout << "Book2 after copy constructor" << endl;
    	bk2.print() ;   

	Book bk3 = Book(34563);
	bk3.print() ;
    	
	//copy assignment
	bk3 = bk2;

	//test
	if (bk3.getID() != bk2.getID() || bk3.getYear() != bk2.getYear()
	    || bk3.getRating() != bk2.getRating())
		cout << "error with Book copy assignment operator " << endl;
	cout << "Book3 operator=" << endl;
	bk3.print();

	/*    
	Test SortedList destructor.
	Test SortedList copy constructor.
	Test SortedList copy assignment operator.
	*/
	
    return 0;
}



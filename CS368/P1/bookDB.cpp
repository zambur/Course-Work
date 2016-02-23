/*******************************************************************************
Author: Zach Ambur
CS Login: zachary
Course: CS 368, Fall 2014
Assignment: Programming Assignment 1 
*******************************************************************************/
#include <iostream>

using namespace std;


//this struct holds all of the attributes linked to each book.  Its book id,
// publication year, and rating.
struct books {
    int bookID;
    int year;
    double rating;
};

//declairing the functions used
bool addBook(int bookID, int year, double rating);
bool updateBook(int bookID, int year, double rating);
bool deleteBook(int bookID);
void findBooks(int year);
void calculateAverageRating();
void print();

//initializing the global variables
int actualArraySize = 0;
books library[100]; //array of books, used as the database


/**
 * This is the main function of the program which handles all of the user input.
 * It asks the user to enter a command; it first checks to see if the command
 * matches with the available options and then calls other functions to process
 * the command that the user enters.
 *
 * @param none
 * @return int = 0
 */
int main() {
	bool done = false;

	//initialize the local variables
	string choice; //the command
	int bookID, year;
    double rating; //attributes
    char ch;
    
    
    
	cout << "Enter your commands at the > prompt:" << endl;
 
	while (!done) {
		cout << "> ";
                cin >> ch;

		switch (ch) {
            //add a book to the database
            case 'A':
			case 'a':
                cin >> bookID >> year >> rating;
                if (bookID < 10000 || bookID > 99999) {
                    cout << "Cannot add book: invalid ID" << endl;
                    break;
                }
                if (year > 2014 || year < 0) {
                    cout << "Cannot add book: invalid publication year" << endl;
                    break;
                }
                if (rating > 5.0 || rating < 0.0) {
                    cout << "Cannot add book: invalid rating" << endl;
                    break;
                }
                addBook(bookID, year, rating);
                break;
                
            //update and change a book in the database
            case 'U':
            case 'u':
                cin >> bookID >> year >> rating;
                if (bookID < 10000 || bookID > 99999) {
                    cout << "Cannot be updated: invalid ID" << endl;
                    break;
                }
                if (year > 2014 || year < 0) {
                    cout << "Cannot be updated: invalid publication year" << endl;
                    break;
                }
                if (rating > 5.0 || rating < 0.0) {
                    cout << "Cannot be updated: invalid rating" << endl;
                    break;
                }
                updateBook(bookID, year, rating);
                break;
                
            //delete and remove a book from the database
            case 'D':
            case 'd':
                cin >> bookID;
                if (bookID < 10000 || bookID > 99999) {
                    cout << "Cannot delete book: invalid ID" << endl;
                    break;
                }
                deleteBook(bookID);
                break;
                
            //find all books with the corresponding year
            case 'F':
            case 'f':
                cin >> year;
                if (year > 2014 || year < 0) {
                    cout << "Cannot find books: invalid publication year" << endl;
                    break;
                }
                findBooks(year);
                break;
                
            //calculate the average rating of all of the books in the database
            case 'C':
            case 'c':
                calculateAverageRating();
                break;
            
            //print out a list of all of the books in the database
            case 'P':
            case 'p':
                print();
                break;

            //quit the program
            case 'Q':
			case 'q': 
				done = true;
				cout << "quit" << endl;
				break;

			default:
                cout << "Command not recognized, please try again." << endl;
                break;
		} // end switch

	} // end while

	return 0;
}

//defining the functions that were declaired above


/**
 * Checks to see if the book is already in the database and if it is not then it
 * adds that book to the database.
 *
 * @param bookID : id of book
 * @param year : year published
 * @param rating : rating of book
 * @return true if the book was added to the database and false if it wasn't
 */
bool addBook(int bookID, int year, double rating) {
    
    if(actualArraySize > 99) {
        cout << "Cannot add book: the library is full" << endl;
        return false;
    }
    
    int checkBook = 1;
    
    books newBook = {
        bookID,
        year,
        rating
    };
    
    for (int index = 0; index < actualArraySize; index++){
        if (library[index].bookID == bookID){
            cout << "Book " << bookID << " already exists" << endl;
            checkBook = -1;
        }
    }
    
    if (checkBook == 1) {
        newBook.bookID = bookID;
        newBook.year = year;
        newBook.rating = rating;
        library[actualArraySize] = newBook;
        actualArraySize++;
        cout << "Book " << bookID << " added" << endl;
    }
    return true;
}


/**
 * Checks to see if the book is in the database and if it is in the database
 * then it will change the id, year, and rating to the new information that
 * was given by the user.
 *
 * @param bookID : id of book
 * @param year : year published
 * @param rating : rating of book
 * @return true if the book was updated and false if it wasn't
 */
bool updateBook(int bookID, int year, double rating) {
    
    if (actualArraySize == 0) {
        cout << "No entries" << endl;
        return false;
    }
    
    int checkBook = 1;
    
    books newBook = {
        bookID,
        year,
        rating
    };
    
    for (int index = 0; index < actualArraySize; index++){
        if (library[index].bookID == bookID){
            newBook.bookID = bookID;
            newBook.year = year;
            newBook.rating = rating;
            library[index] = newBook;
            cout << "Successfully updated" << endl;
            checkBook = -1;
        }
    }
    
    if (checkBook == 1) {
        cout << "Book not found" << endl;
    }
    return true;
}


/**
 * Checks to see if the book is in the database and if it is in the database than
 * it deletes that book from the array and replaces its position with the book in the
 * last position of the array so there are no gaps in the array.
 *
 * @param bookID : id of book
 * @return true if the book was deleted from the database and false if it wasn't
 */
bool deleteBook(int bookID) {
    
    if (actualArraySize == 0) {
        cout << "No entries" << endl;
        return false;
    }
    
    int checkBook = 1;

    for (int index = 0; index < actualArraySize; index++){
        if (library[index].bookID == bookID){
            library[index] = library[actualArraySize - 1];
            actualArraySize--;
            cout << "Book removed" << endl;
            checkBook = -1;
            break;
        }
    }
    
    if (checkBook == 1) {
        cout << "Book not found" << endl;
    }
    return true;
}


/**
 * Goes through the whole database and prints out any book that was published in 
 * the same year the user is looking for
 *
 * @param year : year published
 * @return void
 */
void findBooks(int year) {
    
    int checkBook = 1;
    
    for (int index = 0; index < actualArraySize; index++){
        if (library[index].year == year){
            cout << library[index].bookID << ", " << library[index].year << ", ";
            printf("%.2f\n", library[index].rating);
            checkBook = -1;
        }
    }
    
    if (checkBook == 1) {
        cout << "No entries" << endl;
    }
}


/**
 * Goes through the whole database and adds up all of the ratings for each book and then
 * divides that number by the total number of books to display the average rating of all 
 * the books
 *
 * @return void
 */
void calculateAverageRating() {
    
    double totalRatings = 0.0;
    double averageRating = 0.0;
    
    for (int index = 0; index < actualArraySize; index++){
        totalRatings = totalRatings + library[index].rating;
    }
    
    if (actualArraySize == 0) {
        cout << "No entries" << endl;
    }
    else {
        averageRating = totalRatings / actualArraySize;
        cout << "Average book rating = ";
        printf("%.2f\n", averageRating);
    }
}


/**
 * Goes through the whole database and prints out the id, publication year, and rating
 * of every book.
 *
 * @return void
 */
void print() {
    if (actualArraySize == 0) {
        cout << "No entries" << endl;
    }
    for (int index = 0; index < actualArraySize; index++){
        cout << library[index].bookID << ", " << library[index].year << ", ";
        printf("%.2f\n", library[index].rating);
    }
}


#ifndef SORTEDLIST_H
#define SORTEDLIST_H

#include "Book.h"

/*
 * SortedList class
 *
 * A SortedList is an ordered collection of Books. The Books are ordered
 * from lowest numbered book ID to highest numbered  book ID.
 */

class SortedList {

  public:
    
    SortedList();
    // Constructor for the class to initialize the list.

    bool addBook(Book *b);
    // If a book with the same ID is not already in the list, inserts 
    // the given book into the list in the appropriate place and returns
    // true.  If there is already a book in the list with the same ID
    // then the list is not changed and false is returned.

    Book* search(int bookID);
    // Searches the list for a book with the given book ID.  If the
    // book is found, it is returned; if it is not found, NULL is returned.
    
    bool printBooksByYear(int year);
    // Searches the list for a book for a given year.  If a
    // book is found, it is printed; if it is not found, false is returned. 

    bool updateBook(int ID, int year, double rating);
    //Updates a book, returns true if bookID to be updated is found, fale otherwise

    double calculateAverageRating();
    //Calculates average rating for all the books in the list

    Book* removeBook(int bookID);
    // Searches the list for a book with the given bookID.  If the 
    // book is found, the book is removed from the list and returned;
    // if no book is found with the given ID, NULL is returned.
    // Note that the Book itself is NOT deleted - it is returned - however,
    // the corresponding list node should be deleted.

    void print() const;
    // Prints out the list of books to standard output.  The books are
    // printed in order of book ID (from smallest to largest), one per line

  private:

    // Since Listnodes will only be used within the SortedList class,
    // we make it private.
    struct Listnode {    
      Book* book;
      Listnode* next;
    };

    Listnode* head; // pointer to the first node in the list
    Listnode* tail; // pointer to the last node in the list
};

#endif

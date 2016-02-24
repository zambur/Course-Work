/*******************************************************************************
Author: Zach Ambur
CS Login: zachary
Course: CS 368, Fall 2014
Assignment: Programming Assignment 2
*******************************************************************************/
#include <iostream>
#include "Book.h"
#include "SortedList.h"

using namespace std;

// Constructor for the class to initialize an empty list.
SortedList::SortedList() {
    head = NULL;
    tail = NULL;
}

/**
 * Searches the list to see if the book is not already in the list, if the book
 * is not in the list then it will add it to the end of the list. If the list is
 * empty it will make this book the head of the list. If there is already a book 
 * in the list with the same ID then the list is not changed
 *
 * @param b A pointer the the book
 * @return True if book was added to the list, false if it wasn't added
 */
bool SortedList::addBook(Book *b) {
    Listnode* curr = new Listnode();
    Listnode* newNode = new Listnode();
    newNode->book = b;
    newNode->next = NULL;
    curr = head;
    // checks if head is null
    if(head != NULL) {
        if(head->next == NULL) {
            if(head->book->getID() == newNode->book->getID()) {
                return false;
            }
            curr = newNode;
            head->next = curr;
            tail = curr;
            return true;
        }
        // increments through the list until it reaches the last node
        while (curr != NULL) {
            if (curr->book->getID() == newNode->book->getID()) {
                return false;
            }
            curr = curr->next;
        }
        // Add the book to the end of the list and mark it as tail
        curr = newNode;
        tail->next = curr;
        tail = curr;
        return true;
    }
    else {
        // Add the book to the begining of the list and mark it as head and tail
        head = newNode;
        tail = head;
        return true;
    }
    return false;
}


/**
 * Searches the list to see if the book with the given ID is in the list. Returns
 * a pointer to the book if it is in the list.
 *
 * @param bookID An int value of the ID of the book
 * @return The pointer to the book that was found. NULL if not found.
 */
Book* SortedList::search(int bookID) {
    Listnode* curr = head;
    if(head != NULL) {
        if(head->next == NULL) {
            if(head->book->getID() == bookID) {
                // If the book is in the head location
                return head->book;
            }
            // If book was not in the list
            return NULL;
        }
        // increments through the list until it reaches the last node
        while (curr != NULL) {
            if(curr->book->getID() == bookID) {
                return curr->book;
            }
            curr = curr->next;
        }
        // If book was not in the list
        return NULL;
    }
    else {
        // If head is NULL
        return NULL;
    }
}

/**
 * Searches the list to see if any books have the given publication year.
 * If any books are found with the given publication year, they are printed
 * and true is returned.
 *
 * @param year An int value of the publication year of the book
 * @return True if book(s) are printed, false if nothing is printed
 */
bool SortedList::printBooksByYear(int year) {
    bool printed = false;
    Listnode* curr = head;
    // increments through the list until it reaches the last node
    while (curr != NULL) {
        if (curr->book->getYear() == year) {
            curr->book->print();
            printed = true;
        }
        curr = curr->next;
    }
    if (printed) {
        // Book(s) were printed
        return true;
    }
    else {
        // No books were found with the given publication year
        return false;
    }
}


/**
 * Calls upon the search() function to search the list of books to see
 * if the given bookID is in the list. If the book is in the list then
 * the book is updated with the given information.
 *
 * @param ID An int value of the ID of the book
 * @param year An int value of the publication year of the book
 * @param rating A double value of the rating of the book
 * @return True if book was updated, false if no book was found
 */
bool SortedList::updateBook(int ID, int year, double rating) {
    Book* newBook = search(ID);
    if(newBook == NULL) {
        return false;
    }
    else {
        newBook->updateBook(ID, year, rating);
        return true;
    }
}


/**
 * Increments through the list of books and calculates the average 
 * rating of all of the books in the list. If there are no books in
 * the list then 0.0 is printed and returned.
 *
 * @return The calculated average rating of all the books
 */
double SortedList::calculateAverageRating() {
    double totalRatings = 0.0;
    int numBooks = 0;
    Listnode* curr = head;
    while (curr != NULL) {
        totalRatings = totalRatings + curr->book->getRating();
        numBooks++;
        curr = curr->next;
    }
    
    if (head == NULL) {
        return 0.0;
    }
    else {
        return (totalRatings / numBooks);
    }
    return 0.0;
}


/**
 * Searches the list to see if any books have the given bookID. If a book is
 * found with the given ID than it is deleted from the list and returned. The
 * list is updated with the removed book. If no book is found, NULL is returned.
 *
 * @param bookID An int value of the ID of the book
 * @return A pointer to the book that was deleted, NULL if no book was found
 */
Book* SortedList::removeBook(int bookID) {
    Book* deletedBook;
    if (head == NULL) {
        // List is empty
        return NULL;
    }
    if (head->book->getID() == bookID) {
        deletedBook = head->book;
        if (head->next == NULL) {
            // Book was the only one in the list. Removed so that now the
            //  list is empty.
            head = NULL;
            return deletedBook;
        }
        head = head->next;
        return deletedBook;
    }
    else {
        Listnode* curr = head->next;
        Listnode* prev = head;
        // increments through the list until it reaches the last node
        while (curr != NULL) {
            if (curr->book->getID() == bookID) {
                // Book is found and saved
                deletedBook = curr->book;
                // Setting the next node of the previous node to the node that
                //  follows the book.
                prev->next = curr->next;
                return deletedBook;
            }
            prev = curr;
            curr = curr->next;
        }
    }
    // Book is not in the list
    return NULL;
}


/**
 * Increments through the list of books and prints out the information about 
 * each book in the order: ID Title Year Rating
 *
 * @return void
 */
void SortedList::print() const {
    Listnode* curr = head;
    // increments through the list until it reaches the last node
    while (curr != NULL) {
        curr->book->print();
        curr = curr->next;
    }
}

void SortedList::deleteAllNodes() {
    Listnode* curr = head;
    Listnode* temp;
    
    while (curr != NULL) {
        temp = curr;
        curr = curr->next;
        cout << "Deleting book: " << temp->book->getID() << endl;
        delete temp;
    }
    
    head = NULL;
    tail = NULL;
}

SortedList::~SortedList() {
    cout << "SortedList.cpp :: Destructor called" << endl;
    deleteAllNodes();
}




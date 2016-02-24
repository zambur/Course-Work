/*******************************************************************************
Author: Zach Ambur
CS Login: zachary
Course: CS 368, Fall 2014
Assignment: Programming Assignment 2
*******************************************************************************/
#include <iostream>
#include "Book.h"

using namespace std;

// Constructs a default book with an ID of 0, year 0, and 0.0 rating
Book::Book() {
    this->bookID = 0;
    this->year = 0;
    this->rating = 0.0;
}

// Constructs a book with the given ID, 0 year, and 0.0 rating
Book::Book(int ID) {
    this->bookID = ID;
    this->year = 0;
    this->rating = 0.0;
}

// Constructs a book with the given ID, title, year, and rating
Book::Book(int ID, string title, int yr, double rating) {
    this->bookID = ID;
    this->title = title;
    this->year = yr;
    this->rating = rating;
}

/**
 * Returns the ID of the book
 *
 * @return the book ID
 */
int Book::getID() const {
    return this->bookID;
}

/**
 * Returns the title of the book
 *
 * @return the book title
 */
string Book::getTitle() const {
    return this->title;
}

/**
 * Returns the publication of the book
 *
 * @return the book publication year
 */
int Book::getYear() const {
    return this->year;
}

/**
 * Returns the rating of the book
 *
 * @return the book rating
 */
double Book::getRating() const {
    return this->rating;
}

/**
 * Updates the book with the given information.
 *
 * @param bookID  ID of the book
 * @param yr  Publication year of the book
 * @param rating  Rating of the book
 * @return void
 */
void Book::updateBook(int bookID, int yr, double rating) {
    this->bookID = bookID;
    this->year = yr;
    this->rating = rating;
}

/**
 * Prints out the information about the book.
 *
 * @return void
 */
void Book::print() const {
    cout << bookID << " " << title << " " << year << " " << rating << endl;
}
#ifndef BOOK_H
#define BOOK_H

#include <string>
using namespace std;

/*
 * Book class
 *
 * A Book object contains a book ID, publication year, and a rating.
 * 
 */
class Book{

  public:
    
    Book();
    // Constructs a default book with an ID of 0, year 0, and 0.0 rating.

    Book(int ID);
    // Constructs a book with the given ID, 0 year, and 0.0 rating.

    Book(int ID, string title, int yr, double rating);
    // Constructs a book with the given ID, year , and rating.

    // Deconstructor
    ~Book();
    
    // Accessors
    int getID() const;          // returns the book ID
    string getTitle() const;    // returns the title
    int getYear() const;        // returns the publication year
    double getRating() const;   // returns the rating

    // Methods
    void updateBook(int bookID, int yr, double rating);
    void print() const; // print out the book information 
                        // as ID title year rating

  private:
    int bookID;
    string title;
    int year;
    double rating;
};

#endif

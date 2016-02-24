# Project 2

Building off of project 1's book database, I implemented all the books with a linked list sorted by bookID

***Compile:***   
```
g++ -c Book.cpp
g++ -c SortedList.cpp
g++ Book.o SortedList.o bookDB.o -o runDB
```

=====
Commands to Enter:   
a ID title year rating :   
* Add a book to the database. Note: The title must not be in quotes and must end with a period.   
d ID :   
* Delete a book from the database   
u ID year rating :   
* Update the year and rating for a book with the given ID   
c :   
    Calculate the average rating of all the books   
f year :
    Find and print all books in the database that were published in the given year   
p :   
    Print the contents of the database ordered by bookID   
q :   
    Quit the program   
? :   
    Print out help on the commands

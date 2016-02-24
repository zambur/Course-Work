# Project 3

In P2 I largely ignored issues of proper memory management for the Book and SortedList classes. The compiler defaults for the destructors, copy constructors, and assignment operators were assumed to be good enough. For this assignment I wrote my own to ensure that memory dynamically allocated in the classes is correctly managed.

P3main.cpp is a file to test the destructors, copy constructors, and assignment operators in Book.cpp and SortedList.cpp

***Compile:***
```
g++ -c Book.cpp
g++ -c SortedList.cpp
g++ -c P3main.cpp
g++ Book.o SortedList.o P3main.o -o P3main
```

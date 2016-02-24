# Project 5

This program searches for occurrences of given word within a given file. The word and the file name will be entered as command-line arguments.

***Compile:***
```
% g++ -g findWord.cpp -o findWord 
% findWord 
Proper usage: findWord <word> <file>
where
<word> is a sequence of non-whitespace characters
<file> is the file in which to search for the word
```

***Example Program Runs:***
```
% findWord the test.txt 
Searching for 'the’ in file 'test.txt’
2 : that they do not use permeates the [C++] language. Another example
3 : will further illustrate this influence. Imagine that an integer
5 : What bit value should be moved into the topmost position? If we
6 : look at the machine level, architectural designers are divided on
8 : the most significant bit position, while on other machines the sign
9 : bit (which, in the case of a negative number, will be 1) is extended.
10 : Either case can be simulated by the other, using software, by means
occurrences of 'the’ = 13
```

```
% findWord C++ test.txt
Searching for 'C++’ in file 'test.txt’
2 : that they do not use permeates the [C++] language. Another example
13 : – p. 4, “C++ for Java Programmers”, Timothy Budd (Addison-Wesley, 1999)
occurrences of 'C++’ = 2
```

```
% findWord summer test.txt
Searching for 'summer’ in file 'test.txt’
occurrences of 'summer’ = 0
```

```
% findWord the noFile.txt
File 'noFile.txt’ could not be opened
```

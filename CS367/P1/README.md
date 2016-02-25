# Program 1

###Description

A database of counties in Wisconsin and the storms that occurred in these counties last year. For each county, 
the database will store each storm that occurred in that county as well as the storm's date, damage amount (in $). 
The program will process a text file, specified as a command-line argument, using it to construct a database of 
counties and their storms. It will then repeatedly prompt the user to choose from a set of operations and display 
the resulting output on the console window.

***Command input***

* a amount :

acquire and print the names and dates of all storms with damage amount amount on separate lines. If no storms have that amount, display "no storms found". Otherwise, print out the details in the following format:    
storm 1 name, storm 1 date

* c county_name :

If a county with the name county_name is not in the database, display "county not found". Otherwise, print out each storm in that county along with its date in the format:   
storm 1 name, storm 1 date, storm 1 damage amount

* d date :

display the storm name(s), and damage amount(s) for each storm that occurred on the given date.   
storm 1 name, storm 1 damage amount

* i :

Display the statistics

* r county_name :

remove the county with the given name from the database and display "county removed". If there is no county with the name county_name in the database, display "county not found".

* s name_county1; name_county2 :

search the database for two counties with names name_county1 and name_county2 and display "same damage amount" if the total amount of damage caused by storms in those counties are equal, or "different damage amounts" if the total amount of damage is not equal for those counties. If either of the counties are not found in the database display "counties are not valid".

* w storm_name :

Print the average damage amount for all storms with the name storm_name in the format: "average damage amount: number". If no storms in the database have the name storm_name, display "no storms found".

* x :

Display "exit" and exit the program.

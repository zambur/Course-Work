#Project 4

Program overloading arithmetic, relational, assignment, and I/O operators.

***Assignment operator (=)***   
`Date& operator=(const Date& dt)`   
Sets the current Date+ object equal to the passed in parameter and returns the current object.   
***Arithmetic operators (+, -)***
`Date operator+ (const Date&, const int n) const`   
[Non-member function]   
Returns a new Date object that represents the date that is n days after the current Date object. If a negative number is passed in causing a date before 1/1/1900, print an appropriate error message and set the date to 1/1/1900.   
`Date operator- (const Date&, const int n) const`   
[Non-member function]   
Returns a new Date object that represents the date that was n days before the current Date object. If a number is passed that results in a date before 1/1/1900, print an appropriate error message and set the date to 1/1/1900.   

***I/O operators (<<, >>)***   

* `ostream& operator << (ostream& out, const Date& dt)`   
Output the date in your choice of standard date representations (e.g. 09/06/2006, 06/09/2006, September 6, 2006, etc.). Remember that this function cannot be a member function; instead it is a friend.   
* `istream& operator >> (istream& in, Date& dt)`   
Input the date from standard in without prompts in such a way that cin >> date; works. You may assume that the user will always enter the day, month and year in the said format.  

***Relational operators (!=, <, <=, >, >=)***

* `friend bool operator!= (const Date& date1, const Date& date2)`   
Returns true if the current Date object and the parameter Date object do not represent the same date.   
* `friend bool operator < (const Date& date1, const Date& date2)`   
Returns true if the current Date object is before the parameter Date object.   
* `friend bool operator <= (const Date& date1, const Date& date2)`   
Returns true if the current Date object is before or equal to the parameter Date object.   
* `friend bool operator > (const Date& date1, const Date& date2)`   
Returns true if the current Date object is after the parameter Date object.   
* `friend bool operator >= (const Date& date1, const Date& date2)`   
Returns true if the current Date object is equal to or after the parameter Date object.   

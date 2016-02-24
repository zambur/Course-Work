/*******************************************************************************
Author: Zach Ambur
CS Login: zachary
Course: CS 368, Fall 2014
Assignment: Programming Assignment 4
*******************************************************************************/
#include <iostream>
#include <cmath>
#include <algorithm>
#include "Date.h"

using namespace std;

// Declairing functions
bool leapYear(int year);
int daysInMonth(int m, int y);

// Default constructor creating a date of 1/1/1900
Date::Date() : month(1), day(1), year(1900) {}

// Constructor creating a date with the given MM/DD/YYYY
Date::Date(int m, int d, int y) : month(m), day(d), year(y) {}

// Copy Constructor
Date::Date(const Date& dt) {
    this->month = dt.getMonth();
    this->day = dt.getDay();
    this->year = dt.getYear();
}

/**
 * Sets the current Date+ object equal to the passed in
 * parameter and returns the current object.
 *
 * @return Date& The updated current Date
 */
const Date& Date::operator= (const Date& dt) {
    this->month = dt.getMonth();
    this->day = dt.getDay();
    this->year = dt.getYear();
    return *this;
}


/**
 * Returns a new Date object that represents the date
 * that is n days after the current Date object. If a
 * negative number is passed in causing a date before 
 * 1/1/1900, print an appropriate error message and 
 * set the date to 1/1/1900.
 *
 * @return Date The updated current Date
 */
Date operator+ (const Date& date, const int n) {
    Date newDate = date;
    int m = newDate.getMonth();
    int d = newDate.getDay();
    int y = newDate.getYear();
    int daysToAdd = n;
    if (n > 0) {
    	if ((d + daysToAdd) < daysInMonth(m,y)) {
      	  d = d + daysToAdd;
    	}
    	else {
    	    while (daysToAdd > 0) {
    	            d++;
     	           if (d > daysInMonth(m,y)) {
     	               d = 1;
      	              m++;
      	              if (m > 12) {
      	                  m = 1;
      	                  y++;
      	              }
      	          }
       	         daysToAdd--;
       	 	}
       	}
    }
    else {
		daysToAdd = std::abs(daysToAdd);
		newDate = newDate - daysToAdd;
		return newDate;
    }
    newDate.setDate(m,d,y);
    return newDate;
}


/**
 * Returns a new Date object that represents the date
 * that was n days before the current Date object. If
 * a number is passed that results in a date before
 * 1/1/1900, print an appropriate error message and
 * set the date to 1/1/1900.
 *
 * @return Date The updated current Date
 */
Date operator- (const Date& date, const int n) {
	Date newDate = date;
    int m = newDate.getMonth();
    int d = newDate.getDay();
    int y = newDate.getYear();
    int daysToAdd = n;
    if (n > 0) {
    	if ((d - daysToAdd) > 0) {
      	  	d = d - daysToAdd;
    	}
    	else {
    	    while (daysToAdd > 0) {
    	        	d--;
     	           	if (d < 1) {
     	           		m--;
      	              	if (m < 1) {
      	                 	m = 12;
      	                 	d = daysInMonth(m,y);
      	                	y--;
      	                  	if (y < 1900) {
      	                  		m = 1;
      	                  		d = 1;
      	                  		y = 1900;
      	                  		cout << "Can't go before 1/1/1900" << endl;
      	                  		break;
      	                 	}
      	          		}
      	          		d = daysInMonth(m,y);
      	          	}
       	         	daysToAdd--;
       	 	}
       	}
    }
    else {
    	daysToAdd = std::abs(daysToAdd);
		newDate = newDate + daysToAdd;
		return newDate;
    }
    newDate.setDate(m,d,y);
    return newDate;
}


/**
 * Returns true if the current Date object and the
 * parameter Date object do not represent the same date.
 *
 * @return True if dates dont equal
 */
bool operator!= (const Date& date1, const Date& date2) {
    if (date1.day == date2.day) {
        if (date1.month == date2.month) {
            if (date1.year == date2.year) {
                return false;
            }
        }
    }
    return true;
}


/**
 * Returns true if the current Date object is before
 * the parameter Date object.
 *
 * @return True if date is before the one passed
 */
bool operator < (const Date& date1, const Date& date2) {
    if (date1.year > date2.year) {
        return false;
    }
    if (date1.month > date2.month) {
        return false;
    }
    if (date1.day > date2.day) {
        return false;
    }
    if (!(date1 != date2)) {
        return false;
    }
    return true;
}


/**
 * Returns true if the current Date object is before
 * or equal to the parameter Date object.
 *
 * @return True if date is before or equal the one passed
 */
bool operator <= (const Date& date1, const Date& date2) {
    if (date1.year > date2.year) {
        return false;
    }
    if (date1.month > date2.month) {
        return false;
    }
    if (date1.day > date2.day) {
        return false;
    }
    return true;
}

/**
 * Returns true if the current Date object is after
 * the parameter Date object.
 *
 * @return True if date is after the one passed
 */
bool operator > (const Date& date1, const Date& date2) {
    if (date1.year < date2.year) {
        return false;
    }
    if (date1.month < date2.month) {
        return false;
    }
    if (date1.day < date2.day) {
        return false;
    }
    if (!(date1 != date2)) {
        return false;
    }
    return true;
}


/**
 * Returns true if the current Date object is after
 * or equal to the parameter Date object.
 *
 * @return True if date is after or equal the one passed
 */
bool operator >= (const Date& date1, const Date& date2) {
    if (date1.year < date2.year) {
        return false;
    }
    if (date1.month < date2.month) {
        return false;
    }
    if (date1.day < date2.day) {
        return false;
    }
    return true;
}


/**
 * Overrides the cin istream to take in the date that
 * the user entered and removes all unnessisary white
 * spaces and parses the date into the MM/DD/YYYY form
 *
 */
istream& operator>> (istream& in, Date& dt) {
    int m, d, y;
    string date;
    std::getline(in,date);
    date.erase(std::remove_if(date.begin(), date.end(), ::isspace), date.end());
    int count = 0;
    int i = 0;
    while(i < date.length()) {
        if (date[i] == '/') {
            if (count == 0) {
                m = std::stoi(date.substr(0,i));
            }
            if (count == 1) {
                d = std::stoi(date.substr(0,i));
            }
            date.erase (0,i+1);
            count++;
        }
        else
            i++;
    }
    y = std::stoi(date);
    dt.setDate(m,d,y);
    return in;
}

/**
 * Overrides the cout ostream to print the date to
 * the user in the form of MM/DD/YYYY
 * Calls upon print()
 *
 */
ostream& operator<< (ostream& out, const Date& n) {
    n.print(out);
    return out;
}

/**
 * Prints out the date in the form of MM/DD/YYYY.
 *
 * @return void
 */
void Date::print(ostream& out) const {
    out << this->getMonth() << "/" << this->getDay()
        << "/" << this->getYear();
}

/**
 * Returns the day of the date
 *
 * @return the day
 */
int Date::getDay() const {
    return this->day;
}

/**
 * Returns the month of the date
 *
 * @return the month
 */
int Date::getMonth() const {
    return this->month;
}

/**
 * Returns the year of the date
 *
 * @return the year
 */
int Date::getYear() const {
    return this->year;
}

/**
 * Sets the date object with the given values only if 
 * values are valid.
 *
 * @param m  Month of the date
 * @param d  Day of the date
 * @param y  Year of the date
 * @return True if all values are valid, false if not valid
 */
bool Date::setDate(int m, int d, int y) {
    if (m > 12 || m < 1) {
        cout << "Invalid month. Date set to Default." << endl;
        return false;
    }
    if (d > 31 || d < 1) {
        cout << "Invalid day. Date set to Default." << endl;
        return false;
    }
    if (y < 1900) {
        cout << "Invalid year. Date set to Default." << endl;
        return false;
    }
    if (m == 2) {
        if (leapYear(y) && d < 30) {
            this->month = m;
            this->day = d;
            this->year = y;
            return true;
        }
    }
    if (m == 4 || m == 6 || m == 9 || m == 11) {
        if (d > 30) {
            cout << "Invalid day: That month does not have that many days. Date set to Default." << endl;
            return false;
        }
    }
    if (m == 2 && d > 28) {
        cout << "Invalid day: That month does not have that many days. Date set to Default." << endl;
        return false;
    }
    this->month = m;
    this->day = d;
    this->year = y;
    return true;
}


/**
 * With the given year it finds out if that year is a leap
 * year or not.
 *
 * @param year  Year of the date
 * @return True if the date is a leap year
 */
bool leapYear(int year) {
    if (year%4 == 0 && year%100 != 0) {
        return true;
    }
    else if (year%400 == 0) {
        return true;
    }
    return false;
}


/**
 * Takes in the month and year of the date and returns the 
 * number of days in that month. It takes leap year into 
 * account.
 *
 * @param m  Month of the date
 * @param y  Year of the date
 * @return int of the number of days in the given month
 */
int daysInMonth(int m, int y) {
    if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) {
        return 31;
    }
    if (m == 4 || m == 6 || m == 9 || m == 11) {
        return 30;
    }
    if (m == 2 && leapYear(y)) {
        return 29;
    }
    if (m == 2) {
        return 28;
    }
    return -1;
}






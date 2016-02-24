/*******************************************************************************
 Author: Zach Ambur
 CS Login: zachary
 Course: CS 368, Fall 2014
 Assignment: Programming Assignment 4
 *******************************************************************************/
#include <iostream>
#include "Date.h"

using namespace std;

int main() {
    Date date1, date2;
    cout << "Enter a date: ";
    cin >> date1;
    cout << "Enter another date: ";
    cin >> date2;
    cout << "Date 1 is: " << date1 << endl;
    cout << "Date 2 is: " << date2 << "\n\n";
    
    if (date1 != date2)
        cout << date1 << " doesn't match " << date2 << endl;
    else
        cout << date1 << " matches " << date2 << endl;
    
    if (date1 < date2)
        cout << date1 << " comes before " << date2 << endl;
    else
        cout << date1 << " does not comes before " << date2 << endl;

    if (date1 <= date2)
        cout << date1 << " comes before or on " << date2 << endl;
    else
        cout << date1 << " does not comes before or on " << date2 << endl;

    if (date1 > date2)
        cout << date1 << " comes after " << date2 << endl;
    else
        cout << date1 << " does not comes after " << date2 << endl;

    if (date1 >= date2)
        cout << date1 << " comes after or on " << date2 << "\n\n";
    else
        cout << date1 << " does not comes after or on " << date2 << "\n\n";
    
    Date date1Up, date2Up;
    cout << "Enter a date to update Date 1: ";
    cin >> date1Up;
    date1.setDate(date1Up.getMonth(), date1Up.getDay(), date1Up.getYear());
    
    cout << "Enter a date to update Date 2: ";
    cin >> date2Up;
    date2.setDate(date2Up.getMonth(), date2Up.getDay(), date2Up.getYear());
    
    cout << "Date 1 is now: " << date1 << endl;
    cout << "Date 2 is now: " << date2 << endl;
    
    int n;
    cout << "Enter a number of days to add to Date 1: ";
    cin >> n;
    date1 = date1 + n;
    cout << "Date 1 is now: " << date1 << endl;
    
    cout << "Enter a number of days to subtract from Date 2: ";
    cin >> n;
    date2 = date2 - n;
    cout << "Date 2 is now: " << date2 << "\n\n";
    
    if (date1 != date2)
        cout << date1 << " doesn't match " << date2 << endl;
    else
        cout << date1 << " matches " << date2 << endl;
    
    if (date1 < date2)
        cout << date1 << " comes before " << date2 << endl;
    else
        cout << date1 << " does not comes before " << date2 << endl;
    
    if (date1 <= date2)
        cout << date1 << " comes before or on " << date2 << endl;
    else
        cout << date1 << " does not comes before or on " << date2 << endl;
    
    if (date1 > date2)
        cout << date1 << " comes after " << date2 << endl;
    else
        cout << date1 << " does not comes after " << date2 << endl;
    
    if (date1 >= date2)
        cout << date1 << " comes after or on " << date2 << endl;
    else
        cout << date1 << " does not comes after or on " << date2 << endl;

    return 0;
}

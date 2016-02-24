# Assignment 3

This assignment consists of 2 programs which use specific software interrupts, requiring a capture of the interrupts to be handled, as well as handling code.

### Program 1 : A Periodic Alarm

C program called intdate.c that is composed of two parts. One part is the main program, which does absolutely nothing in an infinite loop. Before entering the infinite loop, the main program will set up what is to happen when an alarm goes off 3 seconds later. When the alarm goes off, this causes a SIGALRM interrupt to signal the program. This interrupt is to be caught by the program, and handled by the second part of the program, an interrupt handler. This handler function is to print out the current time, in the same format as the Unix date program, re-arm the alarm to go off three seconds later, and then return back to the main program. The program only exits after the user types Control-c 5 times.

***Sample Program Run:***
```
Date will be printed every 3 seconds.
Enter ^C 5 times to end the program:
^C
Control-c caught. 4 more before program is ended.

current time is Thu Feb 26 15:15:51 2015
^C
Control-c caught. 3 more before program is ended.
^C
Control-c caught. 2 more before program is ended.
^C
Control-c caught. 1 more before program is ended.

current time is Thu Feb 26 15:15:54 2015
^C
Final Control-c caught. Exiting.
```

### Program 2 : Some Division

Prompts user for two integer values and then calculate the quotient and remainder of doing the integer division operation: int1 / int2, printing these results, and keeping track of how many division operations were successfully completed. A Control-c will cause this program to stop running.

***Sample Program Run:***
```
Enter first integer: 12
Enter second integer: 2
12 / 2 is 6 with a remainder of 0
Enter first integer: 100
Enter second integer: -7
100 / -7 is -14 with a remainder of 2
Enter first integer: 10
Enter second integer: 20
10 / 20 is 0 with a remainder of 10
Enter first integer: ab17
Enter second integer: 3
0 / 3 is 0 with a remainder of 0
Enter first integer: ^C
```

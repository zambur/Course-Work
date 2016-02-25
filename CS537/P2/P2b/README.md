# xv6 Program 2

In this project, I created a new scheduler into xv6. It is called a simple priority-based scheduler. The basic idea is simple: assign each running process a priority, which is an integer number, in this case either 1 (low priority) or 2 (high priority). At any given instance, the scheduler should run processes that have the high priority (2). If there are two or more processes that have the same high priority, the scheduler should round-robin between them. A low-priority (level 1) process does NOT run as long as there are high-priority jobs available to run. 

###Files

***kernel*** - kernel and booting   
***user*** - user level programs   
***include*** - shared header files for both kernel and user   
***tools*** - tools to run on the host machine   
***README*** - project description   
***Makefile*** - build instructions for GNU make   

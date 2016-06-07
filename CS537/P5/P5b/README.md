# xv6 Kernel File System with Small File Optimization

In this project, I changed the existing xv6 file system to add high-performance support for small files. The basic idea 
is simple: if you have a small file (say, just a few bytes in size), instead of allocating a data block for it, instead 
just store the data itself inside the inode, thus speeding up access to the small file (as well as saving some disk space). 
Because the inode has some number of slots for block addresses (specifically, NDIRECT for direct pointers, and 1 more for 
an indirect pointer), I was able to store (NDIRECT + 1) * 4 bytes in the inode for these small files (52 bytes or 
less).

###Files

***kernel*** - kernel and booting   
***user*** - user level programs   
***include*** - shared header files for both kernel and user   
***tools*** - tools to run on the host machine   
***README*** - project description   
***Makefile*** - build instructions for GNU make 

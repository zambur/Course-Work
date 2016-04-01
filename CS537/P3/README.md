# Program 3

In this project, I changed xv6 to support a feature virtually every modern OS does: causing an exception to occur when your program dereferences a null pointer. I also added a new simple facility to allow different processes to share a memory page.

The basic process is fairly simple: there is a new system call I created, called void *shmem_access(int page_number), which makes a shared page available to the process calling it. The page_number argument can range from 0 through 3, and allows for four different pages to be used in this manner. When a process calls shmem_access(0), the OS maps a physical page into the virtual address space of the caller, starting at the very high end of the address space. The call then returns the virtual address of that page to the caller, so it can read/write it. If another process then calls shmem_access(0), it should also get the page mapped into its virtual address space (possibly at a different virtual address), and also read/write it. In this way, the processes can communicate, by reading/writing shared memory.

One other call that I implemented: int shmem_count(int page_number). This call gets, for a particular shared page, how many processes currently are sharing that page.

###Files

***kernel*** - kernel and booting   
***user*** - user level programs   
***include*** - shared header files for both kernel and user   
***tools*** - tools to run on the host machine   
***README*** - project description   
***Makefile*** - build instructions for GNU make   

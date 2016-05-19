## xv6 Kernel Threads

In this project, I added real kernel threads to xv6. Specifically, there were three main things I did. First, I defined a new system call to create a kernel thread, called clone() , as well as one to wait for a thread called join() . Then, I used clone() to build a little thread library, with a thread_create() call and lock_acquire() and lock_release() functions. Finally, I showed how these things work by using the TA's tests. That's it! And now, for some details.

The new clone system call creates a new kernel thread which shares the calling process's address space. File descriptors are copied as in fork. The new process uses stack as its user stack, which is passed the given argument arg and uses a fake return PC (0xffffffff). The stack is one page in size and page-aligned. The new thread starts executing at the address specified by fcn. As with fork(), the PID of the new thread is returned to the parent.

The other system call join waits for a child thread that shares the address space with the calling process. It returns the PID of waited-for child or -1 if none. The location of the child's user stack is copied into the argument stack.

My thread library is built on top of this, and just has a simple thread_create(void (*start_routine)(void*), void *arg) routine. This routine calls malloc() to create a new user stack, uses clone() to create the child thread and get it running. A thread_join() call is also used, which calls the underlying join() system call, frees the user stack, and then returns.

My thread library also has a simple spin lock. There is a type lock_t that one uses to declare a lock, and two routines lock_acquire(lock_t *) and lock_release(lock_t *) , which acquire and release the lock. The spin lock uses x86 atomic exchange to built the spin lock. One last routine, lock_init(lock_t *) , is used to initialize the lock as need be.

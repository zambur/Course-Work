#include "types.h"
#include "stat.h"
#include "fcntl.h"
#include "user.h"
#include "x86.h"
#include "param.h"

#define PGSIZE 4096

int thread_create(void (*start_routine)(void*), void *arg) {
	
	//Malloc page
	void *ptr = malloc(2 * PGSIZE);
	
	//align page
	ptr = ptr + (PGSIZE - (uint)ptr % PGSIZE);
	
	return clone(start_routine, arg, ptr);
}

int thread_join() {
	
	void* stack;
	
	int pid = join(&stack);
	
	free(stack);
	
	return pid;
}

void lock_acquire(lock_t* lock) {
	while(xchg(&lock->locked,1) == 1) {
		;
	}
}

void lock_release(lock_t* lock) {
	lock->locked = 0;
}

void lock_init(lock_t* lock) {
	lock->locked = 0;
}
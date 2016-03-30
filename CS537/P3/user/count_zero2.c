#include "types.h"
#include "stat.h"
#include "user.h"

void
test_failed()
{
	printf(1, "TEST FAILED\n");
	exit();
}

void
test_passed()
{
 printf(1, "TEST PASSED\n");
 exit();
}

int
main(int argc, char *argv[])
{
	void *ptr;
 	int n;
	int i;
	
	for (i = 0; i < 4; i++) {
		n = shmem_count(i);
		if (n != 0) {
			test_failed();
		}
	}

	int pid = fork();
	if (pid < 0) {
		test_failed();
	}
	else if (pid == 0) {
		for (i = 0; i < 4; i++) {
			ptr = shmem_access(i);
			if (ptr == NULL) {
				test_failed();
			}
		}
		exit();	
	}
	else {
		wait();
		
		for (i = 0; i < 4; i++) {
			n = shmem_count(i);
			if (n != 0) {
				test_failed();
			}
		}
	}
	
	test_passed();
	exit();
}

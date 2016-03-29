#include "types.h"
#include "stat.h"
#include "user.h"
#include "param.h"

#define PGSIZE 4096

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

	ptr = shmem_access(2);
	if (ptr == NULL) {
		test_failed();
	}

	if (((int) ptr) != USERTOP - PGSIZE*1) {
		test_failed();
	}

	ptr = shmem_access(3);
	if (ptr == NULL) {
		test_failed();
	}

	if (((int) ptr) != USERTOP - PGSIZE*2) {
		test_failed();
	}

	ptr = shmem_access(0);
	if (ptr == NULL) {
		test_failed();
	}

	if (((int) ptr) != USERTOP - PGSIZE*3) {
		test_failed();
	}

	ptr = shmem_access(1);
	if (ptr == NULL) {
		test_failed();
	}

	if (((int) ptr) != USERTOP - PGSIZE*4) {
		test_failed();
	}
	
	test_passed();
	exit();
}

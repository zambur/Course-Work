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
 	int n;
	
	n = shmem_count(-1);
	if (n != -1) {
		test_failed();
	}

	n = shmem_count(-100);
	if (n != -1) {
		test_failed();
	}

	n = shmem_count(4);
	if (n != -1) {
		test_failed();
	}

	n = shmem_count(100);
	if (n != -1) {
		test_failed();
	}

	test_passed();
	exit();
}

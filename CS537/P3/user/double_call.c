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
	void *ptr2;
	
	ptr = shmem_access(3);
	if (ptr == NULL) {
		test_failed();
	}

	ptr2 = shmem_access(3);
	if (ptr == NULL) {
		test_failed();
	}

	if (ptr != ptr2) {
		test_failed();
	}

	test_passed();
	exit();
}

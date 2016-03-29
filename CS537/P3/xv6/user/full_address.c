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
  
	while (1) {
		ptr = sbrk(1024);
		if (ptr == (char *) -1) {
			break;
		}
	}
	
	ptr = shmem_access(0);
	if (ptr != NULL) {
		test_failed();
	}

	test_passed();
	exit();
}

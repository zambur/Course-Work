/* write to a chunk from Mem_Alloc and check the value*/
#include <assert.h>
#include <stdlib.h>
#include "mem.h"

int main() {
   assert(Mem_Init(4096) == 0);
   int* ptr = (int*) Mem_Alloc(sizeof(int));
   assert(ptr != NULL);
   *ptr = 42;   // check pointer is in a writeable page
   assert(*ptr == 42);
   exit(0);
}

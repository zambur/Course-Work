/* first pointer returned is 4-byte aligned */
#include <assert.h>
#include <stdlib.h>
#include <stdint.h>
#include "mem.h"

int main() {
   assert(Mem_Init(4096) == 0);
   int* ptr = (int*) Mem_Alloc(sizeof(int));
   assert(ptr != NULL);
   assert((int)ptr % 4 == 0);
   exit(0);
}

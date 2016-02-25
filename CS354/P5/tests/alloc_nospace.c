/* allocation is too big to fit in available space */
#include <assert.h>
#include <stdlib.h>
#include "mem.h"

int main() {
   assert(Mem_Init(4096) == 0);
   assert(Mem_Alloc(4095) == NULL); 
   exit(0);
}

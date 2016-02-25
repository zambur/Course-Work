/* check for coalesce free space */
#include <assert.h>
#include <stdlib.h>
#include "mem.h"

int main() {
   assert(Mem_Init(4096) == 0);
   void * ptr[5];

   ptr[0] = Mem_Alloc(600);
   assert(ptr[0] != NULL);

   ptr[1] = Mem_Alloc(600);
   assert(ptr[1] != NULL);

   ptr[2] = Mem_Alloc(600);
   assert(ptr[2] != NULL);

   ptr[3] = Mem_Alloc(600);
   assert(ptr[3] != NULL);

   ptr[4] = Mem_Alloc(600);
   assert(ptr[4] != NULL);

   while (Mem_Alloc(600) != NULL)
     ;

   assert(Mem_Free(ptr[1]) == 0);
   assert(Mem_Free(ptr[3]) == 0);
   assert(Mem_Free(ptr[2]) == 0);

   ptr[2] = Mem_Alloc(1800);
   assert(ptr[2] != NULL);

   exit(0);
}

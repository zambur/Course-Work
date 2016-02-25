/* check for coalesce free space */
#include <assert.h>
#include <stdlib.h>
#include "mem.h"

int main() {
   assert(Mem_Init(4096) == 0);
   void * ptr[7];

   ptr[0] = Mem_Alloc(500);
   assert(ptr[0] != NULL);

   ptr[1] = Mem_Alloc(500);
   assert(ptr[1] != NULL);

   ptr[2] = Mem_Alloc(500);
   assert(ptr[2] != NULL);

   ptr[3] = Mem_Alloc(500);
   assert(ptr[3] != NULL);

   ptr[4] = Mem_Alloc(500);
   assert(ptr[4] != NULL);

   ptr[5] = Mem_Alloc(500);
   assert(ptr[5] != NULL);

   ptr[6] = Mem_Alloc(500);
   assert(ptr[6] != NULL);

   while (Mem_Alloc(500) != NULL)
     ;

   assert(Mem_Free(ptr[1]) == 0);
   assert(Mem_Free(ptr[5]) == 0);
   assert(Mem_Free(ptr[2]) == 0);
   assert(Mem_Free(ptr[4]) == 0);
   assert(Mem_Free(ptr[3]) == 0);

   ptr[2] = Mem_Alloc(2500);
   assert(ptr[2] != NULL);

   exit(0);
}

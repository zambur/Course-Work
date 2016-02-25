/* check for coalesce free space */
#include <assert.h>
#include <stdlib.h>
#include "mem.h"

int main() {
   assert(Mem_Init(4096) == 0);
   void * ptr[4];

   ptr[0] = Mem_Alloc(800);
   assert(ptr[0] != NULL);

   ptr[1] = Mem_Alloc(800);
   assert(ptr[1] != NULL);

   ptr[2] = Mem_Alloc(800);
   assert(ptr[2] != NULL);

   ptr[3] = Mem_Alloc(800);
   assert(ptr[3] != NULL);
//Mem_Dump();
   while (Mem_Alloc(800) != NULL)
     ;

   assert(Mem_Free(ptr[1]) == 0);
Mem_Dump();
   assert(Mem_Free(ptr[2]) == 0);
Mem_Dump();
   ptr[2] = Mem_Alloc(1600);
//Mem_Dump();
   assert(ptr[2] != NULL);
//Mem_Dump();
   exit(0);
}

/* Check for best fit implementation */
#include <assert.h>
#include <stdlib.h>
#include "mem.h"

int main() {
   assert(Mem_Init(4096) == 0);
   void* ptr[9];
   void* test;

   ptr[0] = Mem_Alloc(300);
   assert(ptr[0] != NULL);

   ptr[1] = Mem_Alloc(200);
   assert(ptr[1] != NULL);

   ptr[2] = Mem_Alloc(200);
   assert(ptr[2] != NULL);

   ptr[3] = Mem_Alloc(100);
   assert(ptr[3] != NULL);

   ptr[4] = Mem_Alloc(200);
   assert(ptr[4] != NULL);

   ptr[5] = Mem_Alloc(800);
   assert(ptr[5] != NULL);

   ptr[6] = Mem_Alloc(500);
   assert(ptr[6] != NULL);

   ptr[7] = Mem_Alloc(700);
   assert(ptr[7] != NULL);

   ptr[8] = Mem_Alloc(300);
   assert(ptr[8] != NULL);

   assert(Mem_Free(ptr[1]) == 0);
   assert(Mem_Free(ptr[3]) == 0);
   assert(Mem_Free(ptr[5]) == 0);
   assert(Mem_Free(ptr[7]) == 0);

   test = Mem_Alloc(50);
   assert(
           (
             ((unsigned long int)test >= (unsigned long int)ptr[3])
             &&
             ((unsigned long int)test < (unsigned long int)ptr[4])
           )
           ||
           (
             ((unsigned long int)test >= (unsigned long int)ptr[3])
             &&
             ((unsigned long int)test < (unsigned long int)ptr[2])
           )
         );
   exit(0);
}

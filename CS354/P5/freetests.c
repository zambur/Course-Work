/******************************************************************************
 * FILENAME: freetests.c
 * AUTHOR:   Zach Ambur 
 * SECTION:  001
 * DATE:     13 Dec 2015
 * *****************************************************************************/
#include <assert.h>
#include <stdlib.h>
#include "mem.h"

int main() {
   assert(Mem_Init(4096) == 0);
   void* ptr[2];
   void* n_ptr = NULL;

   // Testing a single assertion followed by a free call
   ptr[0] = Mem_Alloc(32);
   assert(Mem_Free(ptr[0]) == 0);
	
   // Testing bad input parameters to Mem_Free()
   ptr[1] = Mem_Alloc(16);
   assert(Mem_Free(ptr[3]) == -1);
   assert(Mem_Free(n_ptr) == -1);

   exit(0);
}

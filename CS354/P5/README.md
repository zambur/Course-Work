# Assignment 5

Creating and implementing my own memory allocation functions malloc() and free()

***void *Mem_Alloc(int size)***

Mem_Alloc() is similar to the library function malloc(). Mem_Alloc takes as an input parameter the size in bytes of the memory space to be allocated, and it returns a pointer to the start of that memory space. The function returns NULL if there is not enough contiguous free space within sizeOfRegion allocated by Mem_Init to satisfy this request. For better performance, Mem_Alloc() is to return 4-byte aligned chunks of memory. For example if a user requests 1 byte of memory, the Mem_Alloc() implementation should return 4 bytes of memory, so that the next free block will also be 4-byte aligned.

***int Mem_Free(void *ptr)***

Mem_Free() frees the memory object that ptr points to. Just like with the standard free(), if ptr is NULL, then no operation is performed. The function returns 0 on success and -1 if the ptr was not allocated by Mem_Alloc(). If ptr is NULL, also return -1.

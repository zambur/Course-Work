/******************************************************************************
 * FILENAME: mem.c
 * AUTHOR:   Zach Ambur 
 * SECTION:  001
 * DATE:     13 Dec 2015
 * *****************************************************************************/

#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <sys/mman.h>
#include <string.h>
#include "mem.h"

/* this structure serves as the header for each block */
typedef struct block_hd{
    /* The blocks are maintained as a linked list */
    /* The blocks are ordered in the increasing order of addresses */
    struct block_hd* next;
    
    /* size of the block is always a multiple of 4 */
    /* ie, last two bits are always zero - can be used to store other information*/
    /* LSB = 0 => free block */
    /* LSB = 1 => allocated/busy block */
    
    /* For free block, block size = size_status */
    /* For an allocated block, block size = size_status - 1 */
    
    /* The size of the block stored here is not the real size of the block */
    /* the size stored here = (size of block) - (size of header) */
    int size_status;
    
}block_header;

/* Global variable - This will always point to the first block */
/* ie, the block with the lowest address */
block_header* list_head = NULL;


/* Function used to Initialize the memory allocator */
/* Not intended to be called more than once by a program */
/* Argument - sizeOfRegion: Specifies the size of the chunk which needs to be allocated */
/* Returns 0 on success and -1 on failure */
int Mem_Init(int sizeOfRegion)
{
    int pagesize;
    int padsize;
    int fd;
    int alloc_size;
    void* space_ptr;
    static int allocated_once = 0;
    
    if(0 != allocated_once)
    {
        fprintf(stderr,"Error:mem.c: Mem_Init has allocated space during a previous call\n");
        return -1;
    }
    if(sizeOfRegion <= 0)
    {
        fprintf(stderr,"Error:mem.c: Requested block size is not positive\n");
        return -1;
    }
    
    /* Get the pagesize */
    pagesize = getpagesize();
    
    /* Calculate padsize as the padding required to round up sizeOfRegio to a multiple of pagesize */
    padsize = sizeOfRegion % pagesize;
    padsize = (pagesize - padsize) % pagesize;
    
    alloc_size = sizeOfRegion + padsize;
    
    /* Using mmap to allocate memory */
    fd = open("/dev/zero", O_RDWR);
    if(-1 == fd)
    {
        fprintf(stderr,"Error:mem.c: Cannot open /dev/zero\n");
        return -1;
    }
    space_ptr = mmap(NULL, alloc_size, PROT_READ | PROT_WRITE, MAP_PRIVATE, fd, 0);
    if (MAP_FAILED == space_ptr)
    {
        fprintf(stderr,"Error:mem.c: mmap cannot allocate space\n");
        allocated_once = 0;
        return -1;
    }
    
    allocated_once = 1;
    
    /* To begin with, there is only one big, free block */
    list_head = (block_header*)space_ptr;
    list_head->next = NULL;
    /* Remember that the 'size' stored in block size excludes the space for the header */
    list_head->size_status = alloc_size - (int)sizeof(block_header);
    
    return 0;
}


/* Function for allocating 'size' bytes. */
/* Returns address of allocated block on success */
/* Returns NULL on failure */
/* Here is what this function should accomplish */
/* - Check for sanity of size - Return NULL when appropriate */
/* - Round up size to a multiple of 4 */
/* - Traverse the list of blocks and allocate the first free block which can accommodate the requested size */
/* -- Also, when allocating a block - split it into two blocks when possible */
/* Tips: Be careful with pointer arithmetic */
void* Mem_Alloc(int size)
{
    /*iterator for list*/
    block_header* itr;
    /*Size needed including header*/
    int neededsize;
    /* to temporary store the values before moving*/
    block_header temp;
    
    /*make sure the size is more than 0*/
    if(size <= 0){
        return NULL;
    }
    
    /*round up the size to multiple of 4*/
    if(size%4 != 0){
        /*increase the size to a multiple of 4*/
        size = size + 4-(size%4);
    }
    
    /*Initialize the iterator*/
    itr =  list_head;
    
    /*check if header is not Initialize*/
    if(itr == NULL){
        fprintf(stderr,"Error: Please Call Mem_Init before Mem_Alloc\n");
        return NULL;
    }
    
    /*Calculate the total number of bytes needed including header*/
    neededsize = size + sizeof(block_header);
    
    /*Loop through the whole block list*/
    while(itr != NULL){
        
        /*check if the current block is busy*/
        /*If its a busy block, move the next block*/
        if( itr->size_status & 1){
            itr = itr->next;
            continue;
        }
        
        /*Check if there is enough space in this block.*/
        /*If enough space, create new block */
        if(itr->size_status >= neededsize){
            
            /*Store the previous value*/
            temp = *itr;
            
            /*update the size and and mark it as busy */
            itr->size_status = size + 1;
            /*move the next pointer to the next location*/
            itr->next = (block_header*)((char *)itr + neededsize);
            
            /*update the following node*/
            itr->next->size_status = temp.size_status - neededsize;
            itr->next->next = temp.next;
            
            /*return pointer to the object*/
            return (void*)((char*)itr + sizeof(block_header));
        }
        else{
            /*Not enough space, move to next block*/
            /*move to the next block*/
            itr = itr->next;
        }
    }
    /*If reach the end of linklist,means not enough space
     ,return NULL*/
    return NULL;
}

/* Function for freeing up a previously allocated block */
/* Argument - ptr: Address of the block to be freed up */
/* Returns 0 on success */
/* Returns -1 on failure */
/* Here is what this function should accomplish */
/* - Return -1 if ptr is NULL */
/* - Return -1 if ptr is not pointing to the first byte of a busy block */
/* - Mark the block as free */
/* - Coalesce if one or both of the immediate neighbours are free */
int Mem_Free(void *ptr)
{
    /*Iterator for the linked list*/
    block_header* itr;
    /*to save the previous node*/
    block_header* prev;
    /*to check the size*/
    int sizeCheck;
    /*to temporary hold the size*/
    int temp;
    
    /*Make sure the pointer is not NULL*/
    if(ptr == NULL){
        return -1;
    }
    
    /*Make sure the pointer is pointing towards the first byte*/
    if(((block_header*)(ptr - sizeof(block_header)))->size_status <= 0){
        return -1;
    }
    
    
    sizeCheck =( (block_header*)(ptr - sizeof(block_header)) )->size_status;
    //check if the block header has the correct size, also check if its valid;
    temp = (void*)(( (block_header*)(ptr - sizeof(block_header)) )->next) - ptr;
    //if the size is different, means the pointer is invalid.
    if(sizeCheck-1 != temp){
        return -1;
    }
    
    
    
    /*set the start of the iterator*/
    itr =  list_head;
    /*initialize the prev values as null*/
    prev = NULL;
    
    /*check if header is Null*/
    if(itr == NULL){
        fprintf(stderr,"Error: Please Call Mem_Init before Mem_Alloc\n");
        return -1;
    }
    
    /*Loop through the link list*/
    while(itr != NULL){
        
        /*check if its the correct pointer*/
        if((void*)((char*)itr + sizeof(block_header)) == ptr){
            
            /*check if the block is a Busy block
             If yes, delete the block*/
            if((itr->size_status) & 1){
                
                /*change the size to the correct size.*/
                itr->size_status = itr->size_status - 1;
                
                /*check if the next space is not NULL and is free
                 If true, coalesce the free space */
                if( itr->next != NULL && (!(itr->next->size_status & 1))){
                    /*Update the size of the block with the size of the
                     free space and header*/
                    itr->size_status = itr->size_status + (int)sizeof(block_header)
                    + (itr->next->size_status);
                    /*Set the next to be the next of the free block*/
                    itr->next = itr->next->next;
                }
                
                /*if the previous node is not the head(if its not NULL)
                 and is not empty.
                 If true, coalesce the free space */
                if(prev != NULL && (!(prev->size_status & 1))){
                    /*Update the size of the block with the size of the
                     free space and header*/
                    prev->size_status = itr->size_status + sizeof(block_header)
                    + (prev->size_status);
                    /*Set the new next for the block*/
                    prev->next = itr->next;
                }
                /*success, return 0*/
                return 0;
            }
            /*this means invalid pointer, as the pointer points to a freed block.*/
            else{
                return -1;
            }
        }
        /*move to the next blook*/
        prev = itr;
        itr = itr->next;
    }
    /*cannot find the pointer in the link list.
     return -1(error)*/
    return -1;
}

/* Function to be used for debug */
/* Prints out a list of all the blocks along with the following information for each block */
/* No.      : Serial number of the block */
/* Status   : free/busy */
/* Begin    : Address of the first useful byte in the block */
/* End      : Address of the last byte in the block */
/* Size     : Size of the block (excluding the header) */
/* t_Size   : Size of the block (including the header) */
/* t_Begin  : Address of the first byte in the block (this is where the header starts) */
void Mem_Dump()
{
    int counter;
    block_header* current = NULL;
    char* t_Begin = NULL;
    char* Begin = NULL;
    int Size;
    int t_Size;
    char* End = NULL;
    int free_size;
    int busy_size;
    int total_size;
    char status[5];
    
    free_size = 0;
    busy_size = 0;
    total_size = 0;
    current = list_head;
    counter = 1;
    fprintf(stdout,"************************************Block list***********************************\n");
    fprintf(stdout,"No.\tStatus\tBegin\t\tEnd\t\tSize\tt_Size\tt_Begin\n");
    fprintf(stdout,"---------------------------------------------------------------------------------\n");
    while(NULL != current)
    {
        t_Begin = (char*)current;
        Begin = t_Begin + (int)sizeof(block_header);
        Size = current->size_status;
        strcpy(status,"Free");
        if(Size & 1) /*LSB = 1 => busy block*/
        {
            strcpy(status,"Busy");
            Size = Size - 1; /*Minus one for ignoring status in busy block*/
            t_Size = Size + (int)sizeof(block_header);
            busy_size = busy_size + t_Size;
        }
        else
        {
            t_Size = Size + (int)sizeof(block_header);
            free_size = free_size + t_Size;
        }
        End = Begin + Size;
        fprintf(stdout,"%d\t%s\t0x%08lx\t0x%08lx\t%d\t%d\t0x%08lx\n",counter,status,(unsigned long int)Begin,(unsigned long int)End,Size,t_Size,(unsigned long int)t_Begin);
        total_size = total_size + t_Size;
        current = current->next;
        counter = counter + 1;
    }
    fprintf(stdout,"---------------------------------------------------------------------------------\n");
    fprintf(stdout,"*********************************************************************************\n");
    
    fprintf(stdout,"Total busy size = %d\n",busy_size);
    fprintf(stdout,"Total free size = %d\n",free_size);
    fprintf(stdout,"Total size = %d\n",busy_size+free_size);
    fprintf(stdout,"*********************************************************************************\n");
    fflush(stdout);
    return;
}
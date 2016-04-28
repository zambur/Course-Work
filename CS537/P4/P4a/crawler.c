// Written by Zach Ambur & Griffin Lacek
// CS 537
// Spring 2016

#include <stdlib.h>
#include <unistd.h>
#include <stdio.h>
#include <string.h>
#include <assert.h>
#include <stdint.h>
#include <pthread.h>

// Structure for each node of the queue
typedef struct Node {
    char *value;
    struct Node *next;
	char* page_name;
} Node;

// Structure for each list of the hash table
typedef struct _list_t_ {
    char *string;
    struct _list_t_ *next;
} list_t;

// Structure for hash table
typedef struct _hash_table_t_ {
    int size;
    list_t **table;
} hash_table_t;

// Declairing head nodes of the queues
Node *linkq;
Node *pageq;

// Variables for queus
int linkq_size = 0;
int linkq_max_size;
int pageq_size = 0;
char *prev_page;

// To keep track of amount of work left before program can exit
int total_work = 0;

// Saving fetch and edge functions passed into crawler.c
char *(*fetch_func)(char *url);
void (*edge_func)(char *from, char *to);

// Declairing hash table and size
hash_table_t *link_table;
int table_size = 500;

// Declairing locks
pthread_mutex_t linkq_lock;
pthread_mutex_t pageq_lock;
pthread_mutex_t hash_lock;
pthread_mutex_t finished_lock;

// Declairing condition variables
pthread_cond_t linkq_fill;
pthread_cond_t linkq_empty;
pthread_cond_t pageq_fill;
pthread_cond_t done;

// Hash table credit to:
// http://www.sparknotes.com/cs/searching/hashtables/section3.rhtml
hash_table_t *create_hash_table(int size) {
    hash_table_t *new_table;
    if (size<1) return NULL; /* invalid size for table */

    if ((new_table = malloc(sizeof(hash_table_t))) == NULL) {
        return NULL;
    }
    if ((new_table->table = malloc(sizeof(list_t *) * size)) == NULL) {
        return NULL;
    }

    // Initialize the elements of the table
	int i;
    for(i=0; i<size; i++) new_table->table[i] = NULL;

    new_table->size = size;

	// Return hash table
    return new_table;
}

unsigned int hash(hash_table_t *hashtable, char *str) {
    unsigned int hashval;
    hashval = 0;
    // For each character, we multiply the old hash by 31 and add the current character
    for(; *str != '\0'; str++) hashval = *str + (hashval << 5) - hashval;

    // Return the hash value mod the hashtable size so that it will fit into the necessary range
    return hashval % hashtable->size;
}

list_t *lookup_string(hash_table_t *hashtable, char *str) {
    list_t *list;
    unsigned int hashval = hash(hashtable, str);
    // Go to the correct list based on the hash value and see if the value is in the list  
	//If it is, return return a pointer to the list element
    for(list = hashtable->table[hashval]; list != NULL; list = list->next) {
        if (strcmp(str, list->string) == 0) return list;
    }
    // If it isn't in the list, the item isn't in the table, so return NULL.
    return NULL;
}

int add_string(hash_table_t *hashtable, char *str)
{
    list_t *new_list;
    list_t *current_list;
    unsigned int hashval = hash(hashtable, str);

    if ((new_list = malloc(sizeof(list_t))) == NULL) return 1;

    // Check if item already exist in table
    current_list = lookup_string(hashtable, str);
    // Item already exists, don't insert it again
    if (current_list != NULL) return 2;
    // Item not in table, insert into list
    new_list->string = strdup(str);
    new_list->next = hashtable->table[hashval];
    hashtable->table[hashval] = new_list;

    return 0;
}

// Pushes a new node to the front of the given queue and then sets that node as the head of the queue
int push(Node **head, char *value, char *name) {
    Node *newNode = malloc(sizeof(Node));
	if (newNode == NULL) {
		return -1;
	}
	newNode->value = value;
	newNode->next  = *head;
	newNode->page_name = name;
	*head = newNode;
	return 0;
}

// Pops the head of the queue off and sets the next node as the head. 
// Returns the value of the head
char* pop(Node **head) {
	Node *tmpHead = *head;
	char *value = tmpHead->value;
	*head = tmpHead->next;
	free(tmpHead);
    return value;
}

void *parser() {
	while (1) {		
		// Tries to acquire page queue lock
		pthread_mutex_lock(&pageq_lock);
		// If page queue is empty wait until content is added to it
		while (pageq_size == 0) {
			pthread_cond_wait(&pageq_fill, &pageq_lock);
		}
		// Remove a page from the page queue and save it
		char *page_name = pageq->page_name;
		char *page = pop(&pageq);
		pageq_size--;
		// Release page queue lock
		pthread_mutex_unlock(&pageq_lock);
		
		// Iterates through each word of the page and finds any link in the page that is identified by "link:[link]"
	    char *savePage;
	    char *token = strtok_r(page, " \n", &savePage); 
	    while (token != NULL) {
			int inTable = 0;
		    if (strncmp(token, "link:", 5) == 0) {			
			    char *link = malloc(strlen(token)-4);
				strncpy(link, &token[5], strlen(token)-4);
				
				// Acquires hash table lock
				pthread_mutex_lock(&hash_lock);
				// Checks if link has already been visited (if it is in the hash table or not)
				list_t *list = lookup_string(link_table, link);
				if (list == NULL) {		
					// If new link add it to the hash table
					add_string(link_table, link);
					inTable = 1;
				} 
				// Release hash table lock
				pthread_mutex_unlock(&hash_lock);
				// If link has not been visited yet add it to the link queue
				if (inTable == 1) {
					// Acquire link queue lock
					pthread_mutex_lock(&linkq_lock);
					// Check if link queue is not full
					while (linkq_size == linkq_max_size) {
						pthread_cond_wait(&linkq_empty, &linkq_lock);
					}
					// Push new link onto the front of the link queue
					push(&linkq, link, NULL);
					linkq_size++;
					// Signal that there is a new link in the link queue
					pthread_cond_signal(&linkq_fill);
					// Release link queue lock
					pthread_mutex_unlock(&linkq_lock);
					
					// Makes sure to lock the finished lock before adding work to the total work counter
					pthread_mutex_lock(&finished_lock);
					total_work++;
					pthread_mutex_unlock(&finished_lock);
				}
				// Prints the order of the links
				// "Where the link came from" -> "New Link"
				edge_func(page_name, link);
		    }
			// Move onto the next word in the page
		    token = strtok_r(NULL, " \n", &savePage);
	    }
		
		// Makes sure to lock the finished lock before decrementing the total work and checking if the program has finished
		pthread_mutex_lock(&finished_lock);
		total_work--;
		if (total_work == 0) {
			// No more work to do so signal that the program is ready to exit
			pthread_cond_signal(&done);
		}
		pthread_mutex_unlock(&finished_lock);
	}
}

void *downloader() {
	while (1) {
		// Acquires the link queue lock
		pthread_mutex_lock(&linkq_lock);
		// Checks to make sure the link queue isn't empty
		while(linkq_size == 0) {
			pthread_cond_wait(&linkq_fill, &linkq_lock);
		}
		// Pops off the head of the link queue and saves link
		char* link = pop(&linkq);
		linkq_size--;
		// Signals that the link queue is now empty
		pthread_cond_signal(&linkq_empty);
		// Releases the link queue lock
		pthread_mutex_unlock(&linkq_lock);
		
		// Fetches all contents of the new page
		char *page = fetch_func(link);
		
		pthread_mutex_lock(&pageq_lock);
		// Adds the new page to the page queue
		push(&pageq, page, link);
		pageq_size++;
		// Signals that there is a new page in the page queue
		pthread_cond_signal(&pageq_fill);
		pthread_mutex_unlock(&pageq_lock);
	}
}

int crawl(char *start_url,
	  int download_workers,
	  int parse_workers,
	  int queue_size,
	  char * (*_fetch_fn)(char *url),
	  void (*_edge_fn)(char *from, char *to)) {
		  // Saves functions passed in
		  fetch_func = _fetch_fn;
		  edge_func = _edge_fn;
		  
		  linkq_max_size = queue_size;

		  link_table = create_hash_table(table_size);
		 
		  // Initializes the link queue saving the first link to it
		  linkq = malloc(sizeof(Node));
		  linkq->value = start_url;
		  linkq->next = NULL;
		  linkq_size++;
		  total_work++;
		  add_string(link_table, start_url);
		  
		  // Initializes the page queue
		  pageq = malloc(sizeof(Node));
		  pageq->next = NULL;
		  
		  // Creates parse and download threads
		  pthread_t pid[parse_workers], did[download_workers];
		  int i;
		  for (i = 0; i < parse_workers; i++) {
		  	pthread_create(&pid[i], NULL, parser, NULL);
		  }
		  for (i = 0; i < download_workers; i++) {
		  	pthread_create(&did[i], NULL, downloader, NULL);
		  }

		  // Waits until program has finished visiting all the links in all the pages and then successfully terminates the program
  		  pthread_mutex_lock(&finished_lock);
		  while (total_work > 0) {
			  pthread_cond_wait(&done, &finished_lock);
		  }
		  pthread_mutex_unlock(&finished_lock);
		  		  
		  free(linkq);
		  free(pageq);
		  return 0;
}

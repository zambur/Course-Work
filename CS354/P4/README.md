# Assignment 4

Finding instruction cache misses and data cache misses as well as the hit ratio of each for block size of 4, 32, and 64 bytes. When it comes to comparing the D-cache there is a difference in performance of the 2 programs, the hit ratio of cache2Drows is higher than cache2Dcols.  This result is because of the spatial locality in the caches. For the cache2Drows array the next element will be in the same row, which will likely be caches since they are nearby elements. However in cache2Dcols array the next element will be in the same column but an entire row apart wich will lead to a higher miss ratio.

1. A small C program called cache1D.c that sets each element of an array of 100,000 integers to the value of its index.
2. A C program called cache2Drows.c that sets each element of a 3000 row by 500 column array of integers to the sum of the row index and the column index.
3. Another C program called cache2Dcols.c that does the same thing as cache2Drows.c did, but in a different order. This program has the inner loop work its way through a single column of the array, and the outer loop iterates through the columns.

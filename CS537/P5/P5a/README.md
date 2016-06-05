# File System Checker

In this program, I developed a working file system checker. The checker reads in a file system image and makes sure that 
it is consistent. When it isn't, the checker takes steps to fix the problems it sees. 

The checker reads through the file system image and determines the consistency of a number of things, including the following. 
When one of these does not hold, it prints the coresponding error message (also shown below) and exits immediately.

* Each inode is either unallocated or one of the valid types (T_FILE, T_DIR, T_DEV).    
  **ERROR:** bad inode   
* For in-use inodes, each address that is used by inode is valid (points to a valid datablock address within the image). Note: must check indirect blocks too, when they are in use. ERROR: bad address in inode.
Root directory exists, and it is inode number 1.   
  **ERROR:** root directory does not exist.   
* Each directory contains . and .. entries.   
  **ERROR:** directory not properly formatted.   
* Each .. entry in directory refers to the proper parent inode, and parent inode points back to it.   
  **ERROR:** parent directory mismatch.   
* For in-use inodes, each address in use is also marked in use in the bitmap.   
  **ERROR:** address used by inode but marked free in bitmap.   
* For blocks marked in-use in bitmap, actually is in-use in an inode or indirect block somewhere.   
  **ERROR:** bitmap marks block in use but it is not in use.   
* For in-use inodes, any address in use is only used once.   
  **ERROR:** address used more than once.   
* For inodes marked used in inode table, must be referred to in at least one directory.   
  **ERROR:** inode marked use but not found in a directory.   
* For inode numbers referred to in a valid directory, actually marked in use in inode table.   
  **ERROR:** inode referred to in directory but marked free.   
* Reference counts (number of links) for regular files match the number of times file is referred to in directories (i.e., hard links work correctly). ERROR: bad reference count for file.
No extra links allowed for directories (each directory only appears in one other directory).   
  **ERROR:** directory appears more than once in file system.   

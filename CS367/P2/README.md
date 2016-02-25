# Program 2

This program simulates the process of creating a dot matrix generator.

###Command input

***s filename :***

* save the generated text to a file
***l filename :***

* load a generated text to the program

***d :***

* display the text stored in the program

***n :***

* move on to the next character

***p :***

* move back to the previous character

***j N :***

* jump N characters in the loop (forward if N > 0, backwards if N < 0) and display the current context

***x :***

* delete the current character in the message

***a message :***

* add all the characters in the message to the message loop, one character per node converted to its dot matrix representation, and added one after another. The current character will become the last character that was added and then display the current context. If any of the characters in the message is an invalid character, it won't be able to be converted to the dot matrix representation so add nothing; instead display "An unrecognized character has been entered." and then return to the menu prompt. An invalid character is one, which isn't defined in the dot-matrix mapping file alphabets.txt

***i message :***

* If the message loop is empty, insert all the characters in the message to the message loop, one character per node converted to its dot matrix representation, and inserted one before another. Otherwise, insert these characters in the same manner immediately before the current character. In either case, the current character will become the last character that was inserted and then display the current context. Again, if any of the characters in the message is an invalid character, it won't be able to be converted to the dot matrix representation so insert nothing; instead display "An unrecognized character has been entered." and then return to the menu prompt. An invalid character is one, which isn't defined in the dot-matrix mapping file alphabets.txt

***c :***

* Display the current context

***r :***

* Replace the current character with the new character and display the current context

***q :***

* Display "quit" and quit the program

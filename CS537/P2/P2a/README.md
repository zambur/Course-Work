# Linux Program 2

In this assignment, I implemented a command line interpreter (CLI) aka a shell. The shell operates in a basic way: when a user types in a command (in response to its prompt), the shell creates a child process that executes the command entered and then prompts for more user input when it has finished.

***Basic Shell: WhooSH***

The basic shell, called whoosh , is basically an interactive loop: it repeatedly prints a prompt "whoosh> ", parses the input, executes the command specified on that line of input, and waits for the command to finish.

***Built-in Commands***

Whenever the shell accepts a command, it checks whether the command is a built-in command or not. If it is, it should not be executed like other programs. Instead, the shell will invoke my implementation of the built-in command. For example, to implement the exit built-in command, you simply call exit(0); in my C program.

In this project exit, cd, pwd, and path are implemented.

***Redirection***

When a user types "ls -la /tmp > output" , nothing is printed on the screen. Instead, the standard output of the ls program will be rerouted to the output.out file. In addition, the standard error output of the file is rerouted to the file output.err.

If the output.out or output.err files already exists before the user runs the program, it will overwrite them (after truncating). If the output file is not specified (e.g. the user types ls > ), an error message will print and not run the program ls.

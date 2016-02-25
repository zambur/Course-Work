# Linux Program 1

A sorting program that takes in one or two inputs. If just one input is given, the input file file should be sorted and the sorted output printed to the screen; it is assumed that the file is a text file (full of ASCII characters) and, when no other arguments are given, the sorting should be over the first word in each line.

If the optional argument is included ( -3 in the example), the program should sort the text input file using the specified word as the key to sort upon (with -3 , the program should find the 3rd word in each line and sort the lines based upon that).

***Example Output***

Let's say you have the following file:

```
this line is first
but this line is second
finally there is this line
```

If you run your fastsort and give it this file as input, it should print:

```
but this line is second
finally there is this line
this line is first
```

because but is alphabetically before finally is before this.
If, however, you pass in a flag to sort a different key, you'll get a different output. For example, if you call fastsort -2 on this file, you should get:

```
this line is first
finally there is this line
but this line is second
```

because line comes before there comes before this.

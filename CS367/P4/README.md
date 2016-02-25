# Program 4

Creates a Company Hierarchy Tree which organizes the employees of a company
by their position in the company. It adds employees through a file that is
passed in through the command line arguments. It then prompts the user to 
edit this tree through a variety of inputs.

###Command inputs

***a ID, Name, Date of joining, Title, Supervisor ID, Supervisor Name :***

* Add a new employee with given details to the company tree. Also 
checks to see if the information given is correct and will catch
any CompanyHierarchyExceptions that are throw from this call.

***c ID, Name :***

* Print the names of the co-workers of the employee with given id 
and name. Also checks to see if the information given is correct and 
will catch any CompanyHierarchyExceptions that are throw from this 
call.

***d :***

* Display information about the company tree such as the number of 
employees in the company tree, the max levels of the tree, and 
the name of the CEO of the company.

***e Title :***

* Print the names of the employees that has the given title.

***r ID, Name :***

* Removes the employee with given id and name from the company tree 
and re-assign the worker's to the removed employee's supervisor. 

***s ID, Name :***

* Print the name(s) of all the supervisors in the supervisor chain of 
the given employee.

***u ID, Name, New ID, New Name, Date of Joining, Title***

* Updates the employee with given id and name by replacing with 
the provided employee details.

***j Start Date, End Date :***

* Print the names of the employees whose date of joining are 
between startDate and endDate given by the user.

***x :***

* Exits program.

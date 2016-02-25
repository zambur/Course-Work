///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Main Class File:  CompanyHierarchyMain.java
// File:             CompanyHierarchy.java
// Semester:         CS367 Spring 2014
//
// Author:           Zach Ambur
// Email:            zambur@wisc.edu
// CS Login:         zachary
// Lecturer's Name:  Jim Skrentny
//
//////////////////// PAIR PROGRAMMERS COMPLETE THIS SECTION ////////////////////
//                   CHECK ASSIGNMENT PAGE TO see IF PAIR-PROGRAMMING IS ALLOWED
//                   If allowed, learn what PAIR-PROGRAMMING IS, 
//                   choose a partner wisely, and complete this section.
//
// Pair Partner:     Griffin Lacek
// Email:            lacek@wisc.edu
// CS Login:         lacek
// Lecturer's Name:  Jim Skrentny
//
//////////////////////////// 80 columns wide //////////////////////////////////

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;
/**
 * Numerous methods to edit the company hierarchy tree such as add, remove, and
 *  lookup various employees from the tree
 * 
 * @author Griffin Lacek & Zach Ambur
 */
public class CompanyHierarchy{

	//private local variables
	private TreeNode root;
	int size;
	// The constructor for the CompanyHierarchy class and at defult it
	//  constructs a empty tree by setting root as null
	public CompanyHierarchy() {
		root = null;
		size = 0;
	}
	
	/**
	 * Gets the name of the CEO of the tree
	 *
	 * @return String of the CEO name
	 */
	public String getCEO() {
		if(root == null) {
			return null;
		}
		else {
			return root.getEmployee().getName();
		}
	}
	
	/**
	 * Returns the number of employees in the tree
	 *
	 * @return int of the number of employees in tree
	 */
	public int getNumEmployees() {
		return size;
	}
	
	/**
	 *Returns the max number of levels from the CEO to the deepest level of the
	 * tree. Uses a companion method.
	 *
	 * @return int of the number of levels in tree
	 */
	public int getMaxLevels() {
		return getMaxLevelsHelper(root);
	}
	
	/**
	 * Companion method for gerMaxLevels
	 *
	 * @return int of the number of levels in tree
	 */
	private int getMaxLevelsHelper(TreeNode node) {
		if(node == null) {
			return 0;
		}
		if(node.getWorkers().isEmpty()) {
			return 1;
		}
		int maxLevels = 0;
		List<TreeNode> workers = node.getWorkers();
		Iterator<TreeNode> itr = workers.iterator();
		while(itr.hasNext()) {
			// Recursively calls itself with the next node in the tree
			int childLevels = getMaxLevelsHelper(itr.next());
			// if the current childs tree is longer than the previous max height
			//  than it replaces the max hieght with the child height
			if(childLevels > maxLevels) {
				maxLevels = childLevels;
			}
		}
		return 1 + maxLevels;
	}
	
	/**
	 * Returns the employee details for the given employee id/name.
	 * Throws CompanyHierarchyException if the employee id given does not match
	 * the name. Uses companion method getNode.
	 *
	 * @param (id) (id of the employee)
	 * @param (name) (name of the employee)
	 * @return (Employee object of desired employee)
	 */
	public Employee getEmployee(int id, String name) {
		if(root == null) {
			return null;
		}
		TreeNode result = getNode(root, id, name);
		if(result == null) {
			return null;
		}
		else {
			// Checks to see if the id matches the name
			if(result.getEmployee().getId() == id) {
				if(result.getEmployee().getName().equals(name)) {
					return result.getEmployee();
				}
				else {
					throw new CompanyHierarchyException
					("Incorrect employee name for id!");
				}
			}
			return null;
		}
	}
	
	/**
	 * Adds an employee to the tree if the employee is not already in the tree
	 * Throws CompanyHierachyException if the employee id is already being used
	 * or if the employee's supervisor name does not match the supervisor's id.
	 * Uses companion method getNode
	 *
	 * @param (employee) (employee to add to the tree)
	 * @param (managerId) (id of employee's supervisor)
	 * @param (managerName) (name of employee's supervisor)
	 * @return (true if employee is added to the tree)
	 */
	public boolean addEmployee(Employee employee, int managerId, 
			String managerName) {
		if(root == null) {
			TreeNode CEO = new TreeNode(employee, null);
			root = CEO;
			size++;
			return true;
		}
		/* Checks if employee is already in the company hierarchy. Throws 
		 * CompanyHierarchyException if id is already used.
		 */
		TreeNode checkEmployee = getNode(root, employee.getId(), 
				employee.getName());
		if(checkEmployee != null) {
			// Checks to see if the id matches the name
			if(checkEmployee.getEmployee().getId() == employee.getId()) {
				if(checkEmployee.getEmployee().getName()
						.equals(employee.getName())) {
					return false;
				}
				else {
					throw new CompanyHierarchyException("Id already used!");
				}
			}
		}
		/* Returns null if no supervisor id or name in the tree that matches
		 * managerId or managerName parameters passed in. If there are matches 
		 * add employee to the tree. Throws CompanyHierarchyException if the 
		 * supervisor's id does not match the supervisor's name
		 */
		TreeNode result = getNode(root, managerId, managerName);
		if(result == null) {
			return false;
		}
		else {
			// Checks to see if the id matches the name
			if(result.getEmployee().getId() == managerId) {
				if(result.getEmployee().getName().equals(managerName)) {
					TreeNode worker = new TreeNode(employee, result);
					result.addWorker(worker);
					size++;
					return true;
				}
				else {
					throw new CompanyHierarchyException
					("Incorrect supervisor name for id!");
				}
			}
			return false;
		}
	}

	/**
	 * Return true if the company tree contains employee with given id and name,
	 * otherwise return false. In search for the employee, if the id matches but
	 * name doesn't, then throw a CompanyHierarchyException with the message 
	 * "Incorrect employee name for id!"
	 *
	 * @param (id) (id of employee being searched for)
	 * @param (name) (name of employee being searched for)
	 * @return (true if tree contains employee)
	 */
	public boolean contains(int id, String name){
		if(root == null) {
			return false;
		}
		TreeNode result = getNode(root, id, name);
		if(result == null) {
			return false;
		}
		else {
			// Checks to see if the id matches the name
			if(result.getEmployee().getId() == id) {
				if(result.getEmployee().getName().equals(name)) {
					return true;
				}
				else {
					throw new CompanyHierarchyException
					("Incorrect employee name for id!");
				}
			}
			return false;
		}
	}
	
	/**
	 * Removes the employee with the specified id and name and updates all the 
	 * supervisor-worker links.
	 *
	 * @param (id) (id of employee being searched for)
	 * @param (name) (name of employee being searched for)
	 * @return (true if employee is removed)
	 */
	public boolean removeEmployee(int id, String name) {
		if(root == null) {
			return false;
		}
		TreeNode result = getNode(root, id, name);
		if(result == null) {
			return false;
		}
		else {
			if(result.getSupervisor() == null) {
				throw new CompanyHierarchyException
				("Cannot remove CEO of the company!");
			}
			// Checks to see if the id matches the name
			if(result.getEmployee().getId() == id) {
				if(result.getEmployee().getName().equals(name)) {
					List<TreeNode> workers = result.getWorkers();
					Iterator<TreeNode> itr = workers.iterator();
					// Adds the employees workers to its superior
					while(itr.hasNext()) {
						TreeNode employee = itr.next();
						employee.updateSupervisor(result.getSupervisor());
						result.getSupervisor().addWorker(employee);
					}
					// Removes the employees node from the tree
					result.updateSupervisor(null);
					size--;
					return true;
				}
				else {
					throw new CompanyHierarchyException
					("Incorrect employee name for id!");
				}
			}
			return false;
		}
	} 

	/**
	 * Replaces the employee with the specified id and name with the employee
	 * passed in.
	 *
	 * @param (id) (id of employee being to be replaced)
	 * @param (name) (name of employee to be replaced)
	 * @param (newEmployee) (employee to replace existing employee)
	 * @return (true if employee is replaced)
	 */
    public boolean replaceEmployee(int id, String name, Employee newEmployee) {
    	if(root == null) {
			return false;
		}
    	// Checks to see if the replacing employee already exists in the tree
    	TreeNode checkEmployee = getNode(root, newEmployee.getId(), 
    			newEmployee.getName());
		if(checkEmployee != null) {
			// Checks to see if the id matches the name
			if(checkEmployee.getEmployee().getId() == newEmployee.getId()) {
				if(checkEmployee.getEmployee().getName()
						.equals(newEmployee.getName())) {
					throw new CompanyHierarchyException
					("Replacing employee already exists on the Company Tree!");
				}
				else {
					throw new CompanyHierarchyException("Id already used!");
				}
			}
		}
		// Finds the node that needs to be replaced
		TreeNode result = getNode(root, id, name);
		if(result == null) {
			return false;
		}
		else {
			// Checks to see if the id matches the name
			if(result.getEmployee().getId() == id) {
				if(result.getEmployee().getName().equals(name)) {
					if(result.getEmployee().getTitle()
							.equals(newEmployee.getTitle())) {
						result.updateEmployee(newEmployee);
						return true;
					}
					else {
						throw new CompanyHierarchyException
						("Replacement title does not match existing title!");
					}
				}
				else {
					throw new CompanyHierarchyException
					("Incorrect employee name for id!");
				}
			}
		}
		return false;
    }

    /**
	 * Returns a list of employees with the given title.
	 *
	 * @param (title) (title of employees to search for)
	 * @return (List of employees with passed in title)
	 */
	public List<Employee> getEmployeeWithTitle(String title) {
		if(root == null) {
			return null;
		}
		List<Employee> result = new ArrayList<Employee>();
		return getEmployeeWithTitleHelper(root, title, result); 
	}

	/**
	 * Returns a list of employees who joined during the specified date range.
	 * Throws CompanyHierarchyException if date parsing fails.
	 *
	 * @param (startDate) (date of employment to begin search)
	 * @param (endDate) (date of employment to end search)
	 * @return (List of employees who joined during the date range)
	 */
	public List<Employee> getEmployeeInJoiningDateRange(String startDate, 
			String endDate) {
		// Creates a simple date format to do the parsing with
		SimpleDateFormat df = new SimpleDateFormat("MM/dd/yyyy");
		Date firstDate;
		// Turns the string date into an actual date variable, if possible
		try {
			firstDate = df.parse(startDate);
		} catch (ParseException e) {
			throw new CompanyHierarchyException("Date parsing failed!");
		}
		Date lastDate;
		// Turns the string date into an actual date variable, if possible
		try {
			lastDate = df.parse(endDate);
		} catch (ParseException e) {
			throw new CompanyHierarchyException("Date parsing failed!");
		}
		if(root == null) {
			return null;
		}
		List<Employee> employeeList = new ArrayList<Employee>();
		try {
			return getEmployeeInJoiningDateRangeHelper(root, firstDate, 
					lastDate, employeeList);
		} catch (CompanyHierarchyException e) {
			throw new CompanyHierarchyException("Date parsing failed!");
		}
	}

	/**
	 * Returns the list of the specified employee's chain of command.
	 * i.e. Supervisors from employee to the root. 
	 *
	 * Throws CompanyHierarchyException if id matches employee but name doesn't
	 * or if the employee doesn't have any supervisors.
	 * 
	 * @param (id) (id of the employee)
	 * @param (name) (name of the employee)
	 * @return (List of chain of supervisors of the employee)
	 */
	public List<Employee> getSupervisorChain(int id, String name) {
		if(root == null) {
			return null;
		}
		TreeNode result = getNode(root, id, name);
		if(result == null) {
			return null;
		}
		else {
			// Checks to see if the id matches the name
			if(result.getEmployee().getId() == id) {
				if(result.getEmployee().getName().equals(name)) {
					List<Employee> employeeList = new ArrayList<Employee>();
					TreeNode supervisor = result.getSupervisor();
					if(supervisor == null) {
						throw new CompanyHierarchyException
						("No Supervisor Chain found for that employee!");
					}
					// Gathers all of the supervisors until reaches the root
					while(supervisor != null) {
						employeeList.add(supervisor.getEmployee());
						supervisor  = supervisor.getSupervisor();
					}
					return employeeList;
				}
				else {
					throw new CompanyHierarchyException
					("Incorrect employee name for id!");
				}
			}
			return null;
		}
	}

	/**
	 * Returns a list of employees that have the same supervisor as the 
	 * specified employee.
	 * Throws CompanyHierarchyException if id matches employee but name doesn't.
	 *
	 * @param (id) (id of employee)
	 * @param (name) (name of employee)
	 * @return (List of employees who have same supervisor as specified 
	 * employee)
	 */
	public List<Employee> getCoWorkers(int id, String name){
		if(root == null) {
			return null;
		}
		TreeNode result = getNode(root, id, name);
		if(result == null) {
			return null;
		}
		else {
			// Checks to see if the id matches the name
			if(result.getEmployee().getId() == id) {
				if(result.getEmployee().getName().equals(name)) {
					List<TreeNode> workers = result.getSupervisor()
							.getWorkers();
					List<Employee> employeeList = new ArrayList<Employee>();
					Iterator<TreeNode> itr = workers.iterator();
					// Adds the co-workers to a list, excluding the employee
					//  passed in by the user
					while(itr.hasNext()) {
						TreeNode employee = itr.next();
						if(employee.getEmployee().getId() != 
								result.getEmployee().getId()) {
							employeeList.add(employee.getEmployee());
						}
					}
					return employeeList;
				}
				else {
					throw new CompanyHierarchyException
					("Incorrect employee name for id!");
				}
			}
			return null;
		}
	}
	
	/**
	 * Private class that is only used by other classes above to get the 
	 * node via a passed in node and id/name of the employee it is looking for.
	 *
	 * @param (node) (Treenode)
	 * @param (id) (id of employee)
	 * @param (name) (hame of employee)
	 * @return (Employee from specified node)
	 */
	private TreeNode getNode(TreeNode node, int id, String name) {
		// If the current node equals the id and name, return current node
		if(node.getEmployee().getId() == id) {
			return node;
		}
		// Gets current node children
		List<TreeNode> workers = node.getWorkers();
		Iterator<TreeNode> itr = workers.iterator();
		while(itr.hasNext()) {
			// recursively calls itself with the next node in the tree
			TreeNode employee = getNode(itr.next(), id, name);
			if(employee != null) {
				return employee;
			}
		}
		return null;
	}
	
	/**
	 * Finds employees with specified title and returns a list of 
	 * those employees.
	 *
	 * @param (node) (Treenode)
	 * @param (title) (title of employees to look for)
	 * @param (employeeList) (empty list of employees)
	 * @return (List of employees who have same title)
	 */
	private List<Employee> getEmployeeWithTitleHelper(TreeNode node, 
			String title, List<Employee> employeeList) {
		// If current node has title, add the employee to the list
		if(node.getEmployee().getTitle().equals(title)) {
			employeeList.add(node.getEmployee());
		}
		// Gets current nodes children
		List<TreeNode> workers = node.getWorkers();
		Iterator<TreeNode> itr = workers.iterator();
		while(itr.hasNext()) {
			// Recursively calls itself with the next node in the tree
			getEmployeeWithTitleHelper(itr.next(), title, employeeList);
		}
		return employeeList;
	}
	
	/**
	 * Finds employees with the specified date of joining between the start 
	 * date and end date that are passed and returns a list of those employees.
	 *
	 * @param (node) (Treenode)
	 * @param (firstDate) (the begining date to check)
	 * @param (endDate) (the ending date to check)
	 * @param (employeeList) (empty list of employees)
	 * @return (List of employees who have same title)
	 */
	private List<Employee> getEmployeeInJoiningDateRangeHelper(TreeNode node, 
			Date firstDate, Date lastDate, List<Employee> employeeList) {
		// Creates a date format to base the parsing off of
		SimpleDateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy");
		// Gets the current nodes date of joining the company
		String nodeDate = node.getEmployee().getDateOfJoining();		
		Date nodeStartDate;
		// Turns the nodes date into an actual date variable, if possible
		try {
			nodeStartDate = dateFormat.parse(nodeDate);
		} catch (ParseException e) {
			throw new CompanyHierarchyException("Date parsing failed!");
		}
		// Checks to see if the nodes date of joining is after the first date
		//  and before the last date. If it is it adds it to the list.
		if(nodeStartDate.compareTo(firstDate) >= 0 && nodeStartDate
				.compareTo(lastDate) <= 0) {
			employeeList.add(node.getEmployee());
		}
		// Gets the current nodes children
		List<TreeNode> workers = node.getWorkers();
		Iterator<TreeNode> itr = workers.iterator();
		while(itr.hasNext()) {
			// Recursively calls itself with the next node in the tree
			getEmployeeInJoiningDateRangeHelper(itr.next(), firstDate, 
					lastDate, employeeList);
		}
		return employeeList;
	}
}

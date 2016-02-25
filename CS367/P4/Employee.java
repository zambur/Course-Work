/** The Employee class represents a single employee in the company that keeps
 * track of employee name (as a String), id (as an integer), date of joining
 * (as a String), title (as a String)
 * 
 * DO NOT MODIFY THIS CLASS
 */

public class Employee {
	private String name;
	private int id;
	private String dateOfJoining;
	private String title;
	
	/** Constructor to initialize an Employee with the required details */
	public Employee(String name, int id, String dateOfJoining, String title) {
		this.name = name;
		this.id = id;
		this.dateOfJoining = dateOfJoining;
		this.title = title;
	}
	
	/** Return the name of this employee */
	public String getName() {
		return name;
	}
	
	/** Return the id of this employee */
	public int getId() {
		return id;
	}
	
	/** Return the date of joining of this employee */
	public String getDateOfJoining() {
		return dateOfJoining;
	}
	
	/** Return the title of this employee */
	public String getTitle() {
		return title;
	}
}

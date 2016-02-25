/** The TreeNode class represents a single node in the company tree. A node has 
 * the information of an employee (as a Employee) and also the information 
 * about its supervisor node (as a TreeNode) and worker nodes (as a List of
 * TreeNodes).
 * 
 * DO NOT MODIFY THIS CLASS
 */
import java.util.*;

public class TreeNode {
	private Employee employee;
	private TreeNode supervisorNode;
	private List<TreeNode> worker;
	
	/** Constructs a TreeNode with employee and supervisorNode. */
	public TreeNode (Employee employee, TreeNode supervisorNode) {
		this.employee = employee;
		this.supervisorNode = supervisorNode;
		worker = new ArrayList<TreeNode>();
	}
	
	/** Return the employee of this tree node */
	public Employee getEmployee() {
		return employee;
	}
	
	/** Return the supervisor of this tree node */
	public TreeNode getSupervisor()	{
		return supervisorNode;
	}
	
	/** Return the list of workers for this tree node */
	public List<TreeNode> getWorkers() {
		return worker;
	}
	
	/** Add a new worker to this tree node */
	public void addWorker(TreeNode workerNode) {
		worker.add(workerNode);
	}
	
	/** Update the supervisor for this tree node */
	public void updateSupervisor(TreeNode supervisorNode) {
		this.supervisorNode = supervisorNode;
	}
	
	/** Update the employee for this tree node */
	public void updateEmployee(Employee employee) {
		this.employee = employee;
	}
}

import java.util.ArrayList;

/**
 * The ProcessGenerator class that contains all the processes and respective tasks
 * needed to be done
 */
public class ProcessGenerator {
	
	private ArrayList<Process> processGenContainer = new ArrayList<Process>();
	private ArrayList<Task> taskContainer;
	
    /**
     * This method adds a Process with period p and computation time
     * c to the ProcessGenerator.
     *
     * @param p
     * @param c
     */
	public void addProcess(int p, int c) {
		Process newP = new Process(p, c);
		processGenContainer.add(newP);
	}
	
    /**
     * Each Process that has been added to the ProcessGenerator has a
     * Task created if t is a multiple of the period of the Process. Such a task
     * has a deadline equal to the time t plus the period of the corresponding
     * Process. This method gathers up all the tasks and returns them.
     *
     * @param t the time wanted for these tasks to generate
     * @return all the tasks that will need to be sorted
     */
    public ArrayList<Task> getTasks(int t) {
		taskContainer = new ArrayList<Task>();
		for(int i = 0; i < processGenContainer.size(); i++) {
			if(t == 0) {
				Task newTask = new Task(processGenContainer.get(i), t);
				taskContainer.add(newTask);
			}
			else if(t % processGenContainer.get(i).getPeriod() == 0) {
				Task newTask = new Task(processGenContainer.get(i), t);
				taskContainer.add(newTask);
			}
		}
		return taskContainer;
	}
}


public class Comparator implements java.util.Comparator<Task> {

	@Override
	public int compare(Task o1, Task o2) {
		if(o1.getDeadline() < o2.getDeadline()) {
			return -1;
		}
		else if(o1.getDeadline() > o2.getDeadline()) {
			return 1;
		}
		else {
			return 0;
		}
	}
	
	@Override
	public boolean equals(Object o) {
		throw new UnsupportedOperationException();
	}
	
	

}

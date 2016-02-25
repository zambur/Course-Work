public class Process {
	protected int period;
	protected int compute_time;
	
	public Process(int p, int ct){
		period = p;
		compute_time = ct;
	}
	
	public int getPeriod(){
		return period;
	}
	
	public int getComputeTime(){
		return compute_time;
	}
}

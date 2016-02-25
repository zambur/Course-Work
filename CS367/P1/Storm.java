/** The following class represents the Storm class and holds
 *  a storm's name, date, and damage amount.
 ************ DO NOT MODIFY THIS CLASS *************/

public class Storm implements Comparable<Storm> {
	private String name;
	private String date;
	private Integer damageAmount;
	public Storm(String name, String date, Integer damage) {
		this.name = name;
		this.date = date;
		this.damageAmount = damage;
	}
	public String getName() {
		return name;
	}
	public String getDate() {
		return date;
	}
	public Integer getDamageAmount() {
		return damageAmount;
	}
	
	public int compareTo(Storm storm) {
		if (this.damageAmount > storm.damageAmount) {
			return 1;
		} else if (this.damageAmount < storm.damageAmount) {
			return -1;
		} else {
			return 0;
		}
	}
}

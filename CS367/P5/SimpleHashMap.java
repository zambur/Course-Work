import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
///////////////////////////////////////////////////////////////////////////////
//ALL STUDENTS COMPLETE THESE SECTIONS
//Main Class File:  LoadBalancerMain.java
//File:             SimpleHashMap.java
//Semester:         CS367 Spring 2014
//
//Author:           Griffin Lacek
//CS Login:         lacek
//Lecturer's Name:  Jim Skrentny
//
////////////////////PAIR PROGRAMMERS COMPLETE THIS SECTION ////////////////////
//
//Pair Partner:     Zach Ambur
//CS Login:         zachary
//Lecturer's Name:  Jim Skrentny
//
////////////////////////////80 columns wide //////////////////////////////////

/**
 * This class implements a generic map based on hash tables using chained
 * buckets for collision resolution.
 *
 * <p>A map is a data structure that creates a key-value mapping. Keys are
 * unique in the map. That is, there cannot be more than one value associated
 * with a same key. However, two keys can map to a same value.</p>
 *
 * <p>The <tt>SimpleHashMap</tt> class takes two generic parameters, <tt>K</tt>
 * and <tt>V</tt>, standing for the types of keys and values respectively. Items
 * are stored in a hash table. Hash values are computed from the
 * <tt>hashCode()</tt> method of the <tt>K</tt> type objects.</p>
 *
 * <p>The chained buckets are implemented using Java's <tt>LinkedList</tt>
 * class.  When a hash table is created, its initial table size and maximum
 * load factor is set to <tt>11</tt> and <tt>0.75</tt>. The hash table can hold
 * arbitrarily many key-value pairs and resizes itself whenever it reaches its
 * maximum load factor.</p>
 *
 * <p><tt>null</tt> values are not allowed in <tt>SimpleHashMap</tt> and a
 * NullPointerException is thrown if used. You can assume that <tt>equals()</tt>
 * and <tt>hashCode()</tt> on <tt>K</tt> are defined, and that, for two
 * non-<tt>null</tt> keys <tt>k1</tt> and <tt>k2</tt>, if <tt>k1.equals(k2)</tt>
 * then <tt>k1.hashCode() == k2.hashCode()</tt>. Do not assume that if the hash
 * codes are the same that the keys are equal since collisions are possible.</p>
 */
public class SimpleHashMap<K, V> {

    /**
     * A map entry (key-value pair).
     */
    public static class Entry<K, V> {
        private K key;
        private V value;

        /**
         * Constructs the map entry with the specified key and value.
         */
        public Entry(K k, V v) {
        	key = k;
        	value = v;
        }

        /**
         * Returns the key corresponding to this entry.
         *
         * @return the key corresponding to this entry
         */
        public K getKey() {
        	return this.key;
        }

        /**
         * Returns the value corresponding to this entry.
         *
         * @return the value corresponding to this entry
         */
        public V getValue() {
        	return this.value;
        }

        /**
         * Replaces the value corresponding to this entry with the specified
         * value.
         *
         * @param value new value to be stored in this entry
         * @return old value corresponding to the entry
         */
        public V setValue(V value) {
        	V tmpValue = this.value;
        	this.value = value;
        	return tmpValue;
        }
    }

    // Private instance Variables
    
    // The current size of the table that is a prime number
    private int table_size;
    // The maximum load Factor for the hashMap that is set to 0.75 in the
    //  constructor
    private double loadFactor;
    // Declares the creation of the hashMap of Entries
    private List<Entry<K, V>>[] hashMap;
    // The number of total Entries in the hashMap
    private int size;
    // Creates an array of prime numbers that are doubled and then are the
    //  closest prime to that doubling
    private int[] nextPrime = {11,23,47,97,197,397,797,1597,3203,6421
            ,12853,25717,51437,102877,205759
            ,411527,823117,1646237,3292489,64983
            ,13169977,26339969,52679969,105359939
            ,210719881,421439783,842879579,1685759167};
    // A counter for the current index of the nextPrime array
    private int primeCounter = 0;

    /**
     * Constructs an empty hash map with initial capacity <tt>11</tt> and
     * maximum load factor <tt>0.75</tt>.
     **/
	public SimpleHashMap() {
    	table_size = 11;
    	loadFactor = 0.75;
    	hashMap = (LinkedList<Entry<K, V>>[]) new LinkedList<?>[table_size];
    	size = 0;
    }

    /**
     * Returns the value to which the specified key is mapped, or null if this
     * map contains no mapping for the key.
     *
     * @param key the key whose associated value is to be returned
     * @return the value to which the specified key is mapped, or <tt>null</tt>
     * if this map contains no mapping for the key
     * @throws NullPointerException if the specified key is <tt>null</tt>
     */
    public V get(Object key) {
    	// If key is null it throws an exception.
    	if(key == null) {
    		throw new NullPointerException();
    	}
    	int hashIndex = key.hashCode() % table_size;
    	// If the hash index is negative it adds the size of the table to get 
    	//  a positive hash index
    	if(hashIndex < 0) {
    		hashIndex = hashIndex + table_size;
    	}
    	List<Entry<K, V>> hashIndexList = hashMap[hashIndex];
    	// Goes through every index of the hash map that has a list of entries 
    	//  in it and checks to see if any of those entries match the key that
    	//  is passed in. If it does than it will update the value of that Entry
    	if(hashIndexList != null) {
    		Iterator<Entry<K, V>> itr = hashIndexList.iterator();
    		while(itr.hasNext()) {
    			Entry<K, V> tmpEntry = itr.next();
    			if(key.equals(tmpEntry.getKey())) {
    				return tmpEntry.getValue();
    			}
    		}
    	}
    	// Returns null if there was no matching Entry in the hash map
    	return null;
    }

    /**
     * <p>Associates the specified value with the specified key in this map.
     * Neither the key nor the value can be <tt>null</tt>. If the map
     * previously contained a mapping for the key, the old value is replaced.</p>
     *
     * <p>If the load factor of the hash table after the insertion would exceed
     * the maximum load factor <tt>0.75</tt>, then the resizing mechanism is
     * triggered. The size of the table should grow at least by a constant
     * factor in order to ensure the amortized constant complexity. You must also
     * ensure that the new selected size is Prime. After that, all of the mappings 
     * are rehashed to the new table.</p>
     *
     * @param key key with which the specified value is to be associated
     * @param value value to be associated with the specified key
     * @return the previous value associated with <tt>key</tt>, or
     * <tt>null</tt> if there was no mapping for <tt>key</tt>.
     * @throws NullPointerException if the key or value is <tt>null</tt>
     */
    public V put(K key, V value) {
    	// If key is null it throws an exception.
    	if(key == null  || value == null) {
    		throw new NullPointerException();
    	}
    	int hashIndex = key.hashCode() % table_size;
    	// If the hash index is negative it adds the size of the table to get 
    	//  a positive hash index
    	if(hashIndex < 0) {
    		hashIndex = hashIndex + table_size;
    	}
    	// If hash map at the hash index is null than it adds the passes Entry
    	//  to the hash map
    	List<Entry<K, V>> hashIndexList;
    	if(hashMap[hashIndex] == null) {
    		hashIndexList = new LinkedList<Entry<K, V>>();
    		Entry<K, V> newEntry = new Entry<K, V>(key, value);
        	hashIndexList.add(newEntry);
        	hashMap[hashIndex] = hashIndexList;
    	}
    	else {
    	// Goes through every index of the hash map that has a list of entries 
        //  in it and checks to see if any of those entries match the key that
        //  is passed in. If it does than it will update the value of that Entry
    	hashIndexList = hashMap[hashIndex];
    	Iterator<Entry<K, V>> itr = hashIndexList.iterator();
    		while(itr.hasNext()) {
    			Entry<K, V> tmpEntry = itr.next();
    			if(key.equals(tmpEntry.getKey()) ) {
    				V tmpValue = tmpEntry.getValue();
    				tmpEntry.setValue(value);
    				return tmpValue;
    			}
    		}
    	Entry<K, V> newEntry = new Entry<K, V>(key, value);
    	hashIndexList.add(newEntry);
    	}
    	size++;
    	
    	// Checks to see if the current load factor of the hash map is greater
    	//  than the maximum load factor, which is 0.75
    	if((double)size/table_size > loadFactor) {
    		// Gets a new table size from the array of primes
    		table_size = nextPrime[primeCounter + 1];
    		primeCounter++;
    		// Creates a new hash map with the new table size
    		List<Entry<K, V>>[] newHashMap = (LinkedList<Entry<K, V>>[]) new LinkedList<?>[table_size];
    		// Iterates through the old hash map
    		for(int i = 0; i < nextPrime[primeCounter - 1]; i++) {
    			Iterator<Entry<K, V>> hashItr = hashIndexList.iterator();
    			List<Entry<K, V>> currHashIndexList = hashMap[i];
    			// For each index of the old hash map that is not null it
    			//  creates a new hash index for that Entry and adds that Entry
    			//  to the new hash map. (Might be in a new location)
    			if(hashMap[i] != null) {
    				Iterator<Entry<K, V>> Entryitr = currHashIndexList.iterator();
    				while(Entryitr.hasNext()) {
    					Entry<K, V> replaceEntry = Entryitr.next();
    					int newHashIndex = replaceEntry.getKey().hashCode() % table_size;
    					// If the hash index is negative it adds the size of the
    					// new table to get a positive hash index
    					if(newHashIndex < 0) {
    						newHashIndex = newHashIndex + table_size;
    					}
    					List<Entry<K, V>> replaceIndexList = newHashMap[newHashIndex];
    					// If the new hash map has a null value at the index of
    					//  the hash index than it creates a new linked list,
    					//  then adds the Entry to that list, and finally
    					//  adds the linked list to the new hash map
    					if(replaceIndexList == null) {
    			    		replaceIndexList = new LinkedList<Entry<K, V>>();
    			        	replaceIndexList.add(replaceEntry);
    			        	newHashMap[newHashIndex] = replaceIndexList;
    			    	}
    					else {
    					newHashMap[newHashIndex].add(replaceEntry);
    					}
    				}
    			}
    		}
    		// Sets the old hash map equal to the new hash map
    		hashMap = newHashMap;
    	}
    	return null;
    }

    /**
     * Removes the mapping for the specified key from this map if present. This
     * method does nothing if the key is not in the hash table.
     *
     * @param key key whose mapping is to be removed from the map
     * @return the previous value associated with <tt>key</tt>, or <tt>null</tt>
     * if there was no mapping for <tt>key</tt>.
     * @throws NullPointerException if key is <tt>null</tt>
     */
    public V remove(Object key) {
    	// If key is null it throws an exception.
    	if(key == null) {
    		throw new NullPointerException();
    	}
    	int hashIndex = key.hashCode() % table_size;
    	// If the hash index is negative it adds the size of the table to get 
    	//  a positive hash index
    	if(hashIndex < 0) {
    		hashIndex = hashIndex + table_size;
    	}
    	// Goes through every index of the hash map that has a list of entries 
    	//  in it and checks to see if any of those entries match the key that
    	//  is passed in. If it does than it will remove that Entry
    	if(hashMap[hashIndex] != null) {
    		List<Entry<K, V>> hashIndexList = hashMap[hashIndex];
    		Iterator<Entry<K, V>> itr = hashIndexList.iterator();
    		while(itr.hasNext()) {
    			Entry<K, V> tmpEntry = itr.next();
    			if(key.equals(tmpEntry.getKey())) {
    				V tmpValue = tmpEntry.getValue();
    				hashIndexList.remove(tmpEntry);
    				size--;
    				return tmpValue;
    			}
    		}
    	}
    	// Returns null if there was no Entry in the hash map
    	return null;
    	
    }

    /**
     * Returns the number of key-value mappings in this map.
     *
     * @return the number of key-value mappings in this map
     */
    public int size() {
    	return size;
    }

    /**
     * Returns a list of all the mappings contained in this map. This method
     * will iterate over the hash table and collect all the entries into a new
     * list. If the map is empty, return an empty list (not <tt>null</tt>).
     * The order of entries in the list can be arbitrary.
     *
     * @return a list of mappings in this map
     */
    public List<Entry<K, V>> entries() {
    	List<Entry<K, V>> entriesList = new LinkedList<Entry<K, V>>();
    	for(int i = 0; i < table_size - 1; i++) {
    		// Only iterates through the indexes of the hash map that have a 
    		//  linked list in them
    		if(hashMap[i] != null) {
    			List<Entry<K, V>> hashIndexList = hashMap[i];
        		Iterator<Entry<K, V>> itr = hashIndexList.iterator();
        		// Adds each Entry in the current index of the hash map to a new
        		//  list of Entryies that will later be returned.
        		while(itr.hasNext()) {
        			entriesList.add(itr.next());
        		}
        	}
    		
    	}
    	// Returns the entire list of Entries in the hash map
    	return entriesList;
    }
}

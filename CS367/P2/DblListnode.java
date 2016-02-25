package com.zachambur;

///////////////////////////////////////////////////////////////////////////////
//                   ALL STUDENTS COMPLETE THESE SECTIONS
// Main Class File:  Dot Matrix Character
// File:             DblListnode.java
// Semester:         CS367 Spring 2014
//
// Author:           Zach Ambur
// CS Login:         zachary
// Lecturer's Name:  Jim Skrentny
// Lab Section:      null
//
//////////////////////////// 80 columns wide //////////////////////////////////

public class DblListnode<E> {
	
	//*** fields ***
    private DblListnode<E> prev;
    private E data;
    private DblListnode<E> next;
 
  //*** constructors ***
    // 3 constructors
    public DblListnode() {
        this(null, null, null);
    }
 
    public DblListnode(E d) {
        this(null, d, null);
    }
 
    public DblListnode(DblListnode<E> p, E d, DblListnode<E> n) {
        prev = p;
        data = d;
        next = n;
    }
    
  //*** methods ***
    // access to fields
    public E getData() {
        return data;
    }
 
    public DblListnode<E> getNext() {
        return next;
    }
 
    public DblListnode<E> getPrev() {
        return prev;
    }
 
    // modify fields
    public void setData(E d) {
        data = d;
    }
 
    public void setNext(DblListnode<E> n) {
        next = n;
    }
 
    public void setPrev(DblListnode<E> p) {
        prev = p;
    }

}

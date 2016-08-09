/****************************************************************
 * Pot.java
 * Do not modify this file!
 * This file is for GUI, you don't need to read or understand this file.
 * ------------------------------
 * Licensing Information: You are free to use or extend these projects for educational purposes provided that
 * (1) you do not distribute or publish solutions, (2) you retain the notice, and (3) you provide clear attribution to UW-Madison
 * 
 * Attribute Information: The Mancala Game was developed at UW-Madison.
 * 
 * The initial project was developed by Chuck Dyer(dyer@cs.wisc.edu) and his TAs.
 * 
 * Current Version with GUI was developed by Fengan Li(fengan@cs.wisc.edu).
 * Some GUI componets are from Mancala Project in Google code.
 */

import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.GradientPaint;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Random;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

import javax.swing.JComponent;



public class Pot extends JComponent {
	
	private static final long serialVersionUID = 4648914916326942097L;
	private static final int BEAN_COUNT = Mancala.NUM_STONES;
	protected boolean mouseOver;
	protected boolean beansInitialized;
	protected List<Bean> beans;
	protected Lock lock = new ReentrantLock();
	private boolean isLower;
	private final int index;
	
	public Pot(boolean isLower, int index)
	{
		this.index = index;
		this.isLower = isLower;
		mouseOver = false;
		beansInitialized = false;
	}

	protected void initBeans() {
		beans = Collections.synchronizedList(new ArrayList<Bean>());
		addBeans(BEAN_COUNT);
	}
	
	public void addBeans(int amount) {
		Random rnd = new Random();
		int x;
		int y;
		long startTime = System.currentTimeMillis();
		for(int i = 0; i < amount; i++) {
			x = (int) ((getWidth() - 15) * 0.25) + rnd.nextInt((int) ((getWidth() - 15) * 0.5));
			y = (int) ((getHeight() - 15) * 0.25) + rnd.nextInt((int) ((getHeight() - 15) * 0.5));
			Bean bean = new Bean(1.0 * x / getWidth(), 1.0 * y / getHeight());
			if(isSuitable(bean) || System.currentTimeMillis() - startTime > 200) {
				lock.lock();
				beans.add(bean);
				lock.unlock();
			}
			else
				i--;
		}
		refresh();
	}
	
	public void removeBeans() {
		lock.lock();
		beans.clear();
		lock.unlock();
		refresh();
	}
	
	

	@Override
	protected void paintComponent(Graphics g) {
		super.paintComponent(g);
		Graphics2D g2d = (Graphics2D) g;
		if (!mouseOver) {
			g2d.setColor(new Color(92, 51, 23));
		} else {
			g2d.setColor(new Color(139, 69, 19));
		}
		g2d.setStroke(new BasicStroke(5F, BasicStroke.CAP_ROUND, BasicStroke.JOIN_ROUND));
		
		g2d.drawOval((int) (getWidth() * 0.1), (int) (getHeight() * 0.1), (int) (getWidth() * 0.8), (int) (getHeight() * 0.8));
		g2d.setColor(new Color(255, 69, 0));
		g2d.setStroke(new BasicStroke(0.1F, BasicStroke.CAP_ROUND, BasicStroke.JOIN_ROUND));
		if(!beansInitialized) {
			beansInitialized = true;
			initBeans();
		}
		lock.lock();
		for(Bean bean : beans) {
			int x = (int) (bean.getX() * getWidth());
			int y = (int) (bean.getY() * getHeight());
			GradientPaint gp = new GradientPaint(x + 2, y + 2, new Color(/*255, 69, 0*/255, 81, 71), x + 13, y + 13, new Color(139, /*37*/9, 0), false);
			g2d.setPaint(gp);
			g2d.fillOval(x, y, 15, 15);
		}
		g2d.setColor(Color.white);
		if(isLower) {
			g2d.drawString(beans.size() + "", (int)(getWidth() * 0.5) - 5, getHeight());
		} else {
			g2d.drawString(beans.size() + "", (int)(getWidth() * 0.5) - 5, 10);
		}
		lock.unlock();
	}
	
	private boolean isSuitable(Bean bean)
	{
		for(Bean b : beans) 
		{
			if(b.distanceFrom(bean, getWidth(), getHeight()) < 10.0)
			{
//				System.out.println("Too close!");
				return false;
			}
		}
		return true;
	}
	
	protected void refresh() 
	{
		this.repaint();
	}
	
	protected void createListener()
	{
		this.addMouseListener(new MouseAdapter() 
		{
			@Override
			public void mouseEntered(MouseEvent e) 
			{
				boolean selected = (Match.player1Move && ((Pot)e.getSource()).index < 6) ||  (!Match.player1Move && ((Pot)e.getSource()).index >= 6);
				if (selected)
				{
					mouseOver = true;
					refresh();
				}
			}
			@Override
			public void mouseExited(MouseEvent e)
			{
				boolean selected = (Match.player1Move && ((Pot)e.getSource()).index < 6) ||  (!Match.player1Move && ((Pot)e.getSource()).index >= 6);
				if (selected)
				{
					mouseOver = false;
					refresh();
				}
			}
			@Override
			public void mouseClicked(MouseEvent e)
			{
				boolean selected = (Match.player1Move && ((Pot)e.getSource()).index < 6) ||  (!Match.player1Move && ((Pot)e.getSource()).index >= 6);
				if (selected)
				{
					mouseOver = false;
					HumanPlayer.choice = ((Pot)e.getSource()).index;
				}
			}
		});
	}

}

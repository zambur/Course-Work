/****************************************************************
 * BigPot.java
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

import java.awt.Color;
import java.awt.Dimension;
import java.awt.FontMetrics;
import java.awt.Graphics;
import java.awt.geom.Rectangle2D;
import java.util.ArrayList;
import java.util.Collections;

public class BigPot extends Pot {
	
	private static final long serialVersionUID = -9024340637590238213L;
	private final String playerName;
	
	public BigPot(String playerName) 
	{
		super(true, -1);
		this.playerName = playerName;
		this.setPreferredSize(new Dimension(120,300));
	}

	@Override
	protected void initBeans() {
		beans = Collections.synchronizedList(new ArrayList<Bean>());
		refresh();
	}
	
	@Override
	protected void paintComponent(Graphics g) {
		super.paintComponent(g);
		g.setColor(Color.white);
		FontMetrics fm = g.getFontMetrics();
		Rectangle2D rect = fm.getStringBounds(playerName, g);
		int textWidth = (int) rect.getWidth();
		g.drawString(playerName, (getWidth() - textWidth) / 2, 20);
	}
	

}

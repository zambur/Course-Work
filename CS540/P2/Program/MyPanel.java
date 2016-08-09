/****************************************************************
 * MyPanel.java
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

import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JPanel;

public class MyPanel extends JPanel {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8554162233768101479L;

	@Override
	protected void paintComponent(Graphics g) {
		Image image = (new ImageIcon("wood-texture.jpg")).getImage();
		g.drawImage(image, 0, 0, getWidth(), getHeight(), null);
		setOpaque(false);
		super.paintComponent(g);
		setOpaque(true);
	}
}

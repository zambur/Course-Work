/****************************************************************
 * GUI.java
 * Do not modify this file!
 * This file is for GUI, you don't need to read or understand this file.
 * -----------------------------------------------------------------------------------------------------------------
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

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;

import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.SwingUtilities;
import javax.swing.text.DefaultCaret;


public class GUI {
	public Pot[] pots;
	public Pot bigPot1;
	public Pot bigPot2;
	
	public JTextArea textArea;
	public JScrollPane scrollPanel;
	public String logs;
	public String player1;
	public String player2;
	public JFrame frame;
	
	public GUI(String player1, String player2) 
	{
		this.player1 = player1;
		this.player2 = player2;
		Dimension screen = Toolkit.getDefaultToolkit().getScreenSize();
		frame = new JFrame("Mancala");
		frame.setSize(860, 450);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLocation((screen.width - 860) / 2, (screen.height - 320) / 2);
		frame.setVisible(true);
		Container content = frame.getContentPane();
		content.setLayout(new BorderLayout());
		createPots();
		JPanel center = new JPanel(new GridLayout(2, 6));
		center.setOpaque(false);
		MyPanel panel = new MyPanel();
		panel.setLayout(new BorderLayout());
		panel.add(center, BorderLayout.CENTER);
		addPots(center, panel);
		content.add(panel, BorderLayout.CENTER);
		
		 SwingUtilities.invokeLater(new Runnable()
		 {
	            public void run() 
	            {
	                //frame.init();
	                frame.setSize(860, 320);
	                frame.setVisible(true);
	            }
	        });
	}
	
	public void refreshBigPots() {
		bigPot1.refresh();
		bigPot2.refresh();
	}
	
	private void addPots(JPanel center, MyPanel panel) {
		panel.add(bigPot1, BorderLayout.EAST);
		panel.add(bigPot2, BorderLayout.WEST);
		panel.add(scrollPanel, BorderLayout.SOUTH);
		
		
		for (int i = 11; i > 5; i--) {
			center.add(pots[i]);
		}
		
		for (int i = 0; i < 6; i++) {
			center.add(pots[i]);
		}
	}

	private void createPots()
	{
		bigPot1 = new BigPot("P1:" + player1);
		bigPot2 = new BigPot("P2:" + player2);
		pots = new Pot[12];
		for (int i = 0; i < pots.length; i++)
		{
			if (i < 6) 
				pots[i] = new Pot(true, i);
			else
				pots[i] = new Pot(false, i);
			pots[i].createListener();
		}
		
		textArea = new JTextArea(5, 20);
		textArea.setEditable(false);
		textArea.setLineWrap(true);
		textArea.setWrapStyleWord(true);
		
		textArea.setOpaque(false);
		logs ="";
		textArea.setText(logs);
		scrollPanel = new JScrollPane(textArea);
		DefaultCaret caret = (DefaultCaret)textArea.getCaret();
		caret.setUpdatePolicy(DefaultCaret.ALWAYS_UPDATE);
		
	}
	
	public GUI getGUI() 
	{
		return this;
	}
	
	public void applyMove(int bin, boolean player1, GameState context)
	{
		int [] state = context.state;
    	//clear the original bin
		int stones = state[bin];
    	state[bin] = 0;
    	
    	//clear the bin in GUI
    	if (player1)
    		pots[bin].removeBeans();
    	else
    		pots[bin+6].removeBeans();
    	
    	//sleep to make the move smoother
    	tSleep(Mancala.SLEEP_TIME);
    	
    	int stoneTemp = stones;
    	for (int i = 0; i < stoneTemp; ++i) 
    	{
    		int nextBin = (bin+i+1)%14;
    		if (!(nextBin == 6 && bin > 6) && !(nextBin == 13 && bin < 7))
    			++state[nextBin];
    		else
    			++stoneTemp; //ship that stone
    	}
    	
    	//scatter the stones in the consequent bins
 
    	for (int i = 0; i < stones; i++)
    	{
    		int nextBin = (bin + i + 1) % 14;
    		if (!(nextBin == 6 && bin > 6) && !(nextBin == 13 && bin < 7))
    		{
    			if (nextBin == 6 && player1) //this is the only case we can put stone in the mancala
    				bigPot1.addBeans(1);
    			else if (nextBin == 6 && !player1)
    				bigPot2.addBeans(1);
    			if (player1 && nextBin < 6)
    				pots[nextBin].addBeans(1);
    			else if (player1 && nextBin > 6)
    				pots[nextBin - 1].addBeans(1);
    			else if (!player1 && nextBin < 6)
    				pots[nextBin + 6].addBeans(1);
    			else if (!player1 && nextBin > 6)
    				pots[nextBin - 7].addBeans(1);
    		}
    		else
    			++ stones;
    		//sleep for a little bit
    		tSleep(Mancala.SLEEP_TIME);
    	}
    	int lastBin = (bin+stones)%14;
    	
    	//if free turn
    	if ((lastBin == 6 || lastBin == 13) && !context.gameOver()) 
    	{
    		return;
        }
    	
    	boolean lastBinEmpty = state[lastBin] == 1;
    	boolean lastBinOnYourSide = bin/7 == lastBin/7;
   
    	if (lastBinEmpty && lastBinOnYourSide && lastBin != 6 && lastBin != 13) 
    	{
    	
    		
    		int mancalaBin =  context.mancalaOf(bin);
    		int neighborBin = context.neighborOf(lastBin);
    		
    		//If mancala happens, we also update the GUI
    		int newNeighborBin, newLastBin;
    		if (player1)
    		{
    			newLastBin = lastBin; //should be in our side
    			newNeighborBin = neighborBin - 1;
    			pots[newLastBin].removeBeans();
    			tSleep(Mancala.SLEEP_TIME);
    			pots[newNeighborBin].removeBeans();
    			tSleep(Mancala.SLEEP_TIME);
    			bigPot1.addBeans(state[neighborBin] + 1);
    		}
    		else
    		{
    			newLastBin = lastBin + 6;
    			newNeighborBin = neighborBin - 7;
    			
    			pots[newLastBin].removeBeans();
    			tSleep(Mancala.SLEEP_TIME);
    			pots[newNeighborBin].removeBeans();
    			tSleep(Mancala.SLEEP_TIME);
    			bigPot2.addBeans(state[neighborBin] + 1);
    		}
    		
    		state[mancalaBin] += state[neighborBin] + 1;
    		state[neighborBin] = 0;
    		state[lastBin] = 0;
    	}
        if (context.gameOver())
        {
          context.stonesToMancalas();
          
          //we also update the gui if this happens
          for (int i = 0; i < 6; i++)
          {
        	  bigPot1.addBeans(pots[i].beans.size());
        	  pots[i].removeBeans();
          }
          for (int i = 6; i < 12; i++)
          {
        	  bigPot2.addBeans(pots[i].beans.size());
        	  pots[i].removeBeans();
          }
        }
    
	}
	public void tSleep(int sleepTime)
	{
		try 
    	{
    	    Thread.sleep(sleepTime);                 
    	} catch(InterruptedException ex) 
    	{
    	    Thread.currentThread().interrupt();
    	}
	}
	
	
}

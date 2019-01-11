using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxScript : MonoBehaviour {
	public Text boxText; //The text on the front of the box.
	public float boxValue; //The value found within the box.
	public bool clickable; //Whether the box can be clicked.
	bankerScript banker; //This is the banker.
	setupScript boxManager; //This manages the boxes.
	//Makes the box clickable when it spawns.
	void Start() {
		clickable = true;
		banker = GameObject.Find("banker").GetComponent<bankerScript>(); //We find the banker and set it.
		boxManager = GameObject.Find("banker").GetComponent<setupScript>();
	}
	//Reveals the box value. Removes the box from the game.
	public void RevealBox() {
		boxText.text = "£" + boxValue;
		boxManager.boxes.Remove(boxValue);
	}
	//Opens the box.
	public void OpenBox() {
		if(banker.boxesToChoose>0){ //Checks if the player is able to choose a box.
			clickable = false; //Stops the player from clicking this box.
			bool shouldReveal = true; //This is whether the box value should be revealed.

			banker.boxesToChoose -= 1; //The player can now choose one less box.
			if(banker.boxesToChoose == 0) { //This checks if the player cant choose any more boxes.
				if(banker.currentRound == 0) { //This checks if it is the first round.
					transform.position = new Vector2(2.5f,-3.7f); //We give the player their box.
					banker.playerBox = GetComponent<boxScript>(); //This allows us to access the box script.
					shouldReveal = false; //We tell the box not to reveal.
				}
				banker.AdvanceRound(); //We tell the banker to move to the next round.
			}
			//We reveal the box if the box is able to be revealed.
			if(shouldReveal) {
				RevealBox();
			}
		}
	}
	//Opens the box when it is clicked.
	void OnMouseDown() {
		if(clickable) {
			OpenBox();
		}	
	}
}

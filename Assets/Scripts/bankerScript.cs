using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bankerScript : MonoBehaviour {
	public Text bankerText; //Displays what the banker is saying.
	public int boxesToChoose; //How many boxes the player can currently choose.
	public int[] boxesPerRound; //How many boxes are in each round.
	public int currentRound; //This is the current round.
	public float currentOffer; //This is the current offer.
	public setupScript boxManager; //This is the box manager.
	public GameObject winScreen; //This is the winscreen.
	public GameObject dealScreen; //This is the dealscreen.
	public boxScript playerBox; //This is the players box.
	public bool boxSwap; //This is where there is a box swap.
	public Text winText; //This is the text which is displayed when the player wins.

	// Use this for initialization
	void Start () {
		boxesToChoose = boxesPerRound[currentRound]; //Sets how many boxes the player can choose in the first round.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//This is the offer made to the player.
	void MakeOffer() {
		currentOffer = 0.0f; //This resets the previous offer.
		float average = 0.0f; //This is what the average is going to be.
		//This adds all of the box values together
		for(int i= 0; i < boxManager.boxes.Count; i++) { 
			average += boxManager.boxes[i];
		}
		average /= boxManager.boxes.Count; // We work out the average of the boxes
		currentOffer = System.Convert.ToSingle(System.Math.Round((average)*(0.01f + (currentRound - 1)* 0.06f))); //This is my algorithm for working out the bankers offer.

	}
	//This moves the game to the next round.
	public void AdvanceRound () {
		print(currentRound); //Prints the current round.
		//Checks if the round is 7, then asks the player if they want to swap.
		if(currentRound == 7) {
					boxSwap = true;
					dealScreen.SetActive(true);
					bankerText.text = "Would you like to swap?";
				}
		//This checks if it is the last round.
		if(currentRound + 1>= boxesPerRound.Length) {
			
		}
		else if(currentRound == 0) {
			currentRound += 1;
			boxesToChoose = boxesPerRound[currentRound]; //Sets how many boxes the player can choose this round.
			bankerText.text = "Please choose " + boxesToChoose + " boxes"; //This asks the player to choose boxes.
		}
		//This checks if it is not the last round.
		else {
			MakeOffer();
			bankerText.text = "I'd like to make you an offer of £" + currentOffer; //The banker tells the player how many boxes to choose.
			dealScreen.SetActive(true); //This activates the deal screen.
			
		}
	}
}

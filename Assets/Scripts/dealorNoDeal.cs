using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dealorNoDeal : MonoBehaviour {
public bool isDeal; //Are you in a deal state or not.
public bankerScript banker; //This allows the player to access the banker functions.
public setupScript boxManager; //Uses it to access the boxes.
	// Use this for initialization
	void Start () {
	GetComponent<Button>().onClick.AddListener(OnClick); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Everytime the deal or no deal boxes are clicked, the script runs.
	void OnClick() {
		if(isDeal) {
			if(banker.boxSwap) {
			banker.winScreen.SetActive(true);
				banker.winText.text = "Congratulations you win £"+ boxManager.boxes[0]; 
			}
			else {
				banker.winScreen.SetActive(true);
				banker.winText.text = "Congratulations you win £"+banker.currentOffer;
			}
		}
		else {
			if(banker.boxSwap) {
				banker.winScreen.SetActive(true);
				banker.winText.text = "Congratulations you win £"+ banker.playerBox.boxValue;
			}
			else {
				banker.dealScreen.SetActive(false);
				banker.currentRound += 1;
				banker.boxesToChoose = banker.boxesPerRound[banker.currentRound]; //Sets how many boxes the player can choose this round.
				banker.bankerText.text = "Please choose " + banker.boxesToChoose + " boxes";
			}	
		}
	}
}

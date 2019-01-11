using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setupScript : MonoBehaviour {
public List<float> boxes; //This is a list which keeps track of all of the boxes currently in play.
public GameObject boxTemplate; //This is the box prefab.
public GameObject winScreen;
public GameObject dealScreen;
List<float> unshuffledBoxes; //These are the boxes which are in size order.
	// Use this for initialization
	void Start () {
		//This is a list of all the values which can be found in the boxes.
		boxes = new List<float> {
			0.01f, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400,
			500, 750, 1000, 5000, 10000, 25000, 50000, 75000,
			100000, 200000, 300000, 400000, 500000, 750000, 1000000
		};
		//These are the values of the boxes that will not be shuffled.
		unshuffledBoxes = new List<float> {
			0.01f, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400,
			500, 750, 1000, 5000, 10000, 25000, 50000, 75000,
			100000, 200000, 300000, 400000, 500000, 750000, 1000000
		};
    	Shuffle(); //This shuffles the box values.
		Vector2 currentPosition = new Vector2(-3, 2);
		for(int i = 0; i<boxes.Count; i++) {
			GameObject box= Instantiate(boxTemplate, currentPosition, Quaternion.identity); //Creates the box.
			box.GetComponent<boxScript>().boxValue = boxes[i]; //Tells the box what is inside of it.
			box.GetComponent<boxScript>().boxText.text = "" + i; //Puts the box number on the front of the box.
			//Works out the position of the next box.
			currentPosition += new Vector2(1.5f, 0); 
			if(currentPosition.x >4.5f) {
				currentPosition = new Vector2(-3, currentPosition.y - 1);
			}
		}
		winScreen.SetActive(false); //This sets the winscreen to false until we need it.
		dealScreen.SetActive(false); //This sets the dealscreen to false until we need it.
	}
	
	void Shuffle() { //This shuffles the box values.
		for(int i= 0; i<boxes.Count; i++) {
			int randomnumber= Random.Range(i,boxes.Count); //This picks a random box number.
			float tempvalue = boxes[randomnumber]; //This is the box that has been chosen randomly.
			//We swap the current box with the random box.
			boxes[randomnumber] = boxes[i];
			boxes[i] = tempvalue;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}

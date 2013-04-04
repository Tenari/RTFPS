// Daniel Zapata & Brian Sherman

using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {
	
	// Crosshair stuff
	public Texture2D crosshairTexture;
	Rect crosshairPosition;
	
	// House HP Bar stuff
	public int houseStartHP = 100000;
	public float fullBarWidth = 500.0f;
	public int barHeight = 33;
	public GameObject house1;
	public string house1Tag = "House1";
	public GameObject house2;
	public string house2Tag = "House2";
	public GameObject house3;
	public string house3Tag = "House3";
	
	// Unit statistics stuff, Brian Sherman
	public GameObject gameMaster;
	public string gameMasterTag = "GameController";
	
	// Use this for initialization
	void Start () {
		crosshairPosition = new Rect(
				((Screen.width - crosshairTexture.width)/2),
				((Screen.height - crosshairTexture.height)/2), 
				crosshairTexture.width, 
				crosshairTexture.height);		// Make the rectangle in the center of the screen.
		
		// Initialize houses.
		house1 = GameObject.FindGameObjectWithTag(house1Tag);
		house2 = GameObject.FindGameObjectWithTag(house2Tag);
		house3 = GameObject.FindGameObjectWithTag(house3Tag);
		
		// Initialize game master
		gameMaster = GameObject.FindGameObjectWithTag(gameMasterTag);
	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void OnGUI(){
		GUI.DrawTexture(crosshairPosition, crosshairTexture, ScaleMode.ScaleToFit, true, 0.0f); // Draws the crosshair.
		
		// House HP bar stuff
		Health healthComponent = house1.GetComponent<Health>();
		if(healthComponent!=null){
			float hpRatio = ((float)healthComponent.health) / houseStartHP;
			Rect hpBarRect = new Rect(0, 0, hpRatio * fullBarWidth, barHeight);	// Calculate width of bar based on ratio of HP left.
			GUI.Box(hpBarRect, house3Tag);		// Switched the tag because I think numbering the houses left to right for the player is better than right to left, and I didnt want to change the scene.
		}
		
		// House 2
		healthComponent = house2.GetComponent<Health>();
		if(healthComponent!=null){
			float hpRatio = ((float)healthComponent.health) / houseStartHP;
			Rect hpBarRect = new Rect(0, 35, hpRatio * fullBarWidth, barHeight);	// Calculate width of bar based on ratio of HP left.
			GUI.Box(hpBarRect, house2Tag);
		}
		// House 3
		healthComponent = house3.GetComponent<Health>();
		if(healthComponent!=null){
			float hpRatio = ((float)healthComponent.health) / houseStartHP;
			Rect hpBarRect = new Rect(0, 70, hpRatio * fullBarWidth, barHeight);	// Calculate width of bar based on ratio of HP left.
			GUI.Box(hpBarRect, house1Tag);
		}
		
		///Enemy & Ally counters, by Brian Sherman
		GameMasterScript gm = gameMaster.GetComponent<GameMasterScript>();
		SpawnAllyUnit h1 = house1.GetComponent<SpawnAllyUnit>();
		SpawnAllyUnit h2 = house2.GetComponent<SpawnAllyUnit>();
		SpawnAllyUnit h3 = house3.GetComponent<SpawnAllyUnit>();
		int laneLeftEnemies = gm.spawn1Count;
		int laneMidEnemies = gm.spawn2Count;
		int laneRightEnemies = gm.spawn3Count;
		int house1Allies;
		if(h1 != null)
			house1Allies = h1.numUnitsLeft;
		else
			house1Allies = 0;
		int house2Allies;
		if(h2 != null)
			house2Allies = h2.numUnitsLeft;
		else
			house2Allies = 0;
		int house3Allies;
		if(h3 != null)
			house3Allies = h3.numUnitsLeft;
		else
			house3Allies = 0;
		//Putting it at the bottom
		Rect leftLane = new Rect(0,7*(float)Screen.height/8, (float)Screen.width/3, (float)Screen.height/8f);
		Rect midLane = new Rect((float)Screen.width/3,7*(float)Screen.height/8, (float)Screen.width/3, (float)Screen.height/8f);
		Rect rightLane = new Rect(2*(float)Screen.width/3,7*(float)Screen.height/8, (float)Screen.width/3, (float)Screen.height/8f);
		GUI.Box(leftLane, "Spawns Left:\nLeft Lane Allies:\tLeft Lane Enemies:\n" + house1Allies.ToString() + "\t\t" + laneLeftEnemies.ToString());
		GUI.Box(midLane, "Spawns Left:\nMiddle Lane Allies:\tMiddle Lane Enemies:\n" + house2Allies.ToString() + "\t\t" + laneMidEnemies.ToString());
		GUI.Box(rightLane, "Spawns Left:\nRight Lane Allies:\tRight Lane Enemies:\n" + house3Allies.ToString() + "\t\t" + laneRightEnemies.ToString());
		/// End Brian Sherman's additions
	}
}

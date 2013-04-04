// Daniel Zapata

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
	}
}

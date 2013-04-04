// Daniel Zapata

using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {
	
	// Crosshair stuff
	public Texture2D crosshairTexture;
	Rect crosshairPosition;
	
	// Use this for initialization
	void Start () {
		crosshairPosition = new Rect(
				((Screen.width - crosshairTexture.width)/2),
				((Screen.height - crosshairTexture.height)/2), 
				crosshairTexture.width, 
				crosshairTexture.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnGUI(){
		GUI.DrawTexture(crosshairPosition, crosshairTexture, ScaleMode.ScaleToFit, true, 0.0f); // Draws the crosshair.
	}
}

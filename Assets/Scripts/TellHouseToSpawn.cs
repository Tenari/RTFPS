// Daniel Zapata
using UnityEngine;
using System.Collections;

// Put inside of Main player to allow them to spawn units from houses.
public class TellHouseToSpawn : MonoBehaviour {
	
	public float rayCastDistance = 500.0F;
	
	// House Tags
	public string house1Tag = "House1";
	public string house2Tag = "House2";
	public string house3Tag = "House3";
	
	// Crosshair stuff
	public Texture2D crosshairTexture;
	Rect crosshairPosition;
	
	// Use this for initializing the crosshairPosition to the center of the screen.
	void Start () {
	}
	
	// Update is called once per frame
	// In this implementation, it tries to send a spawnunit message to houses in front of it.
	void Update () {
		crosshairPosition = new Rect(((Screen.width - crosshairTexture.width)/2),((Screen.height - crosshairTexture.height)/2), crosshairTexture.width, crosshairTexture.height);
		

		// If the left click is down,
		if(Input.GetMouseButtonDown(0)){
			
			RaycastHit hit;			// Make the thing to receive information on hits.
			// If the Raycast from the cam's position, along the cam's direction hits something within rayCastDistance meters, it'll put collision info in hit.
			if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayCastDistance)){
				
				// If we hit a house.
				if ( (hit.collider.CompareTag(house1Tag)) || (hit.collider.CompareTag(house2Tag)) || (hit.collider.CompareTag(house3Tag))){
					
					// Spawn a new unit.
					hit.collider.GetComponent<SpawnAllyUnit>().SendMessage("SpawnNewUnit");
				}
			}
		}	
	}
	
	// Draws the crosshair.
	void OnGUI(){
		GUI.DrawTexture(crosshairPosition, crosshairTexture, ScaleMode.ScaleToFit, true, 0.0f);
	}
	
	
}

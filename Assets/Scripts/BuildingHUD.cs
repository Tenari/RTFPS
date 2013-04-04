using UnityEngine;
using System.Collections;

public class BuildingHUD : MonoBehaviour {
	
	//Used to trigger the HUD; only happens if the player looks at the building while on top of the tower
	//(i.e. their z position is greater than, say, 50 -- the tower itself is ~100)
	void OnMouseDown () {
		if (GameObject.Find("First Person Controller").transform.position.z < 50)
			return;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

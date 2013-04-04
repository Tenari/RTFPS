// Daniel Zapata
using UnityEngine;
using System.Collections;

public class SpawnAllyUnit : MonoBehaviour {
	
	public string allyUnitPrefabName = "YourUnit";// Prefab name.
	public Vector3 pos;					// The position of the spawn.
	public float houseSize = 20.0F;		// The size of the houses.
	public int houseNum;
	public int numUnitsLeft = 4;		// Limits the number of units able to be generated.
	// Use this for initialization
	void Start () {
		pos = new Vector3(gameObject.transform.position.x+houseSize,
						  gameObject.transform.position.y,
						  gameObject.transform.position.z+houseSize);
	}
	
	// Update is called once per frame
	// Regens units Left randomly over time.
	void Update () {
		int rand = (int)Random.Range(0,1000);
		if (rand >= 999){
			numUnitsLeft++;
		}
	}
	
	// Is called to spawn a new unit.
	public void SpawnNewUnit(){
		if(numUnitsLeft>0){			// If units remain in the house,
			numUnitsLeft--;			// Subtract one, and send him out.
			// Instantiate a copy of the unit at the initially determined position, with this rotation.
			Instantiate(Resources.Load(allyUnitPrefabName,typeof(GameObject)), pos, transform.rotation);
		/*Use this to spawn a unti and then give it the id of units to attack
		 * GameObject newunit = (GameObject)Instantiate(Resources.Load(allyUnitPrefabName,typeof(GameObject)), pos, transform.rotation);
		   newunit.sendMessage("getNextTarget", houseNum);
		   and remove the line getNextTarget(1) from YourUnitScript, in start(), it tells units to attack only enemy units with id 1
		*/
		}
	}
}

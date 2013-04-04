//Grader: code done by Nik Bauer, njb26
using UnityEngine;
using System.Collections;

public class EnemyUnitSpawn : MonoBehaviour {
	
	public int targetId;
	public GameObject target;
	//private int counter = 0;
	public GameObject eUnit;
	private Vector3 pos;
	
	
	// Use this for initialization
	void Start () {
		pos = gameObject.transform.position;
		pos.x += 10;
		pos.z += 10;
		pos.y += 5;	
		//when spawned, will tell units to attack house that it is given, based on spawn
		switch(targetId){
		case 1:
			target = GameObject.FindGameObjectWithTag("House1");
			break;
		case 2:
			target = GameObject.FindGameObjectWithTag("House2");
			break;
		case 3:
			target = GameObject.FindGameObjectWithTag("House3");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void spawnUnit(){
			
		GameObject newUnit = (GameObject)Instantiate(eUnit, pos, transform.rotation);
		switch(targetId){
		case 1:
			newUnit.SendMessage("getNextTarget", "House1");
			break;
		case 2:
			newUnit.SendMessage("getNextTarget", "House2");
			break;
		case 3:
			newUnit.SendMessage("getNextTarget", "House3");
			break;
		}
	}
}

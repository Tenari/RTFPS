using UnityEngine;
using System.Collections;

public class EnemyUnitSpawn : MonoBehaviour {
	
	public int targetId;
	public GameObject target;
	private int counter = 0;
	
	// Use this for initialization
	void Start () {
		//when spawned, will tell units to attack house that it is given, based on spawn
		switch(targetId){
		case 1:
			target = GameObject.FindGameObjectWithTag("House1");
			break;
		case 2:
			target = GameObject.FindGameObjectWithTag("House2");
			break;
		case 3:
			target = GameObject.FindGameObjectsWithTag("House3");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		//for right now, spawns unit every 500 frames
		if(counter == 500){
			counter = 0;
			spawnUnit();			
		}	
	}
	
	void spawnUnit(){
		
	}
}

using UnityEngine;
using System.Collections;

public class GameMasterScript : MonoBehaviour {
	public int spawn1Count, spawn2Count, spawn3Count;
	public bool round1, round2 = true;
	float spawnDelay = 2.0f;
	float nextSpawn = 0.0f;
	GameObject[] enemySources;

	// Use this for initialization
	
		void Start () {
		enemySources = GameObject.FindGameObjectsWithTag("EnemySpawn");
		/**** ROUND 1 **********
		 * Spawn 1: 5 Units
		 * Spawn 2: 3 Units
		 * Spawn 3: 5 Units
		 */
			if(round1){
				startRound(5, 3, 5, round1);
			}
			/**** ROUND 2 **********
		 * Spawn 1: 2 Units
		 * Spawn 2: 10 Units
		 * Spawn 3: 5 Units
		 */	
			else if(round2){
				startRound(2, 10, 5, round2);
			}
		}	
	
	
	
	
	// Update is called once per frame
	void Update () {
		nextSpawn += Time.deltaTime;
		//if 2 seconds have passed
		if(nextSpawn >= spawnDelay){
			foreach(GameObject obj in enemySources){
				//verify it is an EnemySource
				if(obj.GetComponent<EnemyUnitSpawn>()){
					//if first enemySource			
					if (obj.GetComponent<EnemyUnitSpawn>().targetId == 1){
						if(spawn1Count > 0){
						//	obj.GetComponent<EnemyUnitSpawn>().spawnUnit();
							spawn1Count--;
						}
					}
				//if second enemySource
				else if(obj.GetComponent<EnemyUnitSpawn>().targetId == 2){
					if(spawn2Count > 0){
						//	obj.GetComponent<EnemyUnitSpawn>().spawnUnit();
							spawn2Count--;
						}
				
				}
				//if third enemySource
				else if(obj.GetComponent<EnemyUnitSpawn>().targetId == 3){
					if(spawn3Count > 0){
						//	obj.GetComponent<EnemyUnitSpawn>().spawnUnit();
							spawn3Count--;
						}
				}
				
				}
			}
		//can modify this, make it an array that says if all round before are false, call next
		//but only 2 rounds for now
		if(spawn1Count == 0 && spawn2Count == 0 && spawn3Count == 0){
			Start(); //will call Start, with round1== false, so round 2 will begin
		}
		
		//reset delay for spawns
			nextSpawn = 0.0f;
		}
	}
	
	
	void startRound(int spawn1, int spawn2, int spawn3, bool round){	
		spawn1Count = spawn1;
		spawn2Count = spawn2;
		spawn3Count = spawn3;
		round = false;
	}
	
}

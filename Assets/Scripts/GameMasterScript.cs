//First half of this by Nik Bauer, njb26

using UnityEngine;
using System.Collections;

public class GameMasterScript : MonoBehaviour {
	public int spawn1Count, spawn2Count, spawn3Count = 0;
	public int roundVal = 1;
	float spawnDelay = 2.0f;
	float nextSpawn = 0.0f;
	GameObject[] enemySources;
	GameObject[] allEnemies;
	public string enemyTag = "Enemy";
	public string allyTag = "Ally";

	// Use this for initialization
	
		void Start () {
		enemySources = GameObject.FindGameObjectsWithTag("EnemySpawn");
		/**** ROUND 1 **********
		 * Spawn 1: 5 Units
		 * Spawn 2: 3 Units
		 * Spawn 3: 5 Units
		 */
			if(roundVal == 1){
				startRound(5, 3, 5);
			}
			else if (roundVal== 2){
				startRound(2, 10, 5);
			}
			/**** ROUND 2 **********
		 * Spawn 1: 2 Units
		 * Spawn 2: 10 Units
		 * Spawn 3: 5 Units
		 */	
			
		}	
	
	
	
	
	// Update is called once per frame
	void Update () {
		allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		nextSpawn += Time.deltaTime;
		//if 2 seconds have passed
		if(nextSpawn >= spawnDelay){
			gameStarted = true;
			foreach(GameObject obj in enemySources){
				//verify it is an EnemySource
				if(obj.GetComponent<EnemyUnitSpawn>()){
					//if first enemySource			
					if (obj.GetComponent<EnemyUnitSpawn>().targetId == 1){
						if(spawn1Count > 0){
							obj.GetComponent<EnemyUnitSpawn>().spawnUnit();
							spawn1Count--;
						}
					}
				//if second enemySource
				else if(obj.GetComponent<EnemyUnitSpawn>().targetId == 2){
					if(spawn2Count > 0){
							obj.GetComponent<EnemyUnitSpawn>().spawnUnit();
							spawn2Count--;
						}
				
				}
				//if third enemySource
				else if(obj.GetComponent<EnemyUnitSpawn>().targetId == 3){
					if(spawn3Count > 0){
							obj.GetComponent<EnemyUnitSpawn>().spawnUnit();
							spawn3Count--;
						}
				}
				
				}
			
			}
		//can modify this, make it an array that says if all round before are false, call next
		//but only 2 rounds for now
		if(spawn1Count == 0 && spawn2Count == 0 && spawn3Count == 0 && allEnemies.Length ==0){
				roundVal = 2;
			Start(); //will call Start, with roundVal == 2, round 2 will begin
		}
		
		//reset delay for spawns
			nextSpawn = 0.0f;
		}
		
		// Make the Ally units DealDamage
		MakeTeamDealDamage(allyTag);
		
		// Make the enemies deal damage.
		MakeTeamDealDamage(enemyTag);
		
		
	}
	
	/// <summary>
	/// Makes the (passed in) team try to do their attacks.
	/// 
	/// By Daniel Zapata.
	/// </summary>
	/// <param name='team'>
	/// The Tag of the team that is going to attack.
	/// </param>
	void MakeTeamDealDamage(string team){
		GameObject[] teamUnits = GameObject.FindGameObjectsWithTag(team);		// Get all the units on the team.
		
		if (team == allyTag){
			foreach(GameObject obj in teamUnits){
				obj.GetComponent<DealDamage>().AllyUnitAttack();				// Call the attack method.
			}
		}
		// Same as above, but for enemies.
		if (team == enemyTag){
			foreach(GameObject obj in teamUnits){
				obj.GetComponent<DealDamage>().EnemyUnitAttack();
			}
		}
	}
	/// <summary>
	/// The specified GameObject 'obj' died, and now things need to be resolved.
	/// This method doe the resolving.
	/// 
	/// By Daniel Zapata
	/// </summary>
	/// <param name='obj'>
	/// The newly dead GameObject.
	/// </param>
	void Died(GameObject obj){
		
		// If the dead thing was an enemy unit
		if (obj.tag == enemyTag){
			GameObject[] allyTeamUnits = GameObject.FindGameObjectsWithTag(allyTag);// Get all the units on the ally team.
			
			foreach (GameObject guy in allyTeamUnits){
				YourUnitScript temp = guy.GetComponent<YourUnitScript>();	// Get the YourUnitScript component of this team member.
				temp.getNextTarget((int)Random.Range(1,3));					// Find a new target in a random lane.
			}
		}
		
		
	}
	
	//done by njb26
	void startRound(int spawn1, int spawn2, int spawn3){	
		spawn1Count = spawn1;
		spawn2Count = spawn2;
		spawn3Count = spawn3;
	}
	
}

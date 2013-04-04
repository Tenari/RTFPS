//Grader: code done by Nik Bauer, njb26

using UnityEngine;
using System.Collections;

public class YourUnitScript : MonoBehaviour {
	
	private CharacterMotor motor;
	public Vector3 directionVector;
	public GameObject target;
	public float speed = 1.0F;
	float checkTime = 2.0f;
	float timeSinceLastCheck = 0.0f;
	public int attackUnitsWithId; //1, 2, 3 depending on which spawn point it is made forom
	
	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor>();
		//following only exists for testing: travels to closest enemy with attackId 1
		//so once its there it can start dealing damage!
		//remember, once it is destoryed, call getNextTarget(int id)
		//where id matches the row it is in
		
		//can call getNextTarget(attackUnitsWithId) once the code works
		getNextTarget(1); //finds closest enemy
	}
	
	//added in. when it is spawned you can SendMessage (assignAttackid, id)
	//after enemy is defeated you can then just do getnextTarget(attackUnitsWithId)
	void assignAttackId(int id){
		attackUnitsWithId = id;
	}
	
	// Update is called once per frame
	void Update () {
		// Get the input vector from AI calculations
		directionVector = nextDirectionVector();
	
		if (directionVector != Vector3.zero) {
			// Get the length of the directon vector and then normalize it
			// Dividing by the length is cheaper than normalizing when we already have the length anyway
			float directionLength = directionVector.magnitude;
			directionVector = directionVector / directionLength;
			
			// Make sure the length is no bigger than 1
			directionLength = Mathf.Min(1, directionLength);
			
			// Make the input vector more sensitive towards the extremes and less sensitive in the middle
			// This makes it easier to control slow speeds when using analog sticks
			directionLength = directionLength * directionLength;
			
			// Multiply the normalized direction vector by the modified length
			directionVector = directionVector * directionLength;
		}
		
		// Apply the direction to the CharacterMotor
		motor.inputMoveDirection =  transform.rotation * directionVector;
		
		//every 2 seconds check for a new "closest bad guy"
		//simple way to also make it attack next bad guy if has defeated the old one
		timeSinceLastCheck += Time.deltaTime;
		if(timeSinceLastCheck >= checkTime){
			getNextTarget(attackUnitsWithId);
			timeSinceLastCheck = 0;
		}
	}
	
	Vector3 nextDirectionVector(){
		
		Vector3 targetDir = target.transform.position - transform.position;
		targetDir = new Vector3(targetDir.x, 0, targetDir.z );
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
		return transform.forward;
	}
	
	public GameObject getNextTarget(int idAttack){
		
		attackUnitsWithId = idAttack;//will only change from null if this is the first time it is called
		
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy"); //all enemies
		
		float objDistance = Mathf.Infinity;
		Vector3 position = transform.position;
		
		foreach(GameObject obj in enemies){
			//verify it is an Enemy Unit
			if(obj.GetComponent<EnemyUnitAIMovementController>()){
				//only attack it if it is in the matching row
				if (attackUnitsWithId == obj.GetComponent<EnemyUnitAIMovementController>().attackId){
					//get closest one in matching row
					Vector3 diff = obj.transform.position - position; //distance for enemy found
					float currentDistance = diff.sqrMagnitude;
					if (currentDistance < objDistance){//if this is the closest enemy
						target = obj; //this is the "target" for your unit to travel to
						objDistance = currentDistance;
					}
				}
			}
			
		}
		
		return target;
	}
}


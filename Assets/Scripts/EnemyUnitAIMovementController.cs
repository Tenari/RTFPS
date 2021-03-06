// Daniel Zapata | djz24

using UnityEngine;
using System.Collections;

public class EnemyUnitAIMovementController : MonoBehaviour {
	
	private CharacterMotor motor;
	public Vector3 directionVector;
	public GameObject target;
	public string targetTag = "Finish";
	public float speed = 1.0F;
	public int attackId =0;
	
	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor>();
		//getNextTarget(targetTag);
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
	}
	
	// Calculates the direction towards the target
	Vector3 nextDirectionVector(){
		
		Vector3 targetDir = target.transform.position - transform.position;
		targetDir = new Vector3(targetDir.x, 0, targetDir.z );
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
		return transform.forward;
	}
	
	public GameObject getNextTarget(string tag){
		target=GameObject.FindWithTag(tag);
		if(tag == "House1"){
			attackId = 1;
		}
		else if(tag == "House2"){
			attackId = 2;
		}
		else if(tag == "House3"){
			attackId = 3;
		}
		else{
			attackId = 4; //for attacking the finish/tower
		}
		return target;
	}
}

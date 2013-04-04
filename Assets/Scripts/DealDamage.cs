// Daniel Zapata

using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {
	
	public int damage = 30;			// Set how much damage this unit can deal.
	public bool rollDamage = false;	// Set to True if this unit should have a random damage value.
	public string enemyTag = "Enemy";
	public float minDistance = 1.0F;
	
	private GameObject target;
	
	public string house1Tag = "House1";
	public string house2Tag = "House2";
	public string house3Tag = "House3";
	
	// Use this for initialization
	void Start () {
		
		if(rollDamage)				// If this unit is supposed to roll its damage.
			RollDamage();			// Randomly assigns a new damage amount.
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// The method that should be called when an allied unit wants to attack.
	public void AllyUnitAttack(){
		YourUnitScript temp = gameObject.GetComponent<YourUnitScript>();	// Attempt to get the component containing the target pointer
		
		if(temp != null){
			target = temp.target;
			if(IsCloseEnough(target.transform.position)){
				target.GetComponent<Health>().TakeDamage(damage);		// The actual dealing of damage call to the enemy's Health.TakeDamage()
			}
		}
	}
	
	// The method that should be called when an allied unit wants to attack.
	public void EnemyUnitAttack(){
		EnemyUnitAIMovementController temp = gameObject.GetComponent<EnemyUnitAIMovementController>();	// Attempt to get the component containing the target pointer
		
		if(temp != null){
			target = temp.target;
			if(IsCloseEnough(target.transform.position)){
				target.GetComponent<Health>().TakeDamage(damage);		// The actual dealing of damage call to the enemy's Health.TakeDamage()
			}
		}
	}
	
	// Called when the player is clicking on an enemy unit.
	public void PlayerAttack(GameObject opponent){
		target = opponent;
		// If the player is close enough to the unit.
		if (IsCloseEnough(opponent.transform.position)){
			// Deal the damage.
			opponent.GetComponent<Health>().TakeDamage(damage);
		}
	}
	
	// Use this to randomly assign the damage dealt by this unit.
	void RollDamage(){
		damage = (int)Random.Range(0.0F,75.0F);
	}
	
	// Determines if the 
	bool IsCloseEnough(Vector3 pos){
		if((target.tag == house1Tag) || (target.tag == house2Tag) || (target.tag == house3Tag)){
			if(Vector3.Distance(pos, gameObject.transform.position) <= 30)
				return true;
			else
				return false;
		}
		if(Vector3.Distance(pos, gameObject.transform.position) <= minDistance)
			return true;
		else
			return false;
	}
}

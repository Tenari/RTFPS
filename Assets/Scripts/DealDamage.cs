// Daniel Zapata

using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {
	
	public int damage = 30;			// Set how much damage this unit can deal.
	public bool rollDamage = false;	// Set to True if this unit should have a random damage value.
	public string enemyTag = "Enemy";
	public float minDistance = 1.0F;
	
	private GameObject target;
	
	// Use this for initialization
	void Start () {
		
		if(rollDamage)				// If this unit is supposed to roll its damage.
			RollDamage();			// Randomly assigns a new damage amount.
	
	}
	
	// Update is called once per frame
	void Update () {
		YourUnitScript temp = gameObject.GetComponent<YourUnitScript>();	// Attempt to get the component containing the target pointer
		
		if(temp != null){
			target = temp.target;
			if(IsClose(target.transform.position)){
				target.GetComponent<Health>().TakeDamage(damage);
			}
		}
	}
	
	
	// Use this to randomly assign the damage dealt by this unit.
	void RollDamage(){
		damage = (int)Random.Range(0.0F,75.0F);
	}
	
	bool IsClose(Vector3 pos){
		if(Vector3.Distance(pos, gameObject.transform.position) <= minDistance)
			return true;
		else
			return false;
	}
}

// Daniel Zapata

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	/// <summary>
	/// The primary variables of the Health functionality.
	/// </summary>
	public int health = 100;					// The actual current health of the entity
	public bool dead = false;					// The death? condition. If true, entity is dead.
	
	/// <summary>
	/// The other abstraction variables.
	/// </summary>
	public int startHealth = 100;				//The amount of health the entity starts with.
	public bool startDead = false;				//The default death status of the entity.
	
	
	// Use this for initialization
	void Start () {
		dead = startDead;						// Initializes the 'dead' status of the entity
		health = startHealth;					// Initializes the health of the entity
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0){						// If the health falls below Magic Number '0'...
			Died();								// ... then the entity died. Death is handled by Died()
		}
	}
	
	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name='dmgAmount'>
	/// Dmg amount.
	/// </param>
	public void TakeDamage(int dmgAmount){
		health -= dmgAmount;
	}
	
	/// <summary>
	/// Gains the health.
	/// </summary>
	/// <param name='healAmount'>
	/// Heal amount.
	/// </param>
	void GainHealth(int healAmount){
		health += healAmount;
	}
	
	/// <summary>
	/// Died this instance.
	/// </summary>
	void Died(){
		dead = true;
		GameObject.FindGameObjectWithTag("GameController").SendMessage("Died", gameObject); 					// to game master that you are dead so it can update Targets of other Units.
		Destroy(gameObject);
	}
}

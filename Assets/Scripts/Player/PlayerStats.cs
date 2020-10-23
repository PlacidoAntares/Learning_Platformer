using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int P_Health;
<<<<<<< Updated upstream
=======
	public int P_MaxHealth;
>>>>>>> Stashed changes
	public int P_Armor;
	public bool IsAlive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float amount)
	{
		
    }

	public void Slow(float pct)
	{
		
	}

<<<<<<< Updated upstream
=======
	public void TakeDamage(int Damage)
	{
		P_Health -= Damage;
	}
>>>>>>> Stashed changes
}

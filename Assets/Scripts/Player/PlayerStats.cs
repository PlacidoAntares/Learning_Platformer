using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int P_Health;
	public int P_MaxHealth;
	public int P_Armor;
	public GameObject ExplosionSFX;
	public GameObject PlayerUnit;
	public PowerUp P_UP;
	public HealthBar HP_Bar;
	// Use this for initialization
	void Start () {
		P_Health = P_MaxHealth;
		HP_Bar.SetMaxHealth (P_MaxHealth);
	}
	
	// Update is called once per frame
	void Update () {
		if (P_Health <= 0) 
		{
			Dead ();
		}
	}

	void Dead()
	{
		Instantiate (ExplosionSFX, PlayerUnit.gameObject.transform.position, PlayerUnit.gameObject.transform.rotation);
		DestroyObject (PlayerUnit);
	}

	public void TakeDamage(int Damage)
	{
		P_Health -= Damage;
		HP_Bar.SetHealth (P_Health);
	}
}

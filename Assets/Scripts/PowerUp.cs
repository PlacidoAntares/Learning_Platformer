using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public int PowerUpID;
	public float  PowerUpDur;
	public GameObject PowerUpParent;
	public GameObject Player;
	public PlayerStats P_Stats;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		P_Stats = Player.gameObject.GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") 
			{
			Debug.Log ("Picked Up PowerUp");
			switch (PowerUpID) 
				{
			case 0:
					P_Stats.P_Health += 500;
					Debug.Log ("Healed 500 HP");
				break;
				}
			Destroy (PowerUpParent);
			}
		}
}
